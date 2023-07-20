using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Messages;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;
using PracticeFusion.MmeCalculator.Core.Parsers.Visitors;
using System.Collections.Generic;
using System.Reflection;

namespace PracticeFusion.MmeCalculator.UnitTests.Parsers.Visitors
{
    [TestClass]
    public class StrictSigVisitorTests
    {
        private readonly CoreParserTestHelper<StrictSigVisitor, DefaultParser.StrictSigContext, ParsedSig> _helper =
            new();

        private static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
            };

        [TestMethod]
        public void NullContextShouldThrowParseException()
        {
            _helper.NullContextShouldThrowParseException();
        }

        //[DataTestMethod]
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

        private ParsedSig ParseStatement(string statement)
        {
            DefaultParser.StrictSigContext tree = _helper.DefaultParser(statement).strictSig();
            tree.strictDosage().Should().NotBeNull();
            ParsedSig result = _helper.Visitor.VisitRoot(tree);
            return result;
        }

        private void VisitTest(string statement, string expected)
        {
            DefaultParser.StrictSigContext tree = _helper.DefaultParser(statement).strictSig();
            ParsedSig result = _helper.Visitor.VisitRoot(tree);

            result.ToString().Should().Be(expected);
        }
    }
}