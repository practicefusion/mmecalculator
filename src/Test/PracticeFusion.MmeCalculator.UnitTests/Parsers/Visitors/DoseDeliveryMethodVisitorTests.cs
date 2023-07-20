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
    public class DoseDeliveryMethodVisitorTests
    {
        private readonly CoreParserTestHelper<DoseDeliveryMethodVisitor, DefaultParser.DoseDeliveryMethodContext,
                DoseDeliveryMethod>
            _helper = new();

        private static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[] { "administer", "administer" },
                new object[] { "apply", "apply" },
                new object[] { "chew", "chew" },
                new object[] { "chew and swallow", "chew and swallow" },
                new object[] { "dissolve", "dissolve" },
                new object[] { "give", "give" },
                new object[] { "infuse", "infuse" },
                new object[] { "inhale", "inhale" },
                new object[] { "inject", "inject" },
                new object[] { "insert", "insert" },
                new object[] { "place", "place" },
                new object[] { "suck", "suck" },
                new object[] { "take", "take" },
                new object[] { "use", "use" }
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
            DefaultParser.DoseDeliveryMethodContext tree = _helper.DefaultParser(statement).doseDeliveryMethod();
            DoseDeliveryMethod result = _helper.Visitor.VisitRoot(tree);

            result.ToString().Should().Be(expected);
            result.Index.Should().Be(0);
            result.Length.Should().Be(statement.Length);
        }
    }
}