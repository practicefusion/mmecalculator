using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestSharp;

namespace PracticeFusion.MmeCalculator.RxNavRxNormResolver.UnitTests
{
    [TestClass]
    public class ClientTest
    {
        [TestMethod]
        public void ReturnsAValidForResolveRxNormCode()
        {
            var restClient = MoqServices.RestClient;
            restClient.Reset();
            restClient.Setup(x => x.Execute(It.IsAny<IRestRequest>())).Returns(DefaultNorcoResponse);


            var client = new Client(
                MoqServices.DistributedCache.Object,
                DefaultServices.Logger,
                restClient.Object);

            var response = client.ResolveRxNormCode("some-code");
            restClient.Verify(x => x.Execute(It.IsAny<IRestRequest>()), Times.Once);
            response.Should().NotBeNull();
        }


        [TestMethod]
        public void ReturnsAValidResultWhenSearchingByName()
        {
            var restClient = MoqServices.RestClient;
            restClient.Reset();
            restClient.Setup(x => x.Execute(It.IsAny<IRestRequest>())).Returns(DefaultDrugSearchResponse);


            var client = new Client(
                MoqServices.DistributedCache.Object,
                DefaultServices.Logger,
                restClient.Object);

            var response = client.SearchForDrugByName("some-name");
            restClient.Verify(x => x.Execute(It.IsAny<IRestRequest>()), Times.Once);
            response.Should().NotBeNull();
            response.IdGroup.Should().NotBeNull();
            response.IdGroup.Name.Should().Be("aspirin");
            response.IdGroup.RxNormId.Should().Contain("1191");
        }

        [TestMethod]
        public void ReturnsAValidResultWhenSearchingByNameOrSynonym()
        {
            var restClient = MoqServices.RestClient;
            restClient.Reset();
            restClient.Setup(x => x.Execute(It.IsAny<IRestRequest>())).Returns(DefaultDrugSearchResponse);


            var client = new Client(
                MoqServices.DistributedCache.Object,
                DefaultServices.Logger,
                restClient.Object);

            var response = client.SearchForDrugByNameOrSynonym("some-name");
            restClient.Verify(x => x.Execute(It.IsAny<IRestRequest>()), Times.Once);
            response.Should().NotBeNull();
            response.IdGroup.Should().NotBeNull();
            response.IdGroup.Name.Should().Be("aspirin");
            response.IdGroup.RxNormId.Should().Contain("1191");

        }

        [TestMethod]
        public void ReturnsTheCorrectDrugNameFromTheResponse()
        {
            var restClient = MoqServices.RestClient;
            restClient.Reset();
            restClient.Setup(x => x.Execute(It.IsAny<IRestRequest>())).Returns(DefaultNorcoResponse);


            var client = new Client(
                MoqServices.DistributedCache.Object,
                DefaultServices.Logger,
                restClient.Object);

            var response = client.ResolveRxNormCode("some-code");
            restClient.Verify(x => x.Execute(It.IsAny<IRestRequest>()), Times.Once);
            response.Should().NotBeNull();
            response.Should().Be("acetaminophen 325 MG / hydrocodone bitartrate 7.5 MG Oral Tablet [Norco]");
        }


        [TestMethod]
        public void HandlesNotFoundCorrectly()
        {
            var restClient = MoqServices.RestClient;
            restClient.Reset();
            restClient.Setup(x => x.Execute(It.IsAny<IRestRequest>())).Returns(DefaultNotFoundResponse);


            var client = new Client(
                MoqServices.DistributedCache.Object,
                DefaultServices.Logger,
                restClient.Object);

            var response = client.ResolveRxNormCode("some-code");
            restClient.Verify(x => x.Execute(It.IsAny<IRestRequest>()), Times.Once);
            response.Should().NotBeNull();
        }

        private static RestResponse DefaultNorcoResponse => new()
        {
            Content =
                @"{""propConceptGroup"":{""propConcept"":[{""propCategory"":""NAMES"",""propName"":""RxNorm Name"",""propValue"":""acetaminophen 325 MG / hydrocodone bitartrate 7.5 MG Oral Tablet [Norco]""},{""propCategory"":""NAMES"",""propName"":""RxNorm Synonym"",""propValue"":""Norco 7.5/325 (hydrocodone / acetaminophen) Oral Tablet""},{""propCategory"":""NAMES"",""propName"":""RxNorm Synonym"",""propValue"":""APAP 325 MG / Hydrocodone Bitartrate 7.5 MG Oral Tablet [Norco]""},{""propCategory"":""NAMES"",""propName"":""Prescribable Synonym"",""propValue"":""NORCO 7.5 MG / 325 MG Oral Tablet""},{""propCategory"":""NAMES"",""propName"":""Tallman Synonym"",""propValue"":""acetaminophen 325 MG / HYDROcodone bitartrate 7.5 MG Oral Tablet [Norco]""},{""propCategory"":""NAMES"",""propName"":""Tallman Synonym"",""propValue"":""APAP 325 MG / HYDROcodone Bitartrate 7.5 MG Oral Tablet [Norco]""},{""propCategory"":""NAMES"",""propName"":""Tallman Synonym"",""propValue"":""Norco 7.5/325 (HYDROcodone / acetaminophen) Oral Tablet""}]}}"
        };

        private static RestResponse DefaultDrugSearchResponse => new()
        {
            Content = @"{""idGroup"":{""name"":""aspirin"",""rxnormId"":[""1191""]}}"
        };

        private static RestResponse DefaultNotFoundResponse => new()
        {
            Content = @"{""propConceptGroup"":null}"
        };
    }
}
