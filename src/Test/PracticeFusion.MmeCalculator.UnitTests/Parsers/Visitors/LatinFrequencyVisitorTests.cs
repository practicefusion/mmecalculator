using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;
using PracticeFusion.MmeCalculator.Core.Parsers.Visitors;

namespace PracticeFusion.MmeCalculator.UnitTests.Parsers.Visitors
{
    [TestClass()]
    public class LatinFrequencyVisitorTests
    {
        private readonly CoreParserTestHelper<LatinFrequencyVisitor, DefaultParser.LatinFrequencyContext, Frequency>
            _helper = new();

        [TestMethod]
        public void NullContextShouldThrowParseException()
        {
            _helper.NullContextShouldThrowParseException();
        }

        [TestMethod]
        public void QD()
        {
            var frequency = new Frequency();
            var context = _helper.DefaultParser("qd").latinFrequency();
            _helper.Visitor.VisitRoot(context, frequency);
            frequency.Intervals.Should().HaveCount(1);
            var expected = new Interval()
                { Index = 0, Length = 2, Freq = 1, FreqMax = 1, Period = 1, PeriodMax = 1, PeriodUnit = PeriodEnum.Day, ContainsLatinAbbreviations = true};
            frequency.Intervals[0].Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void QHS()
        {
            var frequency = new Frequency();
            var context = _helper.DefaultParser("qhs").latinFrequency();
            _helper.Visitor.VisitRoot(context, frequency);
            frequency.Intervals.Should().HaveCount(1);
            var expected = new Interval()
                { Index = 0, Length = 3, Freq = 1, FreqMax = 1, Period = 1, PeriodMax = 1, PeriodUnit = PeriodEnum.Day, ContainsLatinAbbreviations = true };
            frequency.Intervals[0].Should().BeEquivalentTo(expected);
            frequency.When.Should().HaveCount(1);
            frequency.When.Should().Contain(EventTimingEnum.BedTime);
        }

        [TestMethod]
        public void QOD()
        {
            var frequency = new Frequency();
            var context = _helper.DefaultParser("qod").latinFrequency();
            _helper.Visitor.VisitRoot(context, frequency);
            frequency.Intervals.Should().HaveCount(1);
            var expected = new Interval()
                { Index = 0, Length = 3, Freq = 1, FreqMax = 1, Period = 2, PeriodMax = 2, PeriodUnit = PeriodEnum.Day, ContainsLatinAbbreviations = true };
            frequency.Intervals[0].Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void BID()
        {
            var frequency = new Frequency();
            var context = _helper.DefaultParser("bid").latinFrequency();
            _helper.Visitor.VisitRoot(context, frequency);
            frequency.Intervals.Should().HaveCount(1);
            var expected = new Interval()
                { Index = 0, Length = 3, Freq = 2, FreqMax = 2, Period = 1, PeriodMax = 1, PeriodUnit = PeriodEnum.Day, ContainsLatinAbbreviations = true };
            frequency.Intervals[0].Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void TID()
        {
            var frequency = new Frequency();
            var context = _helper.DefaultParser("tid").latinFrequency();
            _helper.Visitor.VisitRoot(context, frequency);
            frequency.Intervals.Should().HaveCount(1);
            var expected = new Interval()
                { Index = 0, Length = 3, Freq = 3, FreqMax = 3, Period = 1, PeriodMax = 1, PeriodUnit = PeriodEnum.Day, ContainsLatinAbbreviations = true };
            frequency.Intervals[0].Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void QID()
        {
            var frequency = new Frequency();
            var context = _helper.DefaultParser("qid").latinFrequency();
            _helper.Visitor.VisitRoot(context, frequency);
            frequency.Intervals.Should().HaveCount(1);
            var expected = new Interval()
                { Index = 0, Length = 3, Freq = 4, FreqMax = 4, Period = 1, PeriodMax = 1, PeriodUnit = PeriodEnum.Day, ContainsLatinAbbreviations = true };
            frequency.Intervals[0].Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void QPM()
        {
            var frequency = new Frequency();
            var context = _helper.DefaultParser("qpm").latinFrequency();
            _helper.Visitor.VisitRoot(context, frequency);
            frequency.Intervals.Should().HaveCount(1);
            var expected = new Interval()
                { Index = 0, Length = 3, Freq = 1, FreqMax = 1, Period = 1, PeriodMax = 1, PeriodUnit = PeriodEnum.Day, ContainsLatinAbbreviations = true };
            frequency.Intervals[0].Should().BeEquivalentTo(expected);
            frequency.When.Should().HaveCount(1);
            frequency.When.Should().Contain(EventTimingEnum.AfterNoon);
        }

        [TestMethod]
        public void QN()
        {
            var frequency = new Frequency();
            var context = _helper.DefaultParser("qn").latinFrequency();
            _helper.Visitor.VisitRoot(context, frequency);
            frequency.Intervals.Should().HaveCount(1);
            var expected = new Interval()
                { Index = 0, Length = 2, Freq = 1, FreqMax = 1, Period = 1, PeriodMax = 1, PeriodUnit = PeriodEnum.Day, ContainsLatinAbbreviations = true };
            frequency.Intervals[0].Should().BeEquivalentTo(expected);
            frequency.When.Should().HaveCount(1);
            frequency.When.Should().Contain(EventTimingEnum.Night);
        }

        [TestMethod]
        public void ShouldSetContainsLatinAbbreviationsWhenLatinIsPresent()
        {
            var frequency = new Frequency();
            var context = _helper.DefaultParser("qn").latinFrequency();
            _helper.Visitor.VisitRoot(context, frequency);
            frequency.ContainsLatinAbbreviations.Should().BeTrue();
        }
    }
}