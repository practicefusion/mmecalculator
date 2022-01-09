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
    public class OpioidVisitorTests
    {
        private readonly CoreParserTestHelper<OpioidVisitor, DefaultParser.OpioidContext, Opioid> _helper = new();

        [TestMethod]
        public void NullContextShouldThrowParseException()
        {
            _helper.NullContextShouldThrowParseException();
        }

        private static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[] { "buprenorphine", "buprenorphine" },
                new object[] { "butorphanol", "butorphanol" },
                new object[] { "codeine", "codeine" },
                new object[] { "dihydrocodeine", "dihydrocodeine" },
                new object[] { "fentanyl", "fentanyl" },
                new object[] { "hydrocodone", "hydrocodone" },
                new object[] { "hydromorphone", "hydromorphone" },
                new object[] { "levorphanol", "levorphanol" },
                new object[] { "meperidine", "meperidine" },
                new object[] { "methadone", "methadone" },
                new object[] { "morphine", "morphine" },
                new object[] { "opium", "opium" },
                new object[] { "oxycodone", "oxycodone" },
                new object[] { "oxymorphone", "oxymorphone" },
                new object[] { "pentazocine", "pentazocine" },
                new object[] { "tapentadol", "tapentadol" },
                new object[] { "tramadol", "tramadol" },
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
            var tree = _helper.DefaultParser(statement).opioid();
            var result = _helper.Visitor.VisitRoot(tree);

            result.ToString().Should().Be(expected);
        }
    }
}
