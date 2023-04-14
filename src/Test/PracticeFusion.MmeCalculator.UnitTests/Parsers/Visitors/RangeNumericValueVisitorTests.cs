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
    public class RangeNumericValueVisitorTests
    {
        private readonly CoreParserTestHelper<RangeNumericValueVisitor, DefaultParser.RangeNumericValueContext,
                Tuple<decimal, decimal>>
            _helper = new();

        private static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[] { "1 - 2", 1m, 2m },
                new object[] { "1 to 2", 1m, 2m },
                new object[] { "1.5 to 2.5", 1.5m, 2.5m }
            };

        [TestMethod]
        public void NullContextShouldThrowParseException()
        {
            _helper.NullContextShouldThrowParseException();
        }

        [DataTestMethod]
        [DynamicData(nameof(TestData), DynamicDataDisplayName = "DisplayName")]
        public void RoundTripTests(string statement, decimal min, decimal max)
        {
            VisitTest(statement, min, max);
        }

        public static string DisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null)
            {
                return $"{methodInfo.Name} ({data[0]} : {data[1]})";
            }

            return null;
        }

        private void VisitTest(string statement, decimal min, decimal max)
        {
            DefaultParser.RangeNumericValueContext tree = _helper.DefaultParser(statement).rangeNumericValue();
            Tuple<decimal, decimal> result = _helper.Visitor.VisitRoot(tree);

            result.Item1.Should().Be(min);
            result.Item2.Should().Be(max);
        }
    }
}