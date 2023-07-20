using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;
using PracticeFusion.MmeCalculator.Core.Parsers.Visitors;
using System.Collections.Generic;
using System.Reflection;

namespace PracticeFusion.MmeCalculator.UnitTests.Parsers.Visitors
{
    [TestClass]
    public class IndicationForUseVisitorTests
    {
        private readonly CoreParserTestHelper<IndicationForUseVisitor, DefaultParser.IndicationForUseContext,
            IndicationForUse> _helper =
            new();

        private static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[] { "as needed", "as needed" },
                new object[] { "prn", "as needed" },
                new object[] { "prn pain", "as needed for pain" },
                new object[] { "as needed for chest pain", "as needed for chest pain" },
                new object[] { "prn sleep", "as needed for sleep" },
                new object[] { "prn severe cough", "as needed for severe cough" }
            };

        [TestMethod]
        public void NullContextShouldThrowParseException()
        {
            _helper.NullContextShouldThrowParseException();
        }

        [TestMethod]
        public void WhenThePrecursorIsForThenForShouldNotBeAddedToTheIndication()
        {
            IndicationForUse result = ParseStatement("for pain");
            result.IndicationPrecursor.Should().Be("for");
            result.Indication.Should().Be("pain");
            result.HumanReadable.Should().Be("for pain");
        }

        [TestMethod]
        public void ShouldSetContainsLatinAbbreviationsWhenLatinIsPresent()
        {
            IndicationForUse result = ParseStatement("prn pain");
            result.ContainsLatinAbbreviations.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldNotSetContainsLatinAbbreviationsWhenLatinIsAbsent()
        {
            IndicationForUse result = ParseStatement("as needed for pain");
            result.ContainsLatinAbbreviations.Should().BeFalse();
        }

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

        private void VisitTest(string statement, string expected)
        {
            DefaultParser.IndicationForUseContext tree = _helper.DefaultParser(statement).indicationForUse();
            IndicationForUse result = _helper.Visitor.VisitRoot(tree);

            result.ToString().Should().Be(expected);
            result.Index.Should().Be(0);
            result.Length.Should().Be(statement.Length);
        }


        private IndicationForUse ParseStatement(string statement)
        {
            DefaultParser.TestIndicationForUseContext tree = _helper.DefaultParser(statement).testIndicationForUse();
            IndicationForUse result = _helper.Visitor.VisitAllRoot(tree.indicationForUse());
            return result;
        }
    }
}