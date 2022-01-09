using System.Collections.Generic;
using System.Reflection;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeFusion.MmeCalculator.Core.Messages;
using PracticeFusion.MmeCalculator.Core.Services;

namespace PracticeFusion.MmeCalculator.UnitTests.Services.ParsingTests
{
    [TestClass]
    public class SigParserTests
    {
        private readonly ISigParser _sigParser = new SigParser();

        private static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[] { "take 2 tablets by mouth as one dose on the first day then take 1 tablet daily thereafter", "2 tablets", "take 2 tablets by mouth every day for 1 day", "then take 1 tablet every day thereafter" },
                new object[] { "one tab PO at HS prn knee pain", "1 tablet", "1 tablet by mouth at bedtime as needed for knee pain" },
                new object[] { "take 1-2 tablets by mouth at bedtime as needed for discomfort", "2 tablets", "take 1-2 tablets by mouth at bedtime as needed for discomfort" },
                new object[] { "take 2 tablets as one dose for the first day, then 1 tablet every day for 10 days", "2 tablets", "take 2 tablets every day for 1 day", "then 1 tablet every day for 10 days"},
                new object[] { "take 1 tablet once daily as directed ", "1 tablet", "take 1 tablet every day as directed" },
                new object[] { "1 lollipop daily", "1 lollipop", "1 lollipop every day" },
                new object[] { "1 pill at 08:00 and 14:00", "2 pills", "1 pill at 08:00 and 14:00" },
                new object[] { "1 pill at 8 am and at 2 pm", "2 pills", "1 pill at 08:00 and 14:00" },
                new object[] { "1 dose bid daily", "2 doses", "1 dose 2 times every day" },
                new object[] { "1 patch transdermal change every 72 hours", "1 patch", "1 patch transdermally every 72 hours" },
                new object[]
                {
                    "1 tab(s) orally 1 to 4 times a day x 3 days", "4 tablets", "1 tablet by mouth 1-4 times every day for 3 days"
                },
                new object[] { "10 ml every 6 hours", "40 ml", "10 ml every 6 hours" },
                new object[] { "2mg/ml every 4 hours", "12 mg/ml", "2 mg/ml every 4 hours" },
                new object[]
                {
                    "1 tab(s) orally every 4 hours as needed for pain x 90 days", "6 tablets",
                    "1 tablet by mouth every 4 hours as needed for pain for 90 days"
                },
                new object[] { "1 pill at 8am", "1 pill", "1 pill at 08:00" },
                new object[] { "Half tablet twice a day as needed.", "1 tablet", "0.5 tablet 2 times every day as needed" },
                new object[] { "1 q8h", "3", "1 every 8 hours" },
                new object[] { "1 tablet po q6hr prn pain", "4 tablets", "1 tablet by mouth every 6 hours as needed for pain" },
                new object[] { "2 tablets q8hr", "6 tablets", "2 tablets every 8 hours" },
                new object[] { "0.25mg sl q 2 hrs prn", "3 mg", "0.25 mg sublingually every 2 hours as needed" },
                new object[]
                {
                    "0.25 milliliters to 0.5 milliliters po q 2 hrs po prn severe pain", "6 ml",
                    "0.25-0.5 ml by mouth every 2 hours as needed for severe pain"
                },
                new object[] { "2 tablets q8hr for 1 week", "6 tablets", "2 tablets every 8 hours for 1 week" },
                new object[]
                {
                    "take 1 tablets up to 4 times a day as needed for pain", "4 tablets", "take 1 tablet 4 times every day as needed for pain"
                },
                new object[]
                {
                    "take 1 tablets up to 4 times a day on an empty stomach as needed for pain", "4 tablets", "take 1 tablet 4 times every day on an empty stomach as needed for pain"
                },
            };

        private static IEnumerable<object[]> MddTestData =>
            new List<object[]>
            {
                #region Test Data

                new object[] { "1 tablet 3 times a day", 3m },
                new object[] { "1 tablet 3 times a week", 1m },
                new object[] { "1 tablet 4 times a day", 4m },
                new object[] { "1 tablet 5 times a day", 5m },
                new object[] { "1 tablet every 18 hours", 1.3333333333333333333333333333m },
                new object[] { "1 tablet every 36 hours", 1m },
                new object[] { "1 tablet every 48 hours", 1m },
                new object[] { "1 tablet every 72 hours", 1m },
                new object[] { "1 tablet every 7 days", 1m },
                new object[] { "1 tablet every other day", 1m },
                new object[] { "1 tablet once a day", 1m },
                new object[] { "1 tablet once a month", 1m },
                new object[] { "1 tablet once a week", 1m },
                new object[] { "1 tablet 2 times a day", 2m },
                new object[] { "1 tablet 2 times a week", 1m },
                new object[] { "1 tablet every 15 minutes", 96m },
                new object[] { "1 tablet every hour", 24m },
                new object[] { "1 tablet 10 times a day", 10m },
                new object[] { "1 tablet 12 times a day", 12m },
                new object[] { "1 tablet 16 times a day", 16m },
                new object[] { "1 tablet 6 times a day", 6m },
                new object[] { "1 tablet 7 times a day", 7m },
                new object[] { "1 tablet 8 times a day", 8m },
                new object[] { "1 tablet every 16 hours", 1.5m },
                new object[] { "1 tablet every 2 weeks", 1m },
                new object[] { "1 tablet every 30 minutes", 48m },
                new object[] { "1 tablet every 40 hours", 1m },
                new object[] { "1 tablet 9 times a day", 9m },
                new object[] { "1 tablet every 3 weeks", 1m },
                new object[] { "1 tablet every 5 days", 1m },
                new object[] { "1 tablet every 60 hours", 1m },
                new object[] { "1 tablet every 6 weeks", 1m },
                new object[] { "1 tablet 3 times a day (after meals)", 3m },
                new object[] { "1 tablet 3 times a day (before meals)", 3m },
                new object[] { "1 tablet 3 times a day (with meals)", 3m },
                new object[] { "1 tablet 4 times a day (after meals and at bedtime)", 4m },
                new object[] { "1 tablet 4 times a day (before meals and at bedtime)", 4m },
                new object[] { "1 tablet 4 times a day (with meals and at bedtime)", 4m },
                new object[] { "1 tablet every 10 minutes", 144m },
                new object[] { "1 tablet every 12 hours", 2m },
                new object[] { "1 tablet every 2 hours", 12m },
                new object[] { "1 tablet every 24 hours", 1m },
                new object[] { "1 tablet every 3 days", 1m },
                new object[] { "1 tablet every 3 hours", 8m },
                new object[] { "1 tablet every 4 days", 1m },
                new object[] { "1 tablet every 4 hours", 6m },
                new object[] { "1 tablet every 5 minutes", 288m },
                new object[] { "1 tablet every 6 hours", 4m },
                new object[] { "1 tablet every 8 hours", 3m },
                new object[] { "1 tablet every 96 hours", 1m },
                new object[] { "1 tablet once a day (at bedtime)", 1m },
                new object[] { "1 tablet once a day (in the morning)", 1m },
                new object[] { "1 tablet once a day (before a meal)", 1m },
                new object[] { "1 tablet 4 to 6 times a day", 6m },
                new object[] { "1 tablet every 1 to 2 hours", 24m },
                new object[] { "1 tablet every 3 months", 1m },
                new object[] { "1 tablet every 30 to 60 minutes", 48m },
                new object[] { "1 tablet 5 times a week", 1m },
                new object[] { "1 tablet 2 times a day (with meals)", 2m },
                new object[] { "1 tablet 2 to 4 times a day", 4m },
                new object[] { "1 tablet 1 to 2 times a day", 2m },
                new object[] { "1 tablet every 6 to 15 minutes", 240m },
                new object[] { "1 tablet every 10 to 15 minutes", 144m },
                new object[] { "1 tablet every 4 to 6 hours", 6m },
                new object[] { "1 tablet every 6 to 8 hours", 4m },
                new object[] { "1 tablet 3 to 4 times a day", 4m },
                new object[] { "1 tablet 1 to 4 times a day", 4m },
                new object[] { "1 tablet every 5 to 8 months", 1m },
                new object[] { "1 tablet 4 times a week", 1m },
                new object[] { "1 tablet 6 times a week", 1m },
                new object[] { "1 tablet every 10 to 30 minutes", 144m },
                new object[] { "1 tablet every 2 to 3 hours", 12m },
                new object[] { "1 tablet every 2 to 3 minutes", 720m },
                new object[] { "1 tablet every 2 to 4 hours", 12m },
                new object[] { "1 tablet every 25 to 60 minutes", 57.6m },
                new object[] { "1 tablet every 25 minutes", 57.6m },
                new object[] { "1 tablet every 2 to 5 minutes", 720m },
                new object[] { "1 tablet every 2 minutes", 720m },
                new object[] { "1 tablet every 3 to 4 hours", 8m },
                new object[] { "1 tablet every 3 to 5 hours", 8m },
                new object[] { "1 tablet every 3 to 6 hours", 8m },
                new object[] { "1 tablet every 4 weeks", 1m },
                new object[] { "1 tablet every 5 to 15 minutes", 288m },
                new object[] { "1 tablet every 6 months", 1m },
                new object[] { "1 tablet every 8 to 12 hours", 3m },
                new object[] { "1 tablet every 20 minutes", 72m },
                new object[] { "1 tablet every 5 hours", 4.8m },
                new object[] { "1 tablet every 5 to 10 minutes", 288m },
                new object[] { "1 tablet 2 times a day (after meals)", 2m },
                new object[] { "1 tablet once a day (after a meal)", 1m },
                new object[] { "1 tablet every other day (at bedtime)", 1m },
                new object[] { "1 tablet once a day (in the evening)", 1m },
                new object[] { "1 tablet every 3 to 4 weeks", 1m },
                new object[] { "1 tablet 3 to 4 times a week", 1m },
                new object[] { "1 tablet 1 to 3 times a day", 3m },
                new object[] { "1 tablet every 4 hours while awake", 6m },
                new object[] { "1 tablet every 4 months", 1m },
                new object[] { "1 tablet every 90 minutes", 16m },
                new object[] { "1 tablet every 10 hours", 2.4m },
                new object[] { "1 tablet every 4 hours (5 times/day)", 5m },
                new object[] { "1 tablet 2 times a day (before meals)", 2m },
                new object[] { "1 tablet every 4 to 8 hours", 6m },
                new object[] { "1 tablet every 3 to 6 months", 1m },
                new object[] { "1 tablet every 3 to 4 days", 1m },
                new object[] { "1 tablet 2 times a day (3 days a week)", 2m },
                new object[] { "1 tablet every 3 minutes", 480m },
                new object[] { "1 tablet every 8 weeks", 1m },
                new object[] { "1 tablet every 2 months", 1m },
                new object[] { "1 tablet every 10 weeks", 1m },
                new object[] { "1 tablet 2 times a month", 1m },
                new object[] { "1 tablet every 4 minutes", 360m },
                new object[] { "1 tablet every 6 days", 1m },

                #endregion
            };

        private static IEnumerable<object[]> ExceptionTestData =>
            new List<object[]>
            {
                new object[] { "take 1,5 tablets daily", ConfidenceEnum.None, "Failed to parse 1,5 as a valid number." },
            };


        [DataTestMethod]
        [DynamicData(nameof(TestData), DynamicDataDisplayName = "DisplayName")]
        public void RoundTripTests(string input, string expectedMaximumDailyDose, params string[] expected)
        {
            RoundTripTest(input, expectedMaximumDailyDose, expected);
        }

        [DataTestMethod]
        [DynamicData(nameof(MddTestData), DynamicDataDisplayName = "DisplayName")]
        public void RoundTripTests(string input, decimal expectedMaximumDailyDose)
        {
            RoundTripTest(input, expectedMaximumDailyDose);
        }

        [DataTestMethod]
        [DynamicData(nameof(ExceptionTestData), DynamicDataDisplayName = "DisplayName")]
        public void ExceptionTests(string input, ConfidenceEnum confidence, string errorMessage)
        {
            ExceptionTest(input, confidence, errorMessage);
        }

        public static string DisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null)
            {
                return $"{methodInfo.Name} ({data[0]})";
            }

            return null;
        }

        private void RoundTripTest(string input, string expectedMaximumDailyDose, params string[] expected)
        {
            var result = _sigParser.Parse(input);
            result.Dosages.Should().NotBeNull();
            for (int i = 0; i < expected.Length; i++)
            {
                result.Dosages[i].ToString().Should().Be(expected[i]);

                // ensure there is no "Google Translate" type of error
                var googleTranslation = _sigParser.Parse(result.Dosages[i].ToString());
                googleTranslation.Dosages[0].ToString().Should().Be(
                    expected[i],
                    "because the human-readable output of a dosage should not change when parsed");
            }

            if (expectedMaximumDailyDose != null)
            {
                result.MaximumDosage.ToString().Should().Be(expectedMaximumDailyDose);
            }
        }

        private void RoundTripTest(string input, decimal expectedMaximumDailyDose)
        {
            var result = _sigParser.Parse(input);
            result.Dosages.Should().NotBeNull();
            result.MaximumDosage.Should().NotBeNull();
            result.MaximumDosage.MaxDose.Should().Be(expectedMaximumDailyDose);
        }

        private void ExceptionTest(string input, ConfidenceEnum confidence, string errorMessage)
        {
            var result = _sigParser.Parse(input);
            result.Dosages.Should().NotBeNull();
            result.Dosages.Should().BeEmpty();
            result.Confidence.Should().Be(confidence);
            result.ConfidenceReasons.Should().Contain(errorMessage);
        }
    }
}
