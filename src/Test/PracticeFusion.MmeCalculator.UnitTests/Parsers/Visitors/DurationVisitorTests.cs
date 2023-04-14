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
    public class DurationVisitorTests
    {
        private readonly CoreParserTestHelper<DurationVisitor, DefaultParser.DurationContext, Duration> _helper = new();

        private static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[] { "for 10 day supply", "for 10 days" },
                new object[] { "this is a 10 month supply", "for 10 months" },
                new object[] { "must last for 10 minutes", "for 10 minutes" },
                new object[] { "x10 hours", "for 10 hours" },
                new object[] { "for 2 weeks", "for 2 weeks" },
                new object[] { "for 2 wks", "for 2 weeks" },
                new object[] { "for 3 d", "for 3 days" }
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
            DefaultParser.DurationContext tree = _helper.DefaultParser(statement).duration();
            Duration result = _helper.Visitor.VisitRoot(tree);

            result.ToString().Should().Be(expected);
            result.Index.Should().Be(0);
            result.Length.Should().Be(statement.Length);
        }
    }
}