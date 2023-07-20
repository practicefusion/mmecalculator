using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Messages;
using PracticeFusion.MmeCalculator.Core.Parsers;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;
using PracticeFusion.MmeCalculator.Core.Parsers.Visitors;
using System.Collections.Generic;
using System.Reflection;

namespace PracticeFusion.MmeCalculator.UnitTests.Parsers.Visitors
{
    [TestClass]
    public class StrictDosageVisitorTests
    {
        private readonly CoreParserTestHelper<StrictDosageVisitor, DefaultParser.StrictDosageContext, Dosage> _helper =
            new();


        private static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
            };

        [TestMethod]
        public void NullContextShouldThrowParseException()
        {
            _helper.NullContextShouldThrowParseException();
        }

        [TestMethod]
        public void StrictDosageRequiresDoseDeliveryMethod()
        {
            var expectedRules = new List<string> { "dosageSeparator", "doseDeliveryMethod" };
            this.Invoking(x => x.ThrowParserErrors("1 tablet every 4-6 hours")).Should()
                .Throw<ParsingSyntaxException>().And.AllSyntaxErrors[0].Item3.Should().Contain(expectedRules);
        }

        [TestMethod]
        public void StrictDosageRequiresDose()
        {
            var expectedRules = new List<string> { "doseVal", "rangeNumericValueWithUOM" };
            this.Invoking(x => x.ThrowParserErrors("take every 4-6 hours")).Should()
                .Throw<ParsingSyntaxException>().And.AllSyntaxErrors[0].Item3.Should().Contain(expectedRules);
        }

        //[DataTestMethod]
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

        private void ThrowParserErrors(string statement)
        {
            List<(ConfidenceEnum Confidence, string ConfidenceReason, List<string>)> parseErrors;
            DefaultParser.StrictDosageContext tree = _helper.DefaultParserWithParseErrors(statement, out parseErrors)
                .strictDosage();
            _helper.ThrowParserErrors(_helper.Parser, tree, parseErrors);
        }

        private void VisitTest(string statement, string expected)
        {
            DefaultParser.StrictDosageContext tree = _helper.DefaultParser(statement).strictDosage();
            Dosage result = _helper.Visitor.VisitRoot(tree);

            result.ToString().Should().Be(expected);
            result.Index.Should().Be(0);
        }
    }
}