using System.Collections.Generic;
using System.Reflection;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Parsers;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;
using PracticeFusion.MmeCalculator.Core.Parsers.Visitors;
using PracticeFusion.MmeCalculator.Core.Services;

namespace PracticeFusion.MmeCalculator.UnitTests.Parsers.Visitors
{
    [TestClass]
    public class AdditionalInstructionVisitorTests
    {
        private readonly
            CoreParserTestHelper<AdditionalInstructionVisitor, DefaultParser.AdditionalInstructionContext, AdditionalInstruction> _helper =
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
                    "with food",
                    "with food"
                },
                new object[]
                {
                    "before food",
                    "before food"
                },
                new object[]
                {
                    "after food",
                    "after food"
                },
                new object[]
                {
                    "with meal",
                    "with meal"
                },
                new object[]
                {
                    "before meals",
                    "before meals"
                },
                new object[]
                {
                    "after meals",
                    "after meals"
                },
                new object[]
                {
                    "with meals",
                    "with meals"
                },
                new object[]
                {
                    "with water",
                    "with water"
                },
                new object[]
                {
                    "with plenty of water",
                    "with plenty of water"
                },
                new object[]
                {
                    "with milk",
                    "with milk"
                },
                new object[]
                {
                    "with plenty of milk",
                    "with plenty of milk"
                },
                new object[]
                {
                    "with liquid",
                    "with liquid"
                },
                new object[]
                {
                    "before eating",
                    "before eating"
                },
                new object[]
                {
                    "after eating",
                    "after eating"
                },
                new object[]
                {
                    "with eating",
                    "with eating"
                },
                new object[]
                {
                    "on an empty stomach",
                    "on an empty stomach"
                },
                new object[]
                {
                    "on a empty stomach",
                    "on a empty stomach"
                },
                new object[]
                {
                    "on empty stomach",
                    "on empty stomach"
                },
            };

        private static IEnumerable<object[]> MultiplesTestData =>
            new List<object[]>
            {
                new object[]
                {
                    "with liquid with food",
                    "with liquid with food"
                },
            };


        [DataTestMethod]
        [DynamicData(nameof(TestData), DynamicDataDisplayName = "DisplayName")]
        public void RoundTripTests(string statement, string expected)
        {
            VisitTest(statement, expected);
            VisitTest(expected, expected);
        }

        [DataTestMethod]
        [DynamicData(nameof(MultiplesTestData), DynamicDataDisplayName = "DisplayName")]
        public void MultiplesTests(string statement, string expected)
        {
            VisitAllRootTest(statement, expected);
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
            var tree = _helper.DefaultParser(statement).additionalInstruction();
            var result = _helper.Visitor.VisitRoot(tree);

            result.ToString().Should().Be(expected);
            result.Index.Should().Be(0);
            result.Length.Should().Be(statement.Length);
        }

        private void VisitAllRootTest(string statement, string expected)
        {
            var tree = _helper.DefaultParser(statement).testAdditionalInstruction().additionalInstruction();
            _helper.Visitor.Invoking(x => x.VisitAllRoot(tree)).Should().ThrowExactly<ParsingException>()
                .WithMessage("Ambiguous additional instructions: there are multiple additional instructions.");
        }

    }
}
