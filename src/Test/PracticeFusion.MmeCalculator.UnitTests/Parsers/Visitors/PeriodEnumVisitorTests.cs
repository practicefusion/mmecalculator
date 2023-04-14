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
    public class PeriodEnumVisitorTests
    {
        private readonly CoreParserTestHelper<PeriodEnumVisitor, DefaultParser.PeriodEnumContext, PeriodEnum> _helper =
            new();

        private static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[] { "ms", "millisecond" },
                new object[] { "s", "second" },
                new object[] { "secs", "second" },
                new object[] { "m", "minute" },
                new object[] { "mins", "minute" },
                new object[] { "h", "hour" },
                new object[] { "hr", "hour" },
                new object[] { "hrs", "hour" },
                new object[] { "d", "day" },
                new object[] { "dys", "day" },
                new object[] { "w", "week" },
                new object[] { "wks", "week" },
                new object[] { "months", "month" },
                new object[] { "y", "year" },
                new object[] { "yrs", "year" },
                new object[] { "years", "year" }
            };

        [TestMethod]
        public void NullContextShouldThrowParseException()
        {
            _helper.NullContextShouldThrowParseException();
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
            DefaultParser.PeriodEnumContext tree = _helper.DefaultParser(statement).periodEnum();
            PeriodEnum result = _helper.Visitor.VisitRoot(tree);

            result.ToString().ToLowerInvariant().Should().Be(expected);
        }
    }
}