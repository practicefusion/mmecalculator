using System.Collections.Generic;
using System.Reflection;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;
using PracticeFusion.MmeCalculator.Core.Parsers.Visitors;

namespace PracticeFusion.MmeCalculator.UnitTests.Parsers.Visitors
{
    [TestClass]
    public class RouteEnumVisitorTests
    {
        private readonly CoreParserTestHelper<RouteEnumVisitor, DefaultParser.RouteEnumContext, RouteEnum> _helper =
            new();

        [TestMethod]
        public void NullContextShouldThrowParseException()
        {
            _helper.NullContextShouldThrowParseException();
        }

        [TestMethod]
        public void ShouldSetContainsLatinAbbreviationsWhenLatinIsPresent()
        {
            var context = _helper.DefaultParser("po").routeEnum();
            RouteEnumVisitor.ContainsLatinAbbreviations(context).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldNotSetContainsLatinAbbreviationsWhenLatinIsAbsent()
        {
            var context = _helper.DefaultParser("orally").routeEnum();
            RouteEnumVisitor.ContainsLatinAbbreviations(context).Should().BeFalse();
        }

        private static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[] { "mouth", RouteEnum.Orally },
                new object[] { "orally", RouteEnum.Orally },
                new object[] { "po", RouteEnum.Orally },
                new object[] { "under the tongue", RouteEnum.Sublingually },
                new object[] { "sl", RouteEnum.Sublingually },
                new object[] { "sublingually", RouteEnum.Sublingually },
                new object[] { "feeding tube", RouteEnum.FeedingTube },
                new object[] { "gastrostomy tube", RouteEnum.FeedingTube },
                new object[] { "nasally", RouteEnum.Nasally },
                new object[] { "rectal", RouteEnum.Rectal },
                new object[] { "topical", RouteEnum.Topically },
                new object[] { "transdermally", RouteEnum.Transdermally },
                new object[] { "intranasally", RouteEnum.Intranasally },
                new object[] { "per nostril", RouteEnum.PerNostril },
                new object[] { "to skin", RouteEnum.Transdermally },
            };

        [DataTestMethod]
        [DynamicData(nameof(TestData), DynamicDataDisplayName = "DisplayName")]
        public void BasicTests(string statement, RouteEnum expected)
        {
            VisitTest(statement, expected);
        }

        public static string DisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null)
            {
                return $"{methodInfo.Name} ({data[0]} : {data[1]})";
            }

            return null;
        }

        private void VisitTest(string statement, RouteEnum expected)
        {
            var tree = _helper.DefaultParser(statement).routeEnum();
            var result = _helper.Visitor.VisitRoot(tree);

            result.Should().Be(expected);
        }
    }
}
