using System.Collections.Generic;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PracticeFusion.MmeCalculator.Core.Messages;
using PracticeFusion.MmeCalculator.Core.Services;

namespace PracticeFusion.MmeCalculator.WebDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculator _calculator;
        private readonly ILogger<CalculatorController> _logger;
        private readonly TransparencyUtils _transparencyUtils;

        public CalculatorController(ILogger<CalculatorController> logger, ICalculator calculator, TransparencyUtils transparencyUtils)
        {
            _logger = logger;
            _calculator = calculator;
            _transparencyUtils = transparencyUtils;
        }

        /// <summary>
        /// Calculate the maximum MME per day given a single drug (the RxNorm CUI), and the sig 
        /// </summary>
        /// <remarks>
        /// Sample request for Percocet 7.5-325mg (RxNorm CUI: 1049642), and a sig with a maximum daily dose of 8 tablets:
        ///
        ///     GET /api/calculator/1049642?sig=1-2 tabs every 6-8 hours prn pain
        /// 
        /// </remarks>
        /// <param name="rxCui">The RxNorm CUI for the drug</param>
        /// <param name="sig">The sig for the prescribed medication</param>
        /// <returns>The calculated result containing the maximum MME per day and detailed analysis</returns>
        [HttpGet("{rxCui}")]
        public CalculatedResult Get(string rxCui, string sig)
        {
            var calculationRequest = new CalculationRequest
            {
                CalculationItems =
                    new List<CalculationItem>(new[] { new CalculationItem { RequestItemId = "1", RxCui = rxCui, Sig = HttpUtility.UrlDecode(HttpUtility.UrlDecode(sig)) } })
            };

            return Calculate(calculationRequest);
        }

        /// <summary>
        /// Calculate the maximum MME per day given a list of drugs and their sigs, typically for the active medication list 
        /// </summary>
        /// <remarks>
        /// Sample request for two separate medications (Percocet 7.5-325mg and Ultram 200mg) with their respective sigs
        ///
        ///     POST /api/calculator/calculate
        ///     {
        ///         "requestId": "Sample-Request",
        ///         "calculationItems": [
        ///             {
        ///                 "requestItemId": "0",
        ///                 "rxCui": "1049642",
        ///                 "sig": "1-2 tabs every 6-8 hours prn pain"
        ///             },
        ///             {
        ///                 "requestItemId": "1",
        ///                 "rxCui": "845315",
        ///                 "sig": "1 tab bid with water"
        ///             }
        ///         ]
        ///     }
        /// 
        /// </remarks>
        /// <param name="calculationRequest">The items to be calculated</param>
        /// <returns>The calculated result containing the maximum MME per day and detailed analysis</returns>
        [HttpPost]
        public CalculatedResult Calculate([FromBody] CalculationRequest calculationRequest)
        {
            _logger.LogInformation("Calculation request: {calculationRequest}", JsonUtils.Serialize(calculationRequest, false));
            return _calculator.Calculate(calculationRequest);
        }

        /// <summary>
        /// Parse a sig
        /// </summary>
        /// <remarks>
        /// Sample request to parse a tapering sig
        ///
        ///     GET /api/calculator?sig=1 tablet every 8 hours for 3 days, then 1 tablet every 12 hours for 2 days, then 1 tablet a day prn pain
        /// 
        /// </remarks>
        /// <param name="sig">The sig</param>
        /// <returns>Machine-readable sig and detailed analysis</returns>
        [HttpGet("")]
        public ParsedSig ParseSig(string sig)
        {
            // double decode just in case
            var decodedSig = HttpUtility.UrlDecode(HttpUtility.UrlDecode(sig));
            _logger.LogInformation("Url decoded sig: {decodedSig}", decodedSig);
            var parsedSig = _calculator.ParseSig(decodedSig);
            return parsedSig;
        }
        
        /// <summary>
        /// Parse a sig using strict sig rules
        /// </summary>
        /// <remarks>
        /// Sample request to parse a tapering sig using strict parsing rules
        ///
        ///     GET /api/calculator?sig=1 tablet every 8 hours for 3 days, then 1 tablet every 12 hours for 2 days, then 1 tablet a day prn pain
        /// 
        /// </remarks>
        /// <param name="sig">The sig</param>
        /// <returns>Machine-readable sig and detailed analysis</returns>
        [HttpGet("strict")]
        public ParsedSig ParseSigStrict(string sig)
        {
            // double decode just in case
            var decodedSig = HttpUtility.UrlDecode(HttpUtility.UrlDecode(sig));
            _logger.LogInformation("Url decoded sig: {decodedSig}", decodedSig);
            var parsedSig = _calculator.ParseSigStrict(decodedSig);
            return parsedSig;
        }

        /// <summary>
        /// View data used for parsing sigs, medications and calculating
        /// conversion factors for opioids
        /// </summary>
        /// <remarks>
        /// Sample request 
        ///
        ///     GET /api/calculator/transparency
        /// 
        /// </remarks>
        /// <returns>Details used for parsing and calculation</returns>
        [HttpGet("transparency")]
        public AllTransparencyDetails DisplayTransparencyInformation()
        {
            return _transparencyUtils.AllDetails();
        }
    }
}
