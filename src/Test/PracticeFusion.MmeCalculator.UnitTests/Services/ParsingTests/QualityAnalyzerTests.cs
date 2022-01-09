using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeFusion.MmeCalculator.Core.Messages;
using PracticeFusion.MmeCalculator.Core.Services;

namespace PracticeFusion.MmeCalculator.UnitTests.Services.ParsingTests
{
    [TestClass]
    public class QualityAnalyzerTests
    {
        private readonly ICalculator _calculator = new Calculator(new MedicationParser(new LocalRxNormResolver.Client()));

        [DataTestMethod]
        [DynamicData(nameof(ReadTestDataFromFile), DynamicDataSourceType.Method, DynamicDataDisplayName = "DisplayName")]
        public void QualityAnalyzerTest(TestMedicationList t)
        {
            // construct the calculator request
            CalculationRequest request = new CalculationRequest() { RequestId = t.Id };
            foreach (var testItem in t.TestItems)
            {
                var calculationItem = new CalculationItem()
                    { RequestItemId = testItem.Id, RxCui = testItem.RxCui, Sig = testItem.Instruction };
                request.CalculationItems.Add(calculationItem);
            }

            // calculate the request
            CalculatedResult result = _calculator.Calculate(request);

            // check the result
            result.CalculatedResultAnalysis.Should().NotBeNull();
            result.CalculatedResultAnalysis.MaximumMmePerDay.Should().Be(t.ExpectedMme);
            result.CalculatedResultAnalysis.Confidence.Should().Be(t.Confidence);
        }

        public static string DisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null)
            {
                return $"{methodInfo.Name} ({(data[0] as TestMedicationList)?.Description} {(data[0] as TestMedicationList)?.Id})";
            }

            return null;
        }

        public static IEnumerable<object[]> ReadTestDataFromFile()
        {
            var testFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "CalculationRequests.txt");
            var calculationRequests = File.ReadLines(testFile);
            var calculationRequest = new TestMedicationList();
            foreach (var line in calculationRequests)
            {
                var parts = line.Split('\t');
                if (parts.Length > 4)
                {
                    TestItem testItem = new TestItem(parts);
                    calculationRequest.TestItems.Add(testItem);
                }
                else
                {
                    calculationRequest.Id = parts[0];
                    calculationRequest.ExpectedMme = decimal.Parse(parts[1]);
                    calculationRequest.Description = parts[2];
                    calculationRequest.Confidence = (ConfidenceEnum) Enum.Parse(typeof(ConfidenceEnum), parts[3]);
                    yield return new object[] { calculationRequest };

                    // reset and continue
                    calculationRequest = new TestMedicationList();
                }
            }
        }
    }
}
