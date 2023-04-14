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
    public class RouteVisitorTests
    {
        private readonly CoreParserTestHelper<RouteVisitor, DefaultParser.RouteContext, Route> _helper = new();

        private static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[] { "inhaled by mouth", "inhaled by mouth" },
                new object[] { "via gastrostomy tube", "via feeding tube" },
                new object[] { "by mouth/under the tongue", "by mouth/sublingually" },
                new object[] { "po/sl", "by mouth/sublingually" },
                new object[] { "po", "by mouth" },
                new object[] { "sl", "sublingually" },
                new object[] { "p.o./sl", "by mouth/sublingually" },
                new object[] { "topically", "topically" },
                new object[] { "inhaled intranasally", "inhaled intranasally" }
            };

        private static IEnumerable<object[]> IndexAndLengthData =>
            new List<object[]> { new object[] { "po", 0, 2 } };

        [TestMethod]
        public void NullContextShouldThrowParseException()
        {
            _helper.NullContextShouldThrowParseException();
        }

        [TestMethod]
        public void ShouldSetContainsLatinAbbreviationsWhenLatinIsPresent()
        {
            DefaultParser.RouteContext[] tree = _helper.DefaultParser("po").testRoute().route();
            Route result = _helper.Visitor.VisitAllRoot(tree);
            result.ContainsLatinAbbreviations.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldNotSetContainsLatinAbbreviationsWhenLatinIsAbsent()
        {
            DefaultParser.RouteContext[] tree = _helper.DefaultParser("by mouth").testRoute().route();
            Route result = _helper.Visitor.VisitAllRoot(tree);
            result.ContainsLatinAbbreviations.Should().BeFalse();
        }

        [DataTestMethod]
        [DynamicData(nameof(TestData), DynamicDataDisplayName = "DisplayName")]
        public void RoundTripTests(string statement, string expected)
        {
            VisitTest(statement, expected);
            VisitTest(expected, expected);
        }

        [DataTestMethod]
        [DynamicData(nameof(IndexAndLengthData), DynamicDataDisplayName = "DisplayName")]
        public void IndexAndLengthTests(string statement, int index, int length)
        {
            DefaultParser.RouteContext[] tree = _helper.DefaultParser(statement).testRoute().route();
            Route result = _helper.Visitor.VisitAllRoot(tree);
            result.Index.Should().Be(index);
            result.Length.Should().Be(length);
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
            DefaultParser.RouteContext[] tree = _helper.DefaultParser(statement).testRoute().route();
            Route result = _helper.Visitor.VisitAllRoot(tree);

            result.ToString().Should().Be(expected);
        }
    }
}