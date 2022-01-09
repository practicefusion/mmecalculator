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
    public class PeriodlyVisitorTests
    {
        private readonly CoreParserTestHelper<PeriodlyVisitor, DefaultParser.PeriodlyContext, PeriodEnum> _helper =
            new();

        [TestMethod]
        public void NullContextShouldThrowParseException()
        {
            _helper.NullContextShouldThrowParseException();
        }

        private static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[] { "hourly", "hour" },
                new object[] { "daily", "day" },
                new object[] { "weekly", "week" },
                new object[] { "monthly", "month" },
                new object[] { "yearly", "year" },
                new object[] { "annually", "year" },
            };

        [DataTestMethod]
        [DynamicData(nameof(TestData), DynamicDataDisplayName = "DisplayName")]
        public void BasicTests(string statement, string expected)
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

        private void VisitTest(string statement, string expected)
        {
            var tree = _helper.DefaultParser(statement).periodly();
            var result = _helper.Visitor.VisitRoot(tree);

            result.ToString().ToLowerInvariant().Should().Be(expected);
        }
    }
}
