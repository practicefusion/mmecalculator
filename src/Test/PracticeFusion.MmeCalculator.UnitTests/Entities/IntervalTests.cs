using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeFusion.MmeCalculator.Core.Entities;

namespace PracticeFusion.MmeCalculator.UnitTests.Entities
{
    [TestClass]
    public class IntervalTests
    {
        [TestMethod]
        public void OneTimePerDayShouldBeExpressedAsOncePerDay()
        {
            Interval result = new Interval()
                { Freq = 1, FreqMax = 1, Period = 1, PeriodMax = 1, PeriodUnit = PeriodEnum.Day, ExpressAsPer = true, Inferred = false };
            result.ToString().Should().Be("once per day");
        }

        [TestMethod]
        public void TwoTimesEveryDayShouldBeExpressedAs2TimesEveryDay()
        {
            Interval result = new Interval()
                { Freq = 2, FreqMax = 2, Period = 1, PeriodMax = 1, PeriodUnit = PeriodEnum.Day, ExpressAsPer = false, Inferred = false };
            result.ToString().Should().Be("2 times every day");
        }

        // Singular
        [TestMethod]
        public void OneTimeEveryMinuteShouldBeExpressedAsEveryMinute()
        {
            Interval result = new Interval()
                { Freq = 1, FreqMax = 1, Period = 1, PeriodMax = 1, PeriodUnit = PeriodEnum.Minute, ExpressAsPer = false, Inferred = false };
            result.ToString().Should().Be("every minute");
        }

        [TestMethod]
        public void OneTimeEveryHourShouldBeExpressedAsEveryHour()
        {
            Interval result = new Interval()
                { Freq = 1, FreqMax = 1, Period = 1, PeriodMax = 1, PeriodUnit = PeriodEnum.Hour, ExpressAsPer = false, Inferred = false };
            result.ToString().Should().Be("every hour");
        }

        [TestMethod]
        public void OneTimeEveryDayShouldBeExpressedAsEveryDay()
        {
            Interval result = new Interval()
                { Freq = 1, FreqMax = 1, Period = 1, PeriodMax = 1, PeriodUnit = PeriodEnum.Day, ExpressAsPer = false, Inferred = false };
            result.ToString().Should().Be("every day");
        }

        [TestMethod]
        public void OneTimeEveryWeekShouldBeExpressedAsEveryWeek()
        {
            Interval result = new Interval()
                { Freq = 1, FreqMax = 1, Period = 1, PeriodMax = 1, PeriodUnit = PeriodEnum.Week, ExpressAsPer = false, Inferred = false };
            result.ToString().Should().Be("every week");
        }

        [TestMethod]
        public void OneTimeEveryMonthShouldBeExpressedAsEveryMonth()
        {
            Interval result = new Interval()
                { Freq = 1, FreqMax = 1, Period = 1, PeriodMax = 1, PeriodUnit = PeriodEnum.Month, ExpressAsPer = false, Inferred = false };
            result.ToString().Should().Be("every month");
        }

        [TestMethod]
        public void OneTimeEveryYearShouldBeExpressedAsEveryYear()
        {
            Interval result = new Interval()
                { Freq = 1, FreqMax = 1, Period = 1, PeriodMax = 1, PeriodUnit = PeriodEnum.Year, ExpressAsPer = false, Inferred = false };
            result.ToString().Should().Be("every year");
        }

        // Plural
        [TestMethod]
        public void OneTimeEvery2MinutesShouldBeExpressedAsEvery2Minutes()
        {
            Interval result = new Interval()
            { Freq = 1, FreqMax = 1, Period = 2, PeriodMax = 2, PeriodUnit = PeriodEnum.Minute, ExpressAsPer = false, Inferred = false };
            result.ToString().Should().Be("every 2 minutes");
        }

        [TestMethod]
        public void OneTimeEvery2HoursShouldBeExpressedAsEvery2Hours()
        {
            Interval result = new Interval()
            { Freq = 1, FreqMax = 1, Period = 2, PeriodMax = 2, PeriodUnit = PeriodEnum.Hour, ExpressAsPer = false, Inferred = false };
            result.ToString().Should().Be("every 2 hours");
        }

        [TestMethod]
        public void OneTimeEvery2DaysShouldBeExpressedAsEvery2Days()
        {
            Interval result = new Interval()
            { Freq = 1, FreqMax = 1, Period = 2, PeriodMax = 2, PeriodUnit = PeriodEnum.Day, ExpressAsPer = false, Inferred = false };
            result.ToString().Should().Be("every 2 days");
        }

        [TestMethod]
        public void OneTimeEvery2WeeksShouldBeExpressedAsEvery2Weeks()
        {
            Interval result = new Interval()
            { Freq = 1, FreqMax = 1, Period = 2, PeriodMax = 2, PeriodUnit = PeriodEnum.Week, ExpressAsPer = false, Inferred = false };
            result.ToString().Should().Be("every 2 weeks");
        }

        [TestMethod]
        public void OneTimeEvery2MonthsShouldBeExpressedAsEvery2Months()
        {
            Interval result = new Interval()
            { Freq = 1, FreqMax = 1, Period = 2, PeriodMax = 2, PeriodUnit = PeriodEnum.Month, ExpressAsPer = false, Inferred = false };
            result.ToString().Should().Be("every 2 months");
        }

        [TestMethod]
        public void OneTimeEvery2YearsShouldBeExpressedAsEvery2Years()
        {
            Interval result = new Interval()
            { Freq = 1, FreqMax = 1, Period = 2, PeriodMax = 2, PeriodUnit = PeriodEnum.Year, ExpressAsPer = false, Inferred = false };
            result.ToString().Should().Be("every 2 years");
        }

        [TestMethod]
        public void MaxiumDailyFrequencyForMilliseconds()
        {
            Interval result = new Interval()
                { Freq = 1, FreqMax = 1, Period = 1, PeriodMax = 1, PeriodUnit = PeriodEnum.Millisecond, ExpressAsPer = false, Inferred = false };

            // 24 hours * 60 minutes * 60 seconds * 1,000 milliseconds per day
            result.MaximumDailyFrequency.Should().Be(24 * 60 * 60 * 1000);
        }

        [TestMethod]
        public void MaxiumDailyFrequencyForSeconds()
        {
            Interval result = new Interval()
                { Freq = 1, FreqMax = 1, Period = 1, PeriodMax = 1, PeriodUnit = PeriodEnum.Second, ExpressAsPer = false, Inferred = false };

            // 24 hours * 60 minutes * 60 seconds per day
            result.MaximumDailyFrequency.Should().Be(24 * 60 * 60);
        }

        [TestMethod]
        public void MaxiumDailyFrequencyForMinutes()
        {
            Interval result = new Interval()
                { Freq = 1, FreqMax = 1, Period = 1, PeriodMax = 1, PeriodUnit = PeriodEnum.Minute, ExpressAsPer = false, Inferred = false };

            // 24 hours * 60 minutes per day
            result.MaximumDailyFrequency.Should().Be(24 * 60);
        }


        [TestMethod]
        public void MaxiumDailyFrequencyForHours()
        {
            Interval result = new Interval()
                { Freq = 1, FreqMax = 1, Period = 1, PeriodMax = 1, PeriodUnit = PeriodEnum.Hour, ExpressAsPer = false, Inferred = false };

            // 24 hours per day
            result.MaximumDailyFrequency.Should().Be(24);
        }

        [TestMethod]
        public void MaxiumDailyFrequencyForDay()
        {
            Interval result = new Interval()
                { Freq = 1, FreqMax = 1, Period = 1, PeriodMax = 1, PeriodUnit = PeriodEnum.Day, ExpressAsPer = false, Inferred = false };

            // 1 day per day
            result.MaximumDailyFrequency.Should().Be(1);
        }

        [TestMethod]
        public void MaxiumDailyFrequencyForWeek()
        {
            Interval result = new Interval()
                { Freq = 1, FreqMax = 1, Period = 1, PeriodMax = 1, PeriodUnit = PeriodEnum.Week, ExpressAsPer = false, Inferred = false };

            // on any day in that week, the maximum daily frequency is 1 day
            result.MaximumDailyFrequency.Should().Be(1);
        }

        [TestMethod]
        public void MaxiumDailyFrequencyForMonth()
        {
            Interval result = new Interval()
                { Freq = 1, FreqMax = 1, Period = 1, PeriodMax = 1, PeriodUnit = PeriodEnum.Month, ExpressAsPer = false, Inferred = false };

            // on any day in that month, the maximum daily frequency is 1 day
            result.MaximumDailyFrequency.Should().Be(1);
        }

        [TestMethod]
        public void MaxiumDailyFrequencyForYear()
        {
            Interval result = new Interval()
                { Freq = 1, FreqMax = 1, Period = 1, PeriodMax = 1, PeriodUnit = PeriodEnum.Year, ExpressAsPer = false, Inferred = false };

            // on any day in that year, the maximum daily frequency is 1 day
            result.MaximumDailyFrequency.Should().Be(1);
        }

        [TestMethod]
        public void MaxiumDailyFrequencyForFrequencyWithNoPeriodReturnsZero()
        {
            Interval result = new Interval()
                { Freq = 1, FreqMax = 1, Period = 0, PeriodMax = 0, PeriodUnit = PeriodEnum.Hour, ExpressAsPer = false, Inferred = false };
            result.MaximumDailyFrequency.Should().Be(0);
        }

        [TestMethod]
        public void MaxiumDailyFrequencyForFrequencyWithNoPeriodUnitReturnsZero()
        {
            Interval result = new Interval()
                { Freq = 1, FreqMax = 1, Period = 0, PeriodMax = 0, ExpressAsPer = false, Inferred = false };
            result.MaximumDailyFrequency.Should().Be(0);
        }

    }
}
