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
    public class DoseVisitorTests
    {
        private readonly CoreParserTestHelper<DoseVisitor, DefaultParser.DoseContext, Dose> _helper = new();

        [TestMethod]
        public void NullContextShouldThrowParseException()
        {
            _helper.NullContextShouldThrowParseException();
        }

        private static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[]
                {
                    "1 mg",
                    "1 mg"
                },
                new object[]
                {
                    "1 - 2 mg",
                    "1-2 mg"
                },
                new object[]
                {
                    "1 - 2 mg (1 - 2 ml)",
                    "1-2 mg (1-2 ml)"
                },
                new object[]
                {
                    "1 mg - 2 mg (1 ml - 2 ml)",
                    "1-2 mg (1-2 ml)"
                },
                new object[]
                {
                    "1 mg (1 ml)",
                    "1 mg (1 ml)"
                },
                new object[] { "1 tablets", "1 tablet" },
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
            var tree = _helper.DefaultParser(statement).dose();
            var result = _helper.Visitor.VisitRoot(tree);

            result.ToString().Should().Be(expected);
            result.Index.Should().Be(0);
            result.Length.Should().Be(statement.Length);
        }
    }
}
