using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;
using PracticeFusion.MmeCalculator.Core.Parsers.Visitors;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace PracticeFusion.MmeCalculator.UnitTests.Parsers.Visitors
{
    [TestClass]
    public class DayOfTheWeekVisitorTests
    {
        private readonly CoreParserTestHelper<DayOfTheWeekVisitor, DefaultParser.DayOfTheWeekContext, DayOfWeek>
            _helper =
                new();

        private static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[] { "monday", "Monday" },
                new object[] { "tuesday", "Tuesday" },
                new object[] { "wednesday", "Wednesday" },
                new object[] { "thursday", "Thursday" },
                new object[] { "friday", "Friday" },
                new object[] { "saturday", "Saturday" },
                new object[] { "sunday", "Sunday" }
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
            DefaultParser.DayOfTheWeekContext tree = _helper.DefaultParser(statement).dayOfTheWeek();
            DayOfWeek result = _helper.Visitor.VisitRoot(tree);

            result.ToString().Should().Be(expected);
        }
    }
}