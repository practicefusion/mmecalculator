using System.Collections.Generic;
using System.Reflection;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Messages;
using PracticeFusion.MmeCalculator.Core.Parsers;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;
using PracticeFusion.MmeCalculator.Core.Parsers.Visitors;
using System;

namespace PracticeFusion.MmeCalculator.UnitTests.Parsers.Visitors
{
    [TestClass]
    public class StrictDosageVisitorTests
    {
        private readonly CoreParserTestHelper<StrictDosageVisitor, DefaultParser.StrictDosageContext, Dosage> _helper = new();

        [TestMethod]
        public void NullContextShouldThrowParseException()
        {
            _helper.NullContextShouldThrowParseException();
        }

        [TestMethod]
        public void StrictSigRequiresDoseDeliverMethod()
        {
            List<string> expectedRules = new List<string> { "dosageSeparator", "doseDeliveryMethod" };
            this.Invoking(x => x.ThrowParserErrors("1 tablet every 4-6 hours")).Should()
                .Throw<ParsingSyntaxException>().And.AllSyntaxErrors[0].Item3.Should().Contain(expectedRules);
        }

        [TestMethod]
        public void StrictSigRequiresDose()
        {
            List<string> expectedRules = new List<string> { "doseVal", "rangeNumericValueWithUOM" };
            this.Invoking(x => x.ThrowParserErrors("take every 4-6 hours")).Should()
                .Throw<ParsingSyntaxException>().And.AllSyntaxErrors[0].Item3.Should().Contain(expectedRules);
        }

        
        private static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[]
                {
                    // "during visit" is part of the free text of the outer sig
                    "take 1 tablet every 4-6 hours as directed during visit",
                    "take 1 tablet every 4-6 hours as directed"
                },
                new object[]
                {
                    "and then take 1 tablet every 4-6 hours",
                    "and then take 1 tablet every 4-6 hours"
                },
                new object[]
                {
                    "take 1-2 tablets by mouth every 4-6 hours for one week",
                    "take 1-2 tablets by mouth every 4-6 hours for 1 week"
                },
                new object[]
                {
                    "take 1-2 tablets by mouth every 4-6 hours with water for one week",
                    "take 1-2 tablets by mouth every 4-6 hours with water for 1 week"
                },
                new object[]
                {
                    "take 1-2 tablets by mouth every 4-6 hours with water prn pain for one week",
                    "take 1-2 tablets by mouth every 4-6 hours with water as needed for pain for 1 week"
                },
                new object[]
                {
                    "take 1-2 tablets by mouth every 4-6 hours with water prn severe chest pain for one week",
                    "take 1-2 tablets by mouth every 4-6 hours with water as needed for severe chest pain for 1 week"
                },
                new object[] {"2 sprays intranasally every 4 hours", "2 sprays intranasally every 4 hours"},
                new object[] { "1-2 po daily", "1-2 by mouth every day" },
                new object[] { "1-2 p.o. daily", "1-2 by mouth every day" },
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

        private void ThrowParserErrors(string statement)
        {
            List<(ConfidenceEnum Confidence, string ConfidenceReason, List<string>)> parseErrors;
            var tree = _helper.DefaultParserWithParseErrors(statement, out parseErrors).strictDosage();
            _helper.ThrowParserErrors(_helper.Parser, tree, parseErrors);
        }
        
        private void VisitTest(string statement, string expected)
        {
            var tree = _helper.DefaultParser(statement).strictDosage();
            var result = _helper.Visitor.VisitRoot(tree);

            result.ToString().Should().Be(expected);
            result.Index.Should().Be(0);
        }
    }
}
