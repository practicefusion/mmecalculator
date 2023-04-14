using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;
using PracticeFusion.MmeCalculator.Core.Parsers.Visitors;
using System.Collections.Generic;
using System.Reflection;

namespace PracticeFusion.MmeCalculator.UnitTests.Parsers.Visitors
{
    [TestClass]
    public class DosageSeparatorVisitorTests
    {
        private readonly CoreParserTestHelper<DosageSeparatorVisitor, DefaultParser.DosageSeparatorContext, string>
            _helper =
                new();

        private static IEnumerable<object[]> TestData =>
            new List<object[]> { new object[] { "then", "then" }, new object[] { "and then", "and then" } };

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
            DefaultParser.DosageSeparatorContext tree = _helper.DefaultParser(statement).dosageSeparator();
            var result = _helper.Visitor.VisitRoot(tree);
            result.Should().Be(expected);
        }
    }
}