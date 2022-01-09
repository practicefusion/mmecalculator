using System.Collections.Generic;
using System.Reflection;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeFusion.MmeCalculator.Core.Parsers;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;
using PracticeFusion.MmeCalculator.Core.Parsers.Visitors;
using PracticeFusion.MmeCalculator.Core.Services;

namespace PracticeFusion.MmeCalculator.UnitTests.Parsers.Visitors
{
    [TestClass]
    public class NumericValueVisitorTests
    {
        private readonly CoreParserTestHelper<NumericValueVisitor, DefaultParser.NumericValueContext, decimal> _helper =
            new();

        [TestMethod]
        public void NullContextShouldThrowParseException()
        {
            _helper.NullContextShouldThrowParseException();
        }

        [TestMethod]
        public void DoesNotYetParseOneQuarterAsAFraction()
        {
            var tree = _helper.DefaultParser("1/4").numericValue();
            _helper.Visitor.Invoking(x => x.VisitRoot(tree)).Should().
                Throw<ParsingException>().WithMessage("Expected a numeric value").
                WithInnerException<ParsingException>().WithMessage("Failed to parse 1/4 as a valid number.");
        }

        [DataTestMethod]
        [DataRow("1,5")]
        [DataRow("1,50")]
        [DataRow("10,50")]
        [DataRow("1,5000")]
        [DataRow("1000,500")]
        public void NumbersWithCommasInUnexpectedPositionsThrowExceptions(string statement)
        {
            var tree = _helper.DefaultParser(statement).numericValue();
            _helper.Visitor.Invoking(x => x.VisitRoot(tree)).Should().Throw<ParsingException>().WithMessage("Expected a numeric value");
        }

        [DataTestMethod]
        [DataRow("1,500", 1500)]
        [DataRow("10,500", 10500)]
        [DataRow("100,500", 100500)]
        [DataRow("1,000,500", 1000500)]
        public void NumbersWithCommasInExpectedPositionsParseCorrectly(string statement, int expected)
        {
            var tree = _helper.DefaultParser(statement).numericValue();
            var result = _helper.Visitor.VisitRoot(tree);
            result.Should().Be(expected);
        }

        private static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[] { "1.5", 1.5m },
                new object[] { "1.0", 1m },
                new object[] { "6 hours", 6m },
                new object[] { "3.5 hours", 3.5m },
                new object[] { "50,000 ius", 50000m },
                new object[] { "50,000ius", 50000m },
                new object[] { ".5", 0.5m },

                new object[] { "one", 1m },
                new object[] { "two", 2m },
                new object[] { "three", 3m },
                new object[] { "four", 4m },
                new object[] { "five", 5m },
                new object[] { "six", 6m },
                new object[] { "seven", 7m },
                new object[] { "eight", 8m },
                new object[] { "nine", 9m },
                new object[] { "ten", 10m },
                new object[] { "twelve", 12m },

                new object[] { "one and one half", 1.5m },
                new object[] { "two and a half", 2.5m },
                new object[] { "twenty four", 24m },
                new object[] { "thirty six", 36m },
                new object[] { "forty eight", 48m },
                new object[] { "seventy two", 72m },
            };

        [DataTestMethod]
        [DynamicData(nameof(TestData), DynamicDataDisplayName = "DisplayName")]
        public void RoundTripTests(string statement, decimal expected)
        {
            VisitTest(statement, expected);
            VisitTest(expected.ToString(), expected);
        }

        public static string DisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null)
            {
                return $"{methodInfo.Name} ({data[0]} : {data[1]})";
            }

            return null;
        }

        private void VisitTest(string statement, decimal expected)
        {

            var tree = _helper.DefaultParser(statement).numericValue();
            var result = _helper.Visitor.VisitRoot(tree);

            result.Should().Be(expected);
        }
    }
}
