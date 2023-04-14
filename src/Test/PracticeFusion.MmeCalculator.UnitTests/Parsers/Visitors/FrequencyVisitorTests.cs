using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Parsers;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;
using PracticeFusion.MmeCalculator.Core.Parsers.Visitors;
using System.Collections.Generic;
using System.Reflection;

namespace PracticeFusion.MmeCalculator.UnitTests.Parsers.Visitors
{
    [TestClass]
    public class FrequencyVisitorTests
    {
        private readonly CoreParserTestHelper<FrequencyVisitor, DefaultParser.FrequencyContext, Frequency> _helper =
            new();

        private static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                // basic frequency: frequencyVal PER... periodVal period
                new object[] { "once per second", "once per second" },
                new object[] { "per week", "per week" },
                new object[] { "2 times per second", "2 times per second" },
                new object[] { "twice per second", "2 times per second" },
                new object[] { "thrice per hour", "3 times per hour" },
                new object[] { "1-2 times each day", "1-2 times every day" },
                new object[] { "1 time a day", "every day" },
                new object[] { "2-4 times each week", "2-4 times every week" },
                new object[] { "once every 1-2 days", "every 1-2 days" },
                new object[] { "1-2 times every other day", "1-2 times every 2 days" },
                new object[] { "twice every other day", "2 times every 2 days" },

                // basic frequency: frequencyVal periodly
                new object[] { "hourly", "every hour" },
                new object[] { "daily", "every day" },
                new object[] { "weekly", "every week" },
                new object[] { "monthly", "every month" },
                new object[] { "twice daily", "2 times every day" },
                new object[] { "thrice weekly", "3 times every week" },

                // day frequency
                new object[]
                {
                    "once daily every monday, wednesday and friday", "a day every Monday, Wednesday and Friday"
                },
                new object[]
                {
                    "once daily on monday, wednesday and friday", "a day every Monday, Wednesday and Friday"
                },
                new object[] { "twice daily every tuesday", "2 times a day every Tuesday" },
                new object[] { "thrice daily every saturday and sunday", "3 times a day every Saturday and Sunday" },
                new object[] { "thrice daily on saturday and sunday", "3 times a day every Saturday and Sunday" },
                new object[] { "1 time a day every tuesday and thursday", "a day every Tuesday and Thursday" },

                //latin frequency: expressions
                new object[] { "1 times q6h", "every 6 hours" },
                new object[] { "q 6 h", "every 6 hours" },
                new object[] { "2 times q6h", "2 times every 6 hours" },
                new object[] { "2 times q d", "2 times every day" },

                // latin abbreviations
                new object[] { "qd", "every day" },
                new object[] { "qod", "every 2 days" },
                new object[] { "bid", "2 times every day" },
                new object[] { "tid", "3 times every day" },
                new object[] { "qid", "4 times every day" },

                //// latin abbreviations with timings
                //new object[] { "qhs", "at bedtime" },
                //new object[] { "qn", "every night" },
                //new object[] { "qpm", "every afternoon" },
                //new object[] { "1 tablet once at bedtime", "at bedtime" },
                new object[] { "every day at noon", "every day at noon" },
                new object[] { "every day at mid day", "every day at noon" },
                new object[] { "every day at bed time", "every day at bedtime" },
                new object[] { "Take one capsule by mouth one time daily", "every day" },
                new object[] { "2 times qd", "2 times every day" },
                new object[] { "3 times qd", "3 times every day" },
                new object[] { "4 times qd", "4 times every day" },
                new object[] { "1 tablet daily", "every day" },
                new object[] { "1 tablet at 14:00 and 22:00", "at 14:00 and 22:00" },
                new object[] { "1 tablet per day", "per day" },
                new object[] { "every other day after", "every 2 days" },
                new object[] { "every day after", "every day" },
                new object[] { "two times a day after", "2 times every day" },
                new object[] { "three times a day after", "3 times every day" },
                new object[] { "four times a day after", "4 times every day" },
                new object[] { "every hour after", "every hour" },
                new object[] { "every month after", "every month" },
                new object[] { "every week after", "every week" },
                new object[] { "every 4-6 hours after", "every 4-6 hours" },
                new object[] { "1-2 times per day", "1-2 times per day" },
                new object[] { "every 6 hrs after", "every 6 hours" },
                new object[] { "tablet up to 4 times daily", "4 times every day" },
                new object[] { "tablet up to 4 times every day", "4 times every day" },
                new object[] { "tablet up to every 4 hours", "every 4 hours" },
                new object[] { "tablet by mouth 3x daily", "3 times every day" },
                new object[] { "change q 48 hrs", "every 48 hours" },
                new object[] { "1 tablet at 7am", "at 07:00" },
                new object[] { "1 tablet at 10 pm", "at 22:00" },
                new object[] { "1 tablet at 14:00", "at 14:00" },
                new object[] { "1 tablet at 8am and 2pm", "at 08:00 and 14:00" },
                new object[] { "1 tablet every other day at 8am and 2pm", "every 2 days at 08:00 and 14:00" },
                new object[] { "every 4 hours (5 times/day)", "every 4 hours (5 times/day)" }
            };

        private static IEnumerable<object[]> OneWayOnlyTestData =>
            new List<object[]>
            {
                new object[] { "every day before noon", "every day before noon" },
                new object[] { "every day in the afternoon", "every day in the afternoon" },
                new object[] { "every morning", "in the morning" },
                new object[] { "every night", "at night" },
                new object[] { "qhs after", "every day at bedtime" },
                new object[] { "5 times qd", "every 4 hours (5 times/day)" }
            };

        private static IEnumerable<object[]> ExceptionData =>
            new List<object[]>
            {
                // negative tests (should throw an exception until we decide how to handle them
                new object[] { "1 tablet 3 times as needed", "3 times" }

                // a possible form of bedtime
                // new object[] { "every bed time after", "at bedtime" },
            };

        [TestMethod]
        public void NullContextShouldThrowParseException()
        {
            _helper.NullContextShouldThrowParseException();
        }

        [TestMethod]
        public void FrequencyContainingTwiceADayAfterEveryMealDefersToTwiceADay()
        {
            Frequency frequency = ParseStatement("1 tablet 2 times per day with meals");
            frequency.MaximumDailyFrequency.Should().Be(2);
        }

        [TestMethod]
        public void FrequencyContainingBeforeEveryMealInfers3TimesADay()
        {
            Frequency frequency = ParseStatement("1 tablet daily before every meal");
            frequency.HumanReadable.Should().Be("every day before every meal");
        }

        [TestMethod]
        public void FrequencyContainingAfterEveryMealInfers3TimesADay()
        {
            Frequency frequency = ParseStatement("1 tablet daily after every meal");
            frequency.HumanReadable.Should().Be("every day after every meal");
        }

        [TestMethod]
        public void FrequencyContainingWithEveryMealInfers3TimesADay()
        {
            Frequency frequency = ParseStatement("1 tablet daily with every meal");
            frequency.HumanReadable.Should().Be("every day with every meal");
        }

        [TestMethod]
        public void FrequencyContainingEveryMealInfers3TimesADayEvenEveryOtherDay()
        {
            Frequency frequency = ParseStatement("1 tablet qod before every meal");
            frequency.HumanReadable.Should().Be("every 2 days before every meal");
        }

        [TestMethod]
        public void FrequencyMergesMultipleIntervalsAppropriately()
        {
            Frequency frequency = ParseStatement("1 tablet twice a day every other day");
            frequency.HumanReadable.Should().Be("2 times every 2 days");
            frequency.Intervals.Count.Should().Be(1);

            // twice a day, merged with...
            frequency.Intervals[0].Freq.Should().Be(2);
            frequency.Intervals[0].FreqMax.Should().Be(2);

            // every other day
            frequency.Intervals[0].PeriodUnit.Should().Be(PeriodEnum.Day);
            frequency.Intervals[0].Period.Should().Be(2);
            frequency.Intervals[0].PeriodMax.Should().Be(2);
        }

        [TestMethod]
        public void FrequencyWithADailyIntervalMergesCorrectly()
        {
            // Every 12 hours daily should parse as every 12 hours
            Frequency frequency = ParseStatement("1 tablet every 12 hours daily");
            frequency.HumanReadable.Should().Be("every 12 hours");
            frequency.Intervals.Count.Should().Be(1);
            frequency.MaximumDailyFrequency.Should().Be(2);
        }

        [TestMethod]
        public void EventsWithProximityShouldBeCountedOnce()
        {
            // Some events are proximate, like "at night" and "at bedtime". They should
            // not count as two separate events. We prefer "at bedtime" as a more precise
            // event.
            Frequency frequency = ParseStatement("1 tablet every night at bedtime");
            frequency.HumanReadable.Should().Be("at bedtime");
            frequency.MaximumDailyFrequency.Should().Be(1);
            frequency.When.Count.Should().Be(1);
            frequency.When[0].Should().Be(EventTimingEnum.BedTime);
        }

        [TestMethod]
        public void VariationsBetweenIntervalsAndTimesOfDayShouldBeReportedAsAmbiguous()
        {
            // 1 tablet three times a day at 8am and 6pm should throw an exception
            this.Invoking(x => x.ParseStatement("1 tablet tid at 8am and 6pm")).Should()
                .ThrowExactly<ParsingException>()
                .WithMessage("Ambiguous frequency: contradicting directions '3 times every day at 08:00 and 18:00'");
        }

        [TestMethod]
        public void FrequenciesWithTimesOfDayInjectAnIntervalIfNeeded()
        {
            // 1 tablet at 8am and 6pm has a frequency of 2
            Frequency frequency = ParseStatement("1 tablet at 8am and 6pm");
            frequency.TimeOfDay.Count.Should().Be(2);
            frequency.Intervals.Count.Should().Be(1);
            frequency.Intervals[0].Freq.Should().Be(2);
            frequency.Intervals[0].FreqMax.Should().Be(2);
            frequency.MaximumDailyFrequency.Should().Be(2);
        }

        [TestMethod]
        public void FrequenciesWithOneAdministrationEventCalculateCorrectMaximumDailyFrequency()
        {
            // 1 tablet in the morning has a frequency of 1
            Frequency frequency = ParseStatement("1 tablet in the morning");
            frequency.When.Count.Should().Be(1);
            frequency.Intervals.Count.Should().Be(1);
            frequency.Intervals[0].Freq.Should().Be(1);
            frequency.Intervals[0].FreqMax.Should().Be(1);
            frequency.MaximumDailyFrequency.Should().Be(1);
        }

        [TestMethod]
        public void FrequenciesWithMoreThanOneAdministrationEventsCalculateCorrectMaximumDailyFrequency()
        {
            // 1 tablet at morning and evening has a frequency of 2
            Frequency frequency = ParseStatement("1 tablet at morning and evening");
            frequency.When.Count.Should().Be(2);
            frequency.Intervals.Count.Should().Be(1);
            frequency.Intervals[0].Freq.Should().Be(2);
            frequency.Intervals[0].FreqMax.Should().Be(2);
            frequency.MaximumDailyFrequency.Should().Be(2);
        }

        [TestMethod]
        public void FrequenciesWithMoreThanOneAdministrationEventsAndAnIntervalCalculateCorrectMaximumDailyFrequency()
        {
            // 1 tablet daily at morning and evening has a frequency of 2
            Frequency frequency = ParseStatement("1 tablet daily at morning and evening");
            frequency.HumanReadable.Should().Be("every day in the morning and at night");
            frequency.When.Count.Should().Be(2);
            frequency.Intervals.Count.Should().Be(1);
            frequency.Intervals[0].Freq.Should().Be(0);
            frequency.Intervals[0].FreqMax.Should().Be(0);
            frequency.MaximumDailyFrequency.Should().Be(2);
        }

        [TestMethod]
        public void FrequenciesWithTimesOfDayAndAZeroFrequencyIntervalCalculateCorrectMaximumDailyFrequency()
        {
            // 1 tablet daily at 8am and 6pm has a frequency of 2
            Frequency frequency = ParseStatement("1 tablet daily at 8am and 6pm");
            frequency.HumanReadable.Should().Be("every day at 08:00 and 18:00");
            frequency.TimeOfDay.Count.Should().Be(2);
            frequency.Intervals.Count.Should().Be(1);
            frequency.Intervals[0].Freq.Should().Be(0);
            frequency.Intervals[0].FreqMax.Should().Be(0);
            frequency.MaximumDailyFrequency.Should().Be(2);
        }


        [TestMethod]
        public void ShouldSetContainsLatinAbbreviationsWhenLatinIsPresentInFrequency()
        {
            Frequency result = ParseStatement("1 tablet tid");
            result.ContainsLatinAbbreviations.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldSetContainsLatinAbbreviationsWhenLatinIsPresentInTiming()
        {
            Frequency result = ParseStatement("1 tablet qhs");
            result.ContainsLatinAbbreviations.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldNotSetContainsLatinAbbreviationsWhenLatinIsAbsentInFrequency()
        {
            Frequency result = ParseStatement("1 tablet 3 times a day");
            result.ContainsLatinAbbreviations.Should().BeFalse();
        }

        [TestMethod]
        public void ShouldNotSetContainsLatinAbbreviationsWhenLatinIsAbsentInTiming()
        {
            Frequency result = ParseStatement("1 tablet at bedtime");
            result.ContainsLatinAbbreviations.Should().BeFalse();
        }

        [TestMethod]
        public void ShouldSetContainsLatinAbbreviationsWhenLatinQIsPresentInFrequency()
        {
            Frequency result = ParseStatement("1 tablet q4h");
            result.ContainsLatinAbbreviations.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldSetContainsLatinAbbreviationsWhenLatinQIsPresentInFrequencyWithPeriodly()
        {
            Frequency result = ParseStatement("1 tablet q daily");
            result.ContainsLatinAbbreviations.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldNotSetContainsLatinAbbreviationsWhenLatinQIsAbsentInFrequency()
        {
            Frequency result = ParseStatement("1 tablet every 4 hours");
            result.ContainsLatinAbbreviations.Should().BeFalse();
        }

        [TestMethod]
        public void ShouldNotSetContainsLatinAbbreviationsWhenLatinQIsAbsentInFrequencyWithPeriodly()
        {
            Frequency result = ParseStatement("1 tablet daily");
            result.ContainsLatinAbbreviations.Should().BeFalse();
        }

        [TestMethod]
        public void CanParseInTheAfternoonCorrectly()
        {
            Frequency result = ParseStatement("1 tablet every day in the afternoon");
            result.When.Should().Contain(EventTimingEnum.InTheAfternoon);
        }

        [DataTestMethod]
        [DynamicData(nameof(TestData), DynamicDataDisplayName = "DisplayName")]
        public void OneWayTests(string statement, string expected)
        {
            VisitTest(statement, expected);
        }

        [DataTestMethod]
        [DynamicData(nameof(OneWayOnlyTestData), DynamicDataDisplayName = "DisplayName")]
        public void OneWayOnlyTests(string statement, string expected)
        {
            VisitTest(statement, expected);
        }

        [DataTestMethod]
        [DynamicData(nameof(TestData), DynamicDataDisplayName = "DisplayName")]
        public void RoundTripTests(string statement, string expected)
        {
            // round trip it, make sure we what we emit, when parsed
            // is emitted exactly the same (i.e. no google translate errors).
            VisitTest(expected, expected);
        }

        [DataTestMethod]
        [DynamicData(nameof(ExceptionData), DynamicDataDisplayName = "DisplayName")]
        public void ExceptionTests(string statement, string expected)
        {
            this.Invoking(x => x.VisitTest(statement, expected)).Should()
                .Throw<ParsingException>();
        }

        public static string DisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null)
            {
                return $"{methodInfo.Name} ({data[0]} : {data[1]})";
            }

            return null;
        }

        private void VisitTest(string statement, string expected)
        {
            Frequency result = ParseStatement(statement);
            result.ToString().Should().Be(expected);
        }

        private Frequency ParseStatement(string statement)
        {
            DefaultParser.TestFrequenciesContext tree = _helper.DefaultParser(statement).testFrequencies();
            tree.frequencies().Should().NotBeNull();
            Frequency result = _helper.Visitor.VisitAllRoot(tree.frequencies().frequency());
            return result;
        }
    }
}