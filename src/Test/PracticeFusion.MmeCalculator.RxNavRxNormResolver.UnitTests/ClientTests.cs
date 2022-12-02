using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using RestSharp;
using RichardSzalay.MockHttp;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PracticeFusion.MmeCalculator.RxNavRxNormResolver.UnitTests
{
    [TestClass]
    public class ClientTest
    {
        private const string BaseUrl = "https://rxnav.nlm.nih.gov";

        [TestMethod]
        public void ReturnsAValidForResolveRxNormCode()
        {
            var restClient = MockRestClient(DefaultNorcoResponse);

            var client = new Client(
                MoqServices.DistributedCache.Object,
                DefaultServices.Logger,
                restClient);

            var response = client.ResolveRxNormCode("some-code");
            response.Should().NotBeNull();
        }


        [TestMethod]
        public void ReturnsAValidResultWhenSearchingByName()
        {
            var restClient = MockRestClient(DefaultDrugSearchResponse);

            var client = new Client(
                MoqServices.DistributedCache.Object,
                DefaultServices.Logger,
                restClient);

            var response = client.SearchForDrugByName("some-name");
            response.Should().NotBeNull();
            response.IdGroup.Should().NotBeNull();
            response.IdGroup.Name.Should().Be("aspirin");
            response.IdGroup.RxNormId.Should().Contain("1191");
        }

        [TestMethod]
        public void ReturnsAValidResultWhenSearchingByNameOrSynonym()
        {
            var restClient = MockRestClient(DefaultDrugSearchResponse);

            var client = new Client(
                MoqServices.DistributedCache.Object,
                DefaultServices.Logger,
                restClient);

            var response = client.SearchForDrugByNameOrSynonym("some-name");
            response.Should().NotBeNull();
            response.IdGroup.Should().NotBeNull();
            response.IdGroup.Name.Should().Be("aspirin");
            response.IdGroup.RxNormId.Should().Contain("1191");

        }

        [TestMethod]
        public void ReturnsTheCorrectDrugNameFromTheResponse()
        {
            var restClient = MockRestClient(DefaultNorcoResponse);

            var client = new Client(
                MoqServices.DistributedCache.Object,
                DefaultServices.Logger,
                restClient);

            var response = client.ResolveRxNormCode("some-code");
            response.Should().NotBeNull();
            response.Should().Be("acetaminophen 325 MG / hydrocodone bitartrate 7.5 MG Oral Tablet [Norco]");
        }


        [TestMethod]
        public void HandlesNotFoundCorrectly()
        {
            var restClient = MockRestClient(DefaultNotFoundResponse);

            var client = new Client(
                MoqServices.DistributedCache.Object,
                DefaultServices.Logger,
                restClient);

            var response = client.ResolveRxNormCode("some-code");
            response.Should().NotBeNull();
        }

        private RestClient MockRestClient(string response)
        {
            var handler = new MockHttpMessageHandler();
            handler.When(BaseUrl + "/*").Respond("application/json", response);

            var restClient = new RestClient(new RestClientOptions { BaseUrl = new Uri(BaseUrl), ConfigureMessageHandler = _ => handler });

            return restClient;
        }

        private static string DefaultNorcoResponse =>
            @"{""propConceptGroup"":{""propConcept"":[{""propCategory"":""NAMES"",""propName"":""RxNorm Name"",""propValue"":""acetaminophen 325 MG / hydrocodone bitartrate 7.5 MG Oral Tablet [Norco]""},{""propCategory"":""NAMES"",""propName"":""RxNorm Synonym"",""propValue"":""Norco 7.5/325 (hydrocodone / acetaminophen) Oral Tablet""},{""propCategory"":""NAMES"",""propName"":""RxNorm Synonym"",""propValue"":""APAP 325 MG / Hydrocodone Bitartrate 7.5 MG Oral Tablet [Norco]""},{""propCategory"":""NAMES"",""propName"":""Prescribable Synonym"",""propValue"":""NORCO 7.5 MG / 325 MG Oral Tablet""},{""propCategory"":""NAMES"",""propName"":""Tallman Synonym"",""propValue"":""acetaminophen 325 MG / HYDROcodone bitartrate 7.5 MG Oral Tablet [Norco]""},{""propCategory"":""NAMES"",""propName"":""Tallman Synonym"",""propValue"":""APAP 325 MG / HYDROcodone Bitartrate 7.5 MG Oral Tablet [Norco]""},{""propCategory"":""NAMES"",""propName"":""Tallman Synonym"",""propValue"":""Norco 7.5/325 (HYDROcodone / acetaminophen) Oral Tablet""}]}}";

        private static string DefaultDrugSearchResponse =>
            @"{""idGroup"":{""name"":""aspirin"",""rxnormId"":[""1191""]}}";

        private static string DefaultNotFoundResponse => @"{""propConceptGroup"":null}";
    }
}
