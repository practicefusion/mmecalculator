using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeFusion.MmeCalculator.Core.Parsers.Visitors;
using FluentAssertions;
using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Parsers;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;
using PracticeFusion.MmeCalculator.Core.Services;

namespace PracticeFusion.MmeCalculator.UnitTests.Parsers.Visitors
{
    [TestClass]
    public class LatinAdministrationTimingVisitorTests
    {
        private readonly CoreParserTestHelper<LatinAdministrationTimingVisitor, DefaultParser.LatinAdministrationTimingContext, Frequency>
            _helper = new();

        [TestMethod]
        public void NullContextShouldThrowParseException()
        {
            _helper.NullContextShouldThrowParseException();
        }

        [TestMethod]
        public void EveryHS()
        {
            var frequency = new Frequency();
            var context = _helper.DefaultParser("every hs").latinAdministrationTiming();
            _helper.Visitor.VisitRoot(context, frequency);
            frequency.When.Should().HaveCount(1).And.Contain(EventTimingEnum.BedTime);
        }

        [TestMethod]
        public void EveryAC()
        {
            var frequency = new Frequency();
            var context = _helper.DefaultParser("qac").latinAdministrationTiming();
            _helper.Visitor.VisitRoot(context, frequency);
            frequency.When.Should().HaveCount(1).And.Contain(EventTimingEnum.BeforeEveryMeal);
        }

        [TestMethod]
        public void EveryPC()
        {
            var frequency = new Frequency();
            var context = _helper.DefaultParser("qpc").latinAdministrationTiming();
            _helper.Visitor.VisitRoot(context, frequency);
            frequency.When.Should().HaveCount(1).And.Contain(EventTimingEnum.AfterEveryMeal);
        }

        [TestMethod]
        public void EveryQAC()
        {
            var frequency = new Frequency();
            var context = _helper.DefaultParser("every ac").latinAdministrationTiming();
            _helper.Visitor.Invoking(x => x.VisitRoot(context, frequency)).Should().ThrowExactly<ParsingException>()
                .WithMessage($"Expected administration timing, but cannot parse 'every ac'");
        }

        [TestMethod]
        public void ShouldSetContainsLatinAbbreviationsWhenLatinIsPresent()
        {
            var frequency = new Frequency();
            var context = _helper.DefaultParser("qac").latinAdministrationTiming();
            _helper.Visitor.VisitRoot(context, frequency);
            frequency.ContainsLatinAbbreviations.Should().BeTrue();
        }
    }
}