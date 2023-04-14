using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Parsers;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;
using PracticeFusion.MmeCalculator.Core.Parsers.Visitors;

namespace PracticeFusion.MmeCalculator.UnitTests.Parsers.Visitors
{
    [TestClass]
    public class SpecialFrequencyVisitorTests
    {
        private readonly CoreParserTestHelper<SpecialFrequencyVisitor, DefaultParser.SpecialFrequencyContext, Frequency>
            _helper =
                new();

        [TestMethod]
        public void NullContextShouldThrowParseException()
        {
            _helper.NullContextShouldThrowParseException();
        }

        [TestMethod]
        public void SpecialFrequenciesOtherThanEvery4Hours5TimesADayThrowException()
        {
            var shouldFail = "every 5 hours (6 times/day)";
            DefaultParser.SpecialFrequencyContext context = _helper.DefaultParser(shouldFail).specialFrequency();
            _helper.Visitor.Invoking(x => x.VisitRoot(context, new Frequency())).Should()
                .ThrowExactly<ParsingException>().WithMessage($"Cannot parse the special frequency '{shouldFail}'");
        }
    }
}