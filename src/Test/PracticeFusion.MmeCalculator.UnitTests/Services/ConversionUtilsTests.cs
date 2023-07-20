using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Services;

namespace PracticeFusion.MmeCalculator.UnitTests.Services
{
    [TestClass]
    public class ConversionUtilsTests
    {
        [TestMethod]
        public void MilligramToMicrogramTest()
        {
            ConversionUtils.UnitOfMeasureConversionFactor(UnitOfMeasureEnum.Microgram, UnitOfMeasureEnum.Milligram)
                .Should().Be(1000m);
        }

        [TestMethod]
        public void MicrogramToMilligramTest()
        {
            ConversionUtils.UnitOfMeasureConversionFactor(UnitOfMeasureEnum.Milligram, UnitOfMeasureEnum.Microgram)
                .Should().Be(0.001m);
        }

        [TestMethod]
        public void NullConversionReturnsZero()
        {
            ConversionUtils.UnitOfMeasureConversionFactor(null, UnitOfMeasureEnum.Microgram).Should().Be(0m);
            ConversionUtils.UnitOfMeasureConversionFactor(UnitOfMeasureEnum.Milligram, null).Should().Be(0m);
        }

        [TestMethod]
        public void ImpossibleConversionReturnsZero()
        {
            ConversionUtils.UnitOfMeasureConversionFactor(UnitOfMeasureEnum.Centimeter, UnitOfMeasureEnum.Microgram)
                .Should().Be(0m);
        }

        [TestMethod]
        public void NoMilligramConversionPossible()
        {
            ConversionUtils.UnitOfMeasureConversionFactor(UnitOfMeasureEnum.Milligram, UnitOfMeasureEnum.Centimeter)
                .Should().Be(0m);
        }

        [TestMethod]
        public void NoMicrogramConversionPossible()
        {
            ConversionUtils.UnitOfMeasureConversionFactor(UnitOfMeasureEnum.Microgram, UnitOfMeasureEnum.Centimeter)
                .Should().Be(0m);
        }

        [TestMethod]
        public void NullEquivalencyReturnsFalse()
        {
            ConversionUtils.EquivalentUnitOfMeasure(null, UnitOfMeasureEnum.Microgram).Should().BeFalse();
            ConversionUtils.EquivalentUnitOfMeasure(UnitOfMeasureEnum.Milligram, null).Should().BeFalse();
        }

        [TestMethod]
        public void ImpossibleEquivalentReturnsFalse()
        {
            ConversionUtils.EquivalentUnitOfMeasure(UnitOfMeasureEnum.Centimeter, UnitOfMeasureEnum.Microgram).Should()
                .BeFalse();
        }

        [TestMethod]
        public void MicrogramAndMicrogramPerHourAreEquivalent()
        {
            ConversionUtils.EquivalentUnitOfMeasure(UnitOfMeasureEnum.Microgram, UnitOfMeasureEnum.MicrogramPerHour)
                .Should().BeTrue();
        }

        [TestMethod]
        public void MilligramAndMilligramPerHourAreEquivalent()
        {
            ConversionUtils.EquivalentUnitOfMeasure(UnitOfMeasureEnum.Milligram, UnitOfMeasureEnum.MilligramPerHour)
                .Should().BeTrue();
        }

        [TestMethod]
        public void CubicCentimeterAndMilliliterAreEquivalent()
        {
            ConversionUtils.EquivalentUnitOfMeasure(UnitOfMeasureEnum.CubicCentimeter, UnitOfMeasureEnum.Milliliter)
                .Should().BeTrue();
        }

        [TestMethod]
        public void NotMilligramEquivalent()
        {
            ConversionUtils.EquivalentUnitOfMeasure(UnitOfMeasureEnum.Milligram, UnitOfMeasureEnum.Microgram).Should()
                .BeFalse();
        }

        [TestMethod]
        public void NotMicrogramEquivalent()
        {
            ConversionUtils.EquivalentUnitOfMeasure(UnitOfMeasureEnum.Microgram, UnitOfMeasureEnum.Milligram).Should()
                .BeFalse();
        }

        [TestMethod]
        public void GetNumeratorUomMilligram()
        {
            ConversionUtils.GetNumeratorUom(UnitOfMeasureEnum.MilligramPerActuation).Should()
                .Be(UnitOfMeasureEnum.Milligram);
            ConversionUtils.GetNumeratorUom(UnitOfMeasureEnum.MilligramPerHour).Should()
                .Be(UnitOfMeasureEnum.Milligram);
            ConversionUtils.GetNumeratorUom(UnitOfMeasureEnum.MilligramPerMilliliter).Should()
                .Be(UnitOfMeasureEnum.Milligram);
        }

        [TestMethod]
        public void GetNumeratorUomMicrogram()
        {
            ConversionUtils.GetNumeratorUom(UnitOfMeasureEnum.MicrogramPerActuation).Should()
                .Be(UnitOfMeasureEnum.Microgram);
            ConversionUtils.GetNumeratorUom(UnitOfMeasureEnum.MicrogramPerHour).Should()
                .Be(UnitOfMeasureEnum.Microgram);
        }
    }
}