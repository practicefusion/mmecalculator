using System.Collections.Generic;
using System.Reflection;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeFusion.MmeCalculator.Core.Messages;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;
using PracticeFusion.MmeCalculator.Core.Parsers.Visitors;

namespace PracticeFusion.MmeCalculator.UnitTests.Parsers.Visitors
{
    [TestClass]
    public class MedicationVisitorTests
    {
        private readonly CoreParserTestHelper<MedicationVisitor, DefaultParser.MedicationContext, ParsedMedication> _helper =
            new();

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
                    "acetaminophen 325 mg / oxycodone hydrochloride 5 mg oral tablet [percocet]", new[] {"acetaminophen 325 mg", "oxycodone 5 mg"},
                    "oral tablet"
                },
                new object[] { "methadone hydrochloride 2 mg/ml oral solution", new[] {"methadone 2 mg/ml"}, "oral solution" },
            };

        [DataTestMethod]
        [DynamicData(nameof(TestData), DynamicDataDisplayName = "DisplayName")]
        public void BasicTests(string statement, string[] expectedComponents, string expectedForm)
        {
            VisitTest(statement, expectedComponents, expectedForm);
        }

        public static string DisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null)
            {
                return $"{methodInfo.Name} ({data[0]} : {data[1]})";
            }

            return null;
        }

        private void VisitTest(string statement, string[] expectedComponents, string expectedForm)
        {
            var tree = _helper.DefaultParser(statement).medication();
            var result = _helper.Visitor.VisitRoot(tree);

            result.MedicationComponents.Should().HaveCount(expectedComponents.Length);

            for (int i = 0; i < result.MedicationComponents.Count; i++)
            {
                result.MedicationComponents[i].ToString().Should().Be(expectedComponents[i]);

                if (expectedForm != null)
                {
                    result.MedicationComponents[i].Form.ToString().Should().Be(expectedForm);
                }
                else
                {
                    result.MedicationComponents[i].Form.Should().BeNull();
                }
            }
        }
    }
}
