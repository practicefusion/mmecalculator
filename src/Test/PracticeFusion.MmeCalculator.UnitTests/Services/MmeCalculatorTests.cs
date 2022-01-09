using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PracticeFusion.MmeCalculator.UnitTests.Services
{
    [TestClass]
    public class MmeCalculatorTests
    {
        [TestMethod]
        public void CalculateNullDoseReturnsZeroMme()
        {
            var mmeCalculator = new Core.Services.MmeCalculator(
                MoqServices.Logger<Core.Services.MmeCalculator>().Object,
                MoqServices.OpioidConversionFactor.Object);
            var result = mmeCalculator.Calculate(DefaultEntities.MedicationComponent, null, null);
            result.OpioidMaximumDailyDose.Should().Be(0);
            result.OpioidMaximumDailyDose.Should().Be(0);
            result.OpioidConversionFactor.Should().Be(0);
        }
    }
}
