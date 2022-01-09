using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Moq;
using RestSharp;

namespace PracticeFusion.MmeCalculator.RxNavRxNormResolver.UnitTests
{
    public static class MoqServices
    {
        public static Mock<IDistributedCache> DistributedCache => new();
        
        public static Mock<IRestClient> RestClient => new();

        public static Mock<ILogger<T>> Logger<T>()
        {
            return new Mock<ILogger<T>>();
        }
    }
}
