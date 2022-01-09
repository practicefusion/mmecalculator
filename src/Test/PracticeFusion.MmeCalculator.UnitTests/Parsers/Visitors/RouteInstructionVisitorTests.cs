using System.Collections.Generic;
using System.Reflection;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;
using PracticeFusion.MmeCalculator.Core.Parsers.Visitors;

namespace PracticeFusion.MmeCalculator.UnitTests.Parsers.Visitors
{
    [TestClass]
    public class RouteInstructionVisitorTests
    {
        private readonly CoreParserTestHelper<RouteInstructionVisitor, DefaultParser.RouteInstructionContext, string> _helper =
            new();

        [TestMethod]
        public void NullContextShouldThrowParseException()
        {
            _helper.NullContextShouldThrowParseException();
        }

        private static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[] { "inhaled by", "inhaled by" },
                new object[] { "inhaled via", "inhaled via" },
                new object[] { "inhaled per", "inhaled per" },
                new object[] { "by", "by" },
                new object[] { "via", "via" },
                new object[] { "per", "per" },
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

        private void VisitTest(string statement, string expected)
        {
            var tree = _helper.DefaultParser(statement).routeInstruction();
            var result = _helper.Visitor.VisitRoot(tree);

            result.ToString().Should().Be(expected);
        }
    }
}
