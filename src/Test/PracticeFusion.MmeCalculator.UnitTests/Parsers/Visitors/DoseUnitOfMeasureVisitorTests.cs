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
    public class DoseUnitOfMeasureVisitorTests
    {
        private readonly CoreParserTestHelper<DoseUnitOfMeasureVisitor, DefaultParser.DoseUnitOfMeasureContext,
            UnitOfMeasure> _helper =
            new();

        private static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[] { "cm", "cm" },
                new object[] { "centimeters", "cm" },
                new object[] { "cc", "cc" },
                new object[] { "ccs", "cc" },
                new object[] { "gs", "g" },
                new object[] { "gms", "g" },
                new object[] { "grams", "g" },
                new object[] { "ius", "iu" },
                new object[] { "international units", "iu" },
                new object[] { "ius", "iu" },
                new object[] { "units", "iu" },
                new object[] { "liter", "l" },
                new object[] { "liters", "l" },
                new object[] { "meqs", "meq" },
                new object[] { "milliequivalents", "meq" },
                new object[] { "mcg/hr", "mcg/hr" },
                new object[] { "mcg/actuations", "mcg/act" },
                new object[] { "mcg/sprays", "mcg/act" },
                new object[] { "mcg", "mcg" },
                new object[] { "mg/hr", "mg/hr" },
                new object[] { "mg/actuations", "mg/act" },
                new object[] { "mg/ml", "mg/ml" },
                new object[] { "mg/actuations", "mg/act" },
                new object[] { "mgs", "mg" },
                new object[] { "milligrams", "mg" },
                new object[] { "mls", "ml" },
                new object[] { "millilitres", "ml" },
                new object[] { "oz", "oz" },
                new object[] { "ounces", "oz" },
                new object[] { "tablespoons", "tablespoon" },
                new object[] { "tbsps", "tablespoon" },
                new object[] { "tbls", "tablespoon" },
                new object[] { "teas", "teaspoon" },
                new object[] { "tsps", "teaspoon" },
                new object[] { "teaspoons", "teaspoon" }
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
            DefaultParser.DoseUnitOfMeasureContext tree = _helper.DefaultParser(statement).doseUnitOfMeasure();
            UnitOfMeasure result = _helper.Visitor.VisitRoot(tree);

            result.ToString().Should().Be(expected);
            result.Index.Should().Be(0);
            result.Length.Should().Be(statement.Length);
        }
    }
}