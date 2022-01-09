using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Moq;
using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Services;

namespace PracticeFusion.MmeCalculator.UnitTests
{
    public static class MoqServices
    {
        public static Mock<IDistributedCache> DistributedCache => new();

        public static Mock<IStringPreprocessor> StringPreprocessor => new();

        public static Mock<IRxNormInformationResolver> RxNormResolver => new();

        public static Mock<IOpioidConversionFactor> OpioidConversionFactor => new();

        public static Mock<IMedicationParser> MedicationParser => new();

        public static Mock<ISigParser> SigParser => new();

        public static Mock<IQualityAnalyzer> QualityAnalyzer => new();

        public static Mock<ICalculator> Calculator => new();

        public static Mock<IMmeCalculator> MmeCalculator
        {
            get
            {
                var mmeCalculator = new Mock<IMmeCalculator>();
                mmeCalculator.Setup(x => x.Calculate(It.IsAny<MedicationComponent>(), It.IsAny<Dose>(), It.IsAny<Route>()))
                    .Returns(DefaultEntities.MmeCalculatorResult);
                return mmeCalculator;
            }
        }

        public static Mock<ILogger<T>> Logger<T>()
        {
            return new Mock<ILogger<T>>();
        }
    }
}
