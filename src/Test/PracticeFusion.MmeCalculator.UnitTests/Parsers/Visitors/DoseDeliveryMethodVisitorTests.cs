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
    public class DoseDeliveryMethodVisitorTests
    {
        private readonly CoreParserTestHelper<DoseDeliveryMethodVisitor, DefaultParser.DoseDeliveryMethodContext, DoseDeliveryMethod>
            _helper = new();

        [TestMethod]
        public void NullContextShouldThrowParseException()
        {
            _helper.NullContextShouldThrowParseException();
        }

        private static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[] { "administer", "administer" },
                new object[] { "apply", "apply" },
                new object[] { "dissolve", "dissolve" },
                new object[] { "give", "give" },
                new object[] { "infuse", "infuse" },
                new object[] { "inhale", "inhale" },
                new object[] { "inject", "inject" },
                new object[] { "insert", "insert" },
                new object[] { "place", "place" },
                new object[] { "suck", "suck" },
                new object[] { "take", "take" },
                new object[] { "use", "use" },
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
            var tree = _helper.DefaultParser(statement).doseDeliveryMethod();
            var result = _helper.Visitor.VisitRoot(tree);

            result.ToString().Should().Be(expected);
            result.Index.Should().Be(0);
            result.Length.Should().Be(statement.Length);
        }
    }
}
