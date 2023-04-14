using System.Collections.Generic;
using System.Reflection;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeFusion.MmeCalculator.Core.Messages;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;
using PracticeFusion.MmeCalculator.Core.Parsers.Visitors;

namespace PracticeFusion.MmeCalculator.UnitTests.Parsers.Visitors
{
    [TestClass]
    public class StrictSigVisitorTests
    {
        private readonly CoreParserTestHelper<StrictSigVisitor, DefaultParser.StrictSigContext, ParsedSig> _helper = new();

        [TestMethod]
        public void ShouldCorrectlyMergeFrequenciesEvenWhenSeparatedInTheOriginalSigWithAnotherRule()
        {
            // this sig has the following rule sequence: 
            // frequency (3 times per day) duration (for 3 days) frequency (after meals)
            var result = ParseStatement("1 tablet by mouth 3 times per day for 3 days after meals");
            result.Dosages.Count.Should().Be(1);
            result.Dosages[0].Frequency.Should().NotBeNull();
            result.Dosages[0].Frequency!.When.Should().Contain(Core.Entities.EventTimingEnum.AfterMeals);
        }

        [TestMethod]
        public void NullContextShouldThrowParseException()
        {
            _helper.NullContextShouldThrowParseException();
        }

        private static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[]
                {
                    "take 1-2 puffs inhaled by mouth daily for 3 days and then take 1 tablet po/sl a day thereafter",
                    "take 1-2 puffs inhaled by mouth every day for 3 days and then take 1 tablet by mouth/sublingually every day thereafter"
                },
                new object[]
                {
                    "take 1 ml each hour",
                    "take 1 ml every hour"
                },
                new object[]
                {
                    "take 1-2 ml each hour",
                    "take 1-2 ml every hour"
                },
                new object[]
                {
                    "take 1ml -2 ml each hour",
                    "take 1-2 ml every hour"
                },
                new object[]
                {
                    "take 1 ml (1mg) each hour",
                    "take 1 ml (1 mg) every hour"
                },
                new object[]
                {
                    "take 1-2 ml (1 - 2mg) each hour",
                    "take 1-2 ml (1-2 mg) every hour"
                },
                new object[]
                {
                    "take 1ml -2 ml (1 mg - 2mg) each hour",
                    "take 1-2 ml (1-2 mg) every hour"
                }
            };

        [DataTestMethod]
        [DynamicData(nameof(TestData), DynamicDataDisplayName = "DisplayName")]
        public void RoundTripTests(string statement, string expected)
        {
            VisitTest(statement, expected);
            VisitTest(expected, expected);
        }

        public static string DisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null)
            {
                return $"{methodInfo.Name} ({data[0]} : {data[1]})";
            }

            return null;
        }

        private ParsedSig ParseStatement(string statement)
        {
            var tree = _helper.DefaultParser(statement).strictSig();
            tree.strictDosage().Should().NotBeNull();
            var result = _helper.Visitor.VisitRoot(tree);
            return result;
        }

        private void VisitTest(string statement, string expected)
        {

            var tree = _helper.DefaultParser(statement).strictSig();
            var result = _helper.Visitor.VisitRoot(tree);

            result.ToString().Should().Be(expected);
        }
    }
}
