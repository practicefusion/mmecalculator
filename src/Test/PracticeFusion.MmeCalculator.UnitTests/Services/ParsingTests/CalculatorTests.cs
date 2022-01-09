using System.Collections.Generic;
using System.Reflection;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeFusion.MmeCalculator.Core.Messages;
using PracticeFusion.MmeCalculator.Core.Services;

namespace PracticeFusion.MmeCalculator.UnitTests.Services.ParsingTests
{
    [TestClass]
    public class CalculatorTests
    {
        private readonly ICalculator _calculator = new Calculator(new MedicationParser(new LocalRxNormResolver.Client()));

        private static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[]
                {
                    "1495474", "1-2 tabs p.o. every Monday and Friday",
                    "Acetaminophen 325 MG / Hydrocodone Bitartrate 5 MG Oral Tablet [Lortab]", 10m
                },
                new object[]
                {
                    "897753", "infuse 1 ml 4 times daily", "1 ML Hydromorphone Hydrochloride 4 MG/ML Injection", 64m
                },
                new object[]
                {
                    "262071", "Apply two patches to upper torso q48h for chronic pain, exemption code B, palliative care",
                    "72 HR Fentanyl 0.1 MG/HR Transdermal System [Duragesic]", 480m
                },
                new object[]
                {
                    "1495474", "1-2 tabs p.o. q 8 -12 hours prn pain",
                    "Acetaminophen 325 MG / Hydrocodone Bitartrate 5 MG Oral Tablet [Lortab]", 30m
                },
                new object[] { "897653", "1-2 ML EVERY 4 HOURS AS NEEDED", "1 ML Hydromorphone Hydrochloride 1 MG/ML Injection", 48m },
                new object[]
                {
                    "892625", "0.5 milliliter(s) to 1 mL orally 4 times a day, as needed for breakthrough pain",
                    "Morphine Sulfate 20 MG/ML Oral Solution", 80m
                },
                new object[]
                {
                    "892625", "0.5 milliliter(s) orally every 1 to 2 hours, As Needed for SOB or pain",
                    "Morphine Sulfate 20 MG/ML Oral Solution", 240m
                },
                new object[]
                {
                    "857002", "1 tab(s) orally every 6 hours, As Needed Moderate to severe pain",
                    "Acetaminophen 325 MG / Hydrocodone Bitartrate 5 MG Oral Tablet", 20m
                },
                new object[]
                {
                    "864769", "1 tablet every 8 hours as needed for pain **must last 30 days**",
                    "Methadone Hydrochloride 2 MG/ML Oral Solution", 24m
                },
                new object[] { "864769", "2-4 ml orally every 4 hours x 30 days", "Methadone Hydrochloride 2 MG/ML Oral Solution", 480m },
                new object[] { "261106", "1 dose orally every day", "Fentanyl 0.2 MG Oral Lozenge [Actiq]", 26m },
                new object[]
                {
                    "261106", "Take 1 dose sublingually q 6 hr prn breakthrough pain", "Fentanyl 0.2 MG Oral Lozenge [Actiq]", 104m
                },
                new object[]
                {
                    "1053651", "1 tablet sublingual every 2 hours as needed for breakthrough pain",
                    "Fentanyl 0.1 MG Sublingual Tablet [Abstral]", 156m
                },
                new object[]
                {
                    "835603", "1-2 tab(s) orally 3 times daily as needed for pain.", "tramadol hydrochloride 50 MG Oral Tablet", 30m
                },
                new object[] { "864769", "1 ml every 6 hours", "Methadone Hydrochloride 2 MG/ML Oral Solution", 32m },
                new object[] { "864769", "1.5 ml every 6 hours", "Methadone Hydrochloride 2 MG/ML Oral Solution", 48m },
                new object[]
                {
                    "864769", "2mg every 6 hours prn moderate pain or 2mg every 4 hours prn severe pain",
                    "Methadone Hydrochloride 2 MG/ML Oral Solution", 48m
                }
            };

        private static IEnumerable<object[]> ExceptionTestData =>
            new List<object[]>
            {
                new object[] { "864769", "1,5 tablets daily", ConfidenceEnum.None, "Failed to parse the sig" },
                new object[]
                {
                    "892625", "0.5 milliliter(s) to 1 mL daily orally 4 times a day, as needed for breakthrough pain", ConfidenceEnum.None,
                    "Failed to parse the sig"
                },
                new object[]
                {
                    "262071", "Apply two patches to upper torso q48h for chronic pain - exemption code B, palliative care", ConfidenceEnum.None,
                    "Failed to parse the sig"
                }
            };

        [DataTestMethod]
        [DynamicData(nameof(TestData), DynamicDataDisplayName = "DisplayName")]
        public void BasicTests(string rxCui, string sig, string medName, decimal expectedMaximumMmePerDay)
        {
            BasicTest(rxCui, sig, medName, expectedMaximumMmePerDay);
        }

        [DataTestMethod]
        [DynamicData(nameof(ExceptionTestData), DynamicDataDisplayName = "DisplayName")]
        public void ExceptionTests(string rxCui, string sig, ConfidenceEnum confidence, string errorMessage)
        {
            ExceptionTest(rxCui, sig, confidence, errorMessage);
        }

        public static string DisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null)
            {
                return $"{methodInfo.Name} ({data[0]} : {data[1]})";
            }

            return null;
        }

        private void BasicTest(string rxCui, string sig, string medName, decimal expectedMaximumMmePerDay)
        {
            var calculateItem = new CalculationItem { RxCui = rxCui, Sig = sig };
            var request = new CalculationRequest();
            request.CalculationItems.Add(calculateItem);
            CalculatedResult result = _calculator.Calculate(request);
            result.ParsedResults[0].ParsedMedication.Should().NotBeNull();
            result.ParsedResults[0].ParsedMedication.OriginalMedication.Should().Be(medName);
            result.ParsedResults[0].ParsedSig.Should().NotBeNull();
            result.ParsedResults[0].MaximumMmePerDay.Should().Be(expectedMaximumMmePerDay);
            result.CalculatedResultAnalysis.Should().NotBeNull();
            result.CalculatedResultAnalysis.MaximumMmePerDay.Should().Be(result.ParsedResults[0].MaximumMmePerDay);
        }

        private void ExceptionTest(string rxCui, string sig, ConfidenceEnum confidence, string errorMessage)
        {
            var calculateItem = new CalculationItem { RxCui = rxCui, Sig = sig };
            var request = new CalculationRequest();
            request.CalculationItems.Add(calculateItem);
            CalculatedResult result = _calculator.Calculate(request);
            result.ParsedResults[0].ParsedSig.Should().NotBeNull();
            result.ParsedResults[0].Confidence.Should().Be(confidence);
            result.ParsedResults[0].ConfidenceReasons.Should().Contain(errorMessage);
        }
    }
}
