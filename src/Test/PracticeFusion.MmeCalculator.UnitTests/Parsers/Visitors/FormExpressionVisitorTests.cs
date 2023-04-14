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
    public class FormExpressionVisitorTests
    {
        private readonly CoreParserTestHelper<FormExpressionVisitor, DefaultParser.FormExpressionContext, Form>
            _helper =
                new();

        private static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[] { "application", "application" },
                new object[] { "capsule", "capsule" },
                new object[] { "dose", "dose" },
                new object[] { "drop", "drop" },
                new object[] { "elixir", "elixir" },
                new object[] { "film", "film" },
                new object[] { "liquid", "liquid" },
                new object[] { "lozenge", "lozenge" },
                new object[] { "patch", "patch" },
                new object[] { "pill", "pill" },
                new object[] { "puff", "puff" },
                new object[] { "solution", "solution" },
                new object[] { "suppository", "suppository" },
                new object[] { "suspension", "suspension" },
                new object[] { "syringe", "syringe" },
                new object[] { "syrup", "syrup" },
                new object[] { "spray", "spray" },
                new object[] { "injection", "injection" },
                new object[] { "injectable solution", "injectable solution" },
                new object[] { "tablet", "tablet" },
                new object[] { "troche", "troche" },
                new object[] { "buccal", "buccal" },
                new object[] { "oral tablet", "oral tablet" },
                new object[] { "nasal spray", "nasal spray" },
                new object[] { "sublingual tablet", "sublingual tablet" },
                new object[] { "transdermal patch", "transdermal patch" },
                new object[] { "tabs", "tablet" },
                new object[] { "caps", "capsule" },
                new object[] { "lozenge on a handle", "lozenge" },
                new object[] { "cartridges", "cartridge" }
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
            DefaultParser.TestFormExpressionContext tree = _helper.DefaultParser(statement).testFormExpression();
            Form result = _helper.Visitor.VisitAllRoot(tree.formExpression());

            result.ToString().Should().Be(expected);
        }
    }
}