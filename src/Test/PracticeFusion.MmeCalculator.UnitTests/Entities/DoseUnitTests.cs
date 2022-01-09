using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeFusion.MmeCalculator.Core.Entities;

namespace PracticeFusion.MmeCalculator.UnitTests.Entities
{
    [TestClass]
    public class DoseUnitTests
    {
        [TestMethod]
        public void ToStringTest()
        {
            DoseUnit doseUnit = new DoseUnit { Form = new Form() { ValueEnums = new List<FormEnum>() { FormEnum.Dose } } };
            doseUnit.ToString().Should().Be("dose");
        }

        [TestMethod]
        public void PluralizeTest()
        {
            DoseUnit doseUnit = new DoseUnit { Form = new Form() { ValueEnums = new List<FormEnum>() { FormEnum.Dose } } };
            doseUnit.Pluralize(2).Should().Be("doses");
        }

        [TestMethod]
        public void HandlesFormCorrectly()
        {
            DoseUnit doseUnit = new DoseUnit { Form = new Form() { ValueEnums = new List<FormEnum>() { FormEnum.Dose } } };
            doseUnit.ToString().Should().Be("dose");
        }

        [TestMethod]
        public void HandlesUomCorrectly()
        {
            DoseUnit doseUnit = new DoseUnit { UnitOfMeasure = new UnitOfMeasure() { ValueEnum = UnitOfMeasureEnum.Gram } };
            doseUnit.ToString().Should().Be("g");
        }

        [TestMethod]
        public void HandlesEmptyCaseCorrectly()
        {
            DoseUnit doseUnit = new DoseUnit();
            doseUnit.ToString().Should().Be("");
        }
    }
}
