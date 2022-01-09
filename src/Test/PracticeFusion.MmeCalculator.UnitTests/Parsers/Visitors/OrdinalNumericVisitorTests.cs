using System.Collections.Generic;
using System.Reflection;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;
using PracticeFusion.MmeCalculator.Core.Parsers.Visitors;

namespace PracticeFusion.MmeCalculator.UnitTests.Parsers.Visitors
{
    [TestClass]
    public class OrdinalNumericVisitorTests
    {
        private readonly CoreParserTestHelper<OrdinalNumericVisitor, DefaultParser.OrdinalNumericContext, decimal> _helper =
            new();

        [TestMethod]
        public void NullContextShouldThrowParseException()
        {
            _helper.NullContextShouldThrowParseException();
        }

        private static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[] { "first", 1m },
                new object[] { "second", 2m },
                new object[] { "third", 3m },
                new object[] { "fourth", 4m },
                new object[] { "fifth", 5m },
                new object[] { "sixth", 6m },
                new object[] { "seventh", 7m },
            };

        [DataTestMethod]
        [DynamicData(nameof(TestData), DynamicDataDisplayName = "DisplayName")]
        public void BasicTests(string statement, decimal expected)
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

        private void VisitTest(string statement, decimal expected)
        {
            var tree = _helper.DefaultParser(statement).ordinalNumeric();
            var result = _helper.Visitor.VisitRoot(tree);

            result.Should().Be(expected);
        }
    }
}
