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
    public class DosageVisitorTests
    {
        private readonly CoreParserTestHelper<DosageVisitor, DefaultParser.DosageContext, Dosage> _helper = new();

        private static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[]
                {
                    // "during visit" is part of the free text of the outer sig
                    "take 1 tablet every 4-6 hours as directed during visit",
                    "take 1 tablet every 4-6 hours as directed"
                },
                new object[] { "and then take 1 tablet every 4-6 hours", "and then take 1 tablet every 4-6 hours" },
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
                new object[] { "2 sprays intranasally every 4 hours", "2 sprays intranasally every 4 hours" },
                new object[] { "1-2 po daily", "1-2 by mouth every day" },
                new object[] { "1-2 p.o. daily", "1-2 by mouth every day" }
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
            DefaultParser.DosageContext tree = _helper.DefaultParser(statement).dosage();
            Dosage result = _helper.Visitor.VisitRoot(tree);

            result.ToString().Should().Be(expected);
            result.Index.Should().Be(0);
        }
    }
}