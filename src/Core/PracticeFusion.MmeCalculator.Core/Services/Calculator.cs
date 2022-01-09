using System;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Messages;

namespace PracticeFusion.MmeCalculator.Core.Services
{
    /// <inheritdoc cref="ICalculator"/>
    public class Calculator : ICalculator
    {
        private readonly IQualityAnalyzer _analyzer;

        private readonly string _cachePrefix = "{Calculator}";
        private readonly IDistributedCache? _distributedCache;
        private readonly ILogger _logger;
        private readonly IMedicationParser _medicationParser;
        private readonly IMmeCalculator _mmeCalculator;
        private readonly ISigParser _sigParser;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="distributedCache"></param>
        /// <param name="medicationParser"></param>
        /// <param name="sigParser"></param>
        /// <param name="mmeCalculator"></param>
        /// <param name="analyzer"></param>
        public Calculator(
            ILogger<Calculator> logger,
            IDistributedCache? distributedCache,
            IMedicationParser medicationParser,
            ISigParser sigParser,
            IMmeCalculator mmeCalculator,
            IQualityAnalyzer analyzer)
        {
            _logger = logger;
            _distributedCache = distributedCache;
            _medicationParser = medicationParser;
            _sigParser = sigParser;
            _mmeCalculator = mmeCalculator;
            _analyzer = analyzer;
        }

        /// <summary>
        /// Constructor uses <see cref="NullLogger"/> and sets <see cref="IDistributedCache"/> to null.
        /// </summary>
        public Calculator(IMedicationParser medicationParser) : this(
            NullLogger<Calculator>.Instance,
            null,
            medicationParser,
            new SigParser(),
            new MmeCalculator(),
            new QualityAnalyzer())
        {
        }

        /// <inheritdoc />
        public CalculatedResult Calculate(CalculationRequest request)
        {
            using (_logger.BeginScope("Calculating for '{request}'", request))
            {
                if (request == null)
                {
                    throw new ArgumentNullException(nameof(request));
                }

                if (string.IsNullOrEmpty(request.RequestId))
                {
                    request.RequestId = Guid.NewGuid().ToString();
                }

                var result = new CalculatedResult { RequestId = request.RequestId };

                if (request.CalculationItems.Count == 0)
                {
                    return result;
                }

                int count = 0;
                foreach (CalculationItem item in request.CalculationItems)
                {
                    if (string.IsNullOrEmpty(item.RequestItemId))
                    {
                        item.RequestItemId = $"{count++}";
                    }

                    result.ParsedResults.Add(Calculate(item));
                }

                _analyzer.AnalyzeCalculatedResult(result);

                return result;
            }
        }

        /// <inheritdoc />
        public ParsedSig ParseSig(string sig)
        {
            using (_logger.BeginScope("Parsing sig: '{sig}'", sig))
            {
                ParsedSig result = _sigParser.Parse(sig);
                _analyzer.AnalyzeParsedSig(result);
                return result;
            }
        }

        private ParsedResult Calculate(CalculationItem request)
        {
            string requestItemId = request.RequestItemId!;
            string rxCui = request.RxCui!;
            string sig = request.Sig!;

            string key = $"{_cachePrefix}{{{rxCui}}}{{{sig}}}";

            if (_distributedCache != null && _distributedCache.TryGetValue(key, out ParsedResult cachedResult))
            {
                cachedResult.RequestItemId = requestItemId;
                return cachedResult;
            }

            var result = new ParsedResult();
            string rxNormName = _medicationParser.GetDrugNameFromRxCui(rxCui);
            result.ParsedMedication = _medicationParser.Parse(rxCui, rxNormName);
            result.ParsedSig = _sigParser.Parse(sig);
            result.MaximumDailyDose = result.ParsedSig.MaximumDosage;
            CalculateMaximumMmePerDay(result);

            if (_distributedCache != null && !_distributedCache.Exists(key))
            {
                _distributedCache.Set(key, result);
            }

            // set the request id after setting the cache
            result.RequestItemId = requestItemId;

            return result;
        }

        private void CalculateMaximumMmePerDay(ParsedResult result)
        {
            if (result.ParsedMedication?.MedicationComponents != null)
            {
                foreach (MedicationComponent medComponent in result.ParsedMedication.MedicationComponents)
                {
                    MmeCalculatorResult calculatedResult = _mmeCalculator.Calculate(medComponent, result.MaximumDailyDose!, null);

                    medComponent.OpioidConversionFactor = calculatedResult.OpioidConversionFactor;
                    result.MaximumMmePerDay += calculatedResult.MaximumMmePerDay;
                }
            }
        }
    }
}
