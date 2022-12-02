using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using PracticeFusion.MmeCalculator.Core.Services;
using PracticeFusion.MmeCalculator.RxNavRxNormResolver.Responses;
using RestSharp;

namespace PracticeFusion.MmeCalculator.RxNavRxNormResolver
{
    /// <summary>
    /// Uses the RxNav API to look up drugs and fetch drug names in the RxNorm format.
    /// </summary>
    /// <remarks>This product uses publicly available data from the U.S. National Library of Medicine (NLM), National Institutes of Health, Department of Health and Human Services; NLM is not responsible for the product and does not endorse or recommend this or any other product.</remarks>
    public class Client : IRxNormInformationResolver
    {
        private const string BaseUrl = "https://rxnav.nlm.nih.gov";

        private readonly RestClient _client;
        private readonly IDistributedCache _cache;
        private readonly ILogger<Client> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cache"></param>
        /// <param name="logger"></param>
        public Client(IDistributedCache cache, ILogger<Client> logger)
        {
            _logger = logger;
            _logger.LogDebug("Creating RxNav API client.");
            _client = new RestClient(BaseUrl);
            _cache = cache;
        }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cache"></param>
        /// <param name="logger"></param>
        /// <param name="client"></param>
        public Client(IDistributedCache cache, ILogger<Client> logger, RestClient client)
        {
            _logger = logger;
            _client = client;
            _cache = cache;
        }

        /// <summary>
        /// Look up the drug by RxNorm CUI, and return the drug name. Only returns the first response.
        /// </summary>
        /// <param name="rxNormCui"></param>
        /// <returns>The drug name in the RxNorm format</returns>
        public string ResolveRxNormCode(string rxNormCui)
        {
            var response = SearchForDrugByRxNormCui(rxNormCui);
            return response.PropertyConceptGroup?.PropertyConcepts?.FirstOrDefault(x => x.Category == "NAMES" && x.Name == "RxNorm Name")
                ?.Value ?? string.Empty;
        }

        /// <summary>
        /// Performs the same search as <see cref="ResolveRxNormCode"/> but returns the complete RxNav structured response.
        /// </summary>
        /// <param name="rxNormCui"></param>
        /// <returns></returns>
        public AllPropertiesResponse SearchForDrugByRxNormCui(string rxNormCui)
        {
            var request = new RestRequest("/REST/rxcui/{rxcui}/allProperties.json?prop=NAMES") { Method = Method.Get };
            request.AddParameter("rxcui", rxNormCui, ParameterType.UrlSegment);
            var response = Execute<AllPropertiesResponse>(request, rxNormCui);
            return response ?? new AllPropertiesResponse();
        }

        /// <summary>
        /// Search for drugs by name or synonym.
        /// </summary>
        /// <param name="sbdName"></param>
        /// <returns></returns>
        public DrugSearchResponse SearchForDrugByNameOrSynonym(string sbdName)
        {
            var request = new RestRequest("/REST/rxcui.json") { Method = Method.Get };
            request.AddParameter("name", sbdName, ParameterType.QueryString);
            request.AddParameter("search", "2", ParameterType.QueryString);
            var response = Execute<DrugSearchResponse>(request, "SearchForDrugByNameOrSynonym" + sbdName);
            return response ?? new DrugSearchResponse();
        }

        /// <summary>
        /// Search for drugs by name
        /// </summary>
        /// <param name="drugName"></param>
        /// <returns></returns>
        public DrugSearchResponse SearchForDrugByName(string drugName)
        {
            var request = new RestRequest("/REST/drugs.json") { Method = Method.Get };
            request.AddParameter("name", drugName, ParameterType.QueryString);
            var response = Execute<DrugSearchResponse>(request, drugName);
            return response ?? new DrugSearchResponse();
        }

        private T? Execute<T>(RestRequest request, string requestKey) where T : new()
        {
            string? cachedResult = string.Empty;

            try
            {
                cachedResult = _cache.GetString(requestKey);
            }
            catch (Exception rce)
            {
                _logger.LogWarning(rce, "Could not connect to distributed cache provider.");
            }

            if (string.IsNullOrEmpty(cachedResult))
            {
                var stopWatch = new Stopwatch();

                stopWatch.Start();
                var response = _client.Execute(request);
                stopWatch.Stop();

                // only present if there was an exception
                if (response.ErrorException != null)
                {
                    const string message = "Error receiving response. Check inner details for more information";
                    var clientException = new Exception(message, response.ErrorException);
                    throw clientException;
                }

                // cache the non-error result
                try
                {
                    _cache?.SetString(requestKey, response.Content ?? string.Empty);
                }
                catch (Exception rce)
                {
                    _logger.LogWarning(rce, "Could not connect to distributed cache provider.");
                }

                if (_logger.IsEnabled(LogLevel.Debug))
                {
                    LogRequestResponse(stopWatch.ElapsedMilliseconds, request, response);
                }

                // return the value
                return JsonUtils.Deserialize<T>(response.Content ?? string.Empty);
            }
            else
            {
                // returned cached value
                if (_logger.IsEnabled(LogLevel.Debug))
                {
                    LogRequestResponse(0, request, null, cachedResult);
                }

                return JsonUtils.Deserialize<T>(cachedResult ?? string.Empty);
            }
        }

        private void LogRequestResponse(long elapsedMilliseconds, RestRequest request, RestResponse? response, string? cachedContent = null)
        {
            _logger.LogDebug("Request completed in {elapsedMilliseconds} ms.", elapsedMilliseconds);

            var logRequest = new
            {
                resource = request.Resource,
                parameters = request.Parameters.Select(
                    parameter => new
                    {
                        name = parameter.Name,
                        value = parameter.Value,
                        type = parameter.Type.ToString()
                    }),
                method = request.Method.ToString(),
                uri = _client.BuildUri(request)
            };
            _logger?.LogDebug("Request: {request}", JsonUtils.Debug(logRequest));

            if (response != null)
            {
                var logResponse = new
                {
                    statusCode = response.StatusCode,
                    headers = response.Headers,
                    responseUri = response.ResponseUri,
                    errorMessage = response.ErrorMessage,
                };
                _logger?.LogDebug("Response: {response}", JsonUtils.Debug(logResponse));

                var logContent = response.Content;
                _logger?.LogDebug("Content: {content}", JsonUtils.JsonFormat(logContent));
            }
            else
            {
                var logContent = cachedContent;
                _logger?.LogDebug("Cached Content: {cachedContent}", logContent == null ? "NULL" : JsonUtils.JsonFormat(logContent));
            }
        }
    }
}
