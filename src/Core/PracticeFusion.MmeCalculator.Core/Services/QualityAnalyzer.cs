using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Messages;
using System.Collections.Generic;
using System.Linq;

namespace PracticeFusion.MmeCalculator.Core.Services
{
    /// <inheritdoc />
    public class QualityAnalyzer : IQualityAnalyzer
    {
        private readonly ILogger<QualityAnalyzer> _logger;
        private readonly IMmeCalculator _mmeCalculator;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mmeCalculator"></param>
        public QualityAnalyzer(ILogger<QualityAnalyzer> logger, IMmeCalculator mmeCalculator)
        {
            _logger = logger;
            _mmeCalculator = mmeCalculator;
        }

        /// <summary>
        ///     Constructor uses <see cref="NullLogger" />.
        /// </summary>
        public QualityAnalyzer() : this(NullLogger<QualityAnalyzer>.Instance, new MmeCalculator())
        {
        }

        /// <inheritdoc />
        public void AnalyzeCalculatedResult(CalculatedResult calculatedResult)
        {
            using (_logger.BeginScope("Analyzing result '{calculatedResult}'", calculatedResult))
            {
                calculatedResult.CalculatedResultAnalysis ??= new CalculatedResultAnalysis();

                // start with high confidence, and chip away at it.
                calculatedResult.CalculatedResultAnalysis.Confidence = ConfidenceEnum.High;

                QualityCheck.IsTrue(
                    calculatedResult.ParsedResults is { Count: > 0 },
                    ConfidenceEnum.None,
                    calculatedResult.CalculatedResultAnalysis,
                    "Failed to parse anything");

                // no need to continue if we have no confidence in the result
                if (calculatedResult.CalculatedResultAnalysis.Confidence == ConfidenceEnum.None)
                {
                    return;
                }

                // loop through every parsed result
                if (calculatedResult.ParsedResults != null)
                {
                    foreach (ParsedResult parsedResult in calculatedResult.ParsedResults)
                    {
                        AnalyzeParsedResult(parsedResult);
                    }

                    QualityCheck.SetLowestConfidence(
                        calculatedResult.CalculatedResultAnalysis,
                        calculatedResult.ParsedResults,
                        "Not all parsed results high confidence");
                }

                AnalyzeOpioids(calculatedResult);
            }
        }

        /// <inheritdoc />
        public void AnalyzeOpioids(CalculatedResult calculatedResult)
        {
            using (_logger.BeginScope("Analyzing opioids"))
            {
                var opioids = new Dictionary<string, OpioidAnalysis>();

                // step through every parsed result with an opioid in the med
                foreach (ParsedResult parsedResult in calculatedResult.ParsedResults
                             .Where(x => x.ParsedMedication?.MedicationComponents.Count(y => y.IsOpioid) > 0))
                {
                    if (parsedResult.ParsedSig == null || parsedResult.ParsedMedication == null)
                    {
                        parsedResult.Confidence = ConfidenceEnum.None;
                        parsedResult.ConfidenceReasons.Add(
                            "Missing either a parsed sig or a parsed medication, require both.");
                        continue;
                    }

                    // use the initial route as the global route
                    Route? route = parsedResult.ParsedSig?.Dosages?.Count > 0
                        ? parsedResult.ParsedSig.Dosages[0].Route
                        : null;

                    foreach (MedicationComponent medicationComponent in parsedResult.ParsedMedication
                                 .MedicationComponents.Where(
                                     x =>
                                         x.IsOpioid && x.Confidence == ConfidenceEnum.High))
                    {
                        OpioidEnum opioidEnum = medicationComponent.Opioid!.ValueEnum;
                        Form? formEnums = medicationComponent.Form;
                        var relatedItem = parsedResult.RequestItemId!;
                        var key = $"{{{opioidEnum}}}{{{formEnums}}}";

                        MmeCalculatorResult mmeCalculatorResult = _mmeCalculator.Calculate(
                            medicationComponent,
                            parsedResult.ParsedSig!.MaximumDosage!,
                            route);

                        var mdd = mmeCalculatorResult.OpioidMaximumDailyDose;
                        UnitOfMeasureEnum? uom = medicationComponent.UnitOfMeasure?.ValueEnum;

                        // strip out the denominator UOM
                        uom = ConversionUtils.GetNumeratorUom(uom);

                        if (!opioids.ContainsKey(key))
                        {
                            opioids.Add(
                                key,
                                new OpioidAnalysis
                                {
                                    Opioid = opioidEnum,
                                    Form = formEnums,
                                    TotalDailyDose = mdd,
                                    TotalDailyDoseUom = uom,
                                    ConversionFactor = mmeCalculatorResult.OpioidConversionFactor,
                                    RelatedResults = new List<string> { relatedItem }
                                });
                        }
                        else
                        {
                            OpioidAnalysis opioid = opioids[key];

                            // confirm the UOM (from a previous med/component calculation) is equivalent, otherwise convert
                            var strengthConversion =
                                ConversionUtils.UnitOfMeasureConversionFactor(opioid.TotalDailyDoseUom, uom);

                            opioid.TotalDailyDose += strengthConversion * mdd;
                            if (!opioid.RelatedResults.Contains(relatedItem))
                            {
                                opioid.RelatedResults.Add(relatedItem);
                            }
                        }
                    }
                }

                // step through each opioid and add the max MME: we have to wait until we have all the results,
                // because drugs like methadone vary the factor by total daily dose.
                foreach (OpioidAnalysis opioid in opioids.Values)
                {
                    opioid.ConversionFactor = _mmeCalculator.CalculateConversionFactor(opioid);
                    opioid.MaximumMmePerDay = opioid.ConversionFactor * opioid.TotalDailyDose;
                    opioid.TddDisplay =
                        opioid.TotalDailyDose + (opioid.TotalDailyDoseUom != null
                            ? " " + opioid.TotalDailyDoseUom.GetParseableEnumData().FriendlyName
                            : "");
                }

                // set the results
                calculatedResult.CalculatedResultAnalysis.Opioids.AddRange(opioids.Values);
                calculatedResult.CalculatedResultAnalysis.MaximumMmePerDay =
                    calculatedResult.CalculatedResultAnalysis.Opioids.Sum(x => x.MaximumMmePerDay);
            }
        }

        /// <inheritdoc />
        public void AnalyzeParsedResult(ParsedResult parsedResult)
        {
            using (_logger.BeginScope("Analyzing parsed result"))
            {
                parsedResult.Confidence = ConfidenceEnum.High;
                QualityCheck.IsTrue(
                    parsedResult.ParsedSig?.Dosages != null && parsedResult.ParsedSig.Dosages.Count > 0,
                    ConfidenceEnum.None,
                    parsedResult,
                    "Failed to parse the sig");
                QualityCheck.IsTrue(
                    parsedResult.ParsedMedication?.MedicationComponents != null &&
                    parsedResult.ParsedMedication.MedicationComponents.Count > 0,
                    ConfidenceEnum.None,
                    parsedResult,
                    "Failed to find the medication");

                if (parsedResult.Confidence > ConfidenceEnum.None)
                {
                    AnalyzeParsedSig(parsedResult.ParsedSig!);
                    AnalyzeParsedMedication(parsedResult.ParsedMedication!);
                }

                QualityCheck.SetLowestConfidence(parsedResult, new[] { parsedResult.ParsedSig! },
                    "Sig not high confidence");
                QualityCheck.SetLowestConfidence(parsedResult, new[] { parsedResult.ParsedMedication! },
                    "Medication not high confidence");
            }
        }

        /// <inheritdoc />
        public void AnalyzeParsedSig(ParsedSig parsedSig)
        {
            using (_logger.BeginScope("Analyzing parsed sig"))
            {
                // start by checking the individual dosages
                parsedSig.Confidence = ConfidenceEnum.High;

                foreach (Dosage dosage in parsedSig.Dosages)
                {
                    AnalyzeDosage(dosage);
                }

                // check each dosage start-end, and compare against the inbound
                // sig. If there is sufficient difference, the confidence should be
                // lowered, e.g. if "take 1 pill bid and do not lie down for one hour"
                // is parsed as "take 1 pill twice a day", the difference in the
                // parsed elements (using start and length) should return no confidence.

                // start by checking for gaps between (or before) dosages
                var currentReadPoint = 0;

                foreach (Dosage dosage in parsedSig.Dosages)
                {
                    // ignore small gaps (likely from "and", "then", etc.
                    if (dosage.Index > currentReadPoint + 4)
                    {
                        dosage.Confidence = ConfidenceEnum.None;
                        dosage.ConfidenceReasons.Add(
                            $"Text from the original sig was not parsed: '{parsedSig.PreprocessedSig?.Substring(currentReadPoint, dosage.Index - currentReadPoint)}'");
                    }

                    currentReadPoint = dosage.Index + dosage.Length;
                }

                // next, check for a gap between the last dosage + the length of any ClarifyingFreeText,
                // and the end of the sig.
                if (currentReadPoint + (parsedSig.ClarifyingFreeText?.Length ?? 0) + 4 <
                    parsedSig.PreprocessedSig?.Length)
                {
                    parsedSig.Confidence = ConfidenceEnum.None;
                    parsedSig.ConfidenceReasons.Add(
                        $"Text from the original sig was not parsed: '{parsedSig.PreprocessedSig?.Substring(currentReadPoint)}'");
                }

                // finally, for multiple dosage sigs, pick the lowest confidence among them
                QualityCheck.SetLowestConfidence(parsedSig, parsedSig.Dosages, "Not all dosages high confidence");
            }
        }

        /// <inheritdoc />
        public void AnalyzeParsedMedication(ParsedMedication parsedMedication)
        {
            using (_logger.BeginScope("Analyzing parsed medication"))
            {
                parsedMedication.Confidence = ConfidenceEnum.High;

                foreach (MedicationComponent medicationComponent in parsedMedication.MedicationComponents)
                {
                    AnalyzeMedicationComponent(medicationComponent);
                }

                QualityCheck.SetLowestConfidence(
                    parsedMedication,
                    parsedMedication.MedicationComponents,
                    "Not all medication components high confidence");
            }
        }

        /// <inheritdoc />
        public void AnalyzeDosage(Dosage dosage)
        {
            using (_logger.BeginScope("Analyzing dosage"))
            {
                // start with high confidence, and chip away at it (unless we already have confidence reasons)
                if (dosage.ConfidenceReasons.Count == 0)
                {
                    dosage.Confidence = ConfidenceEnum.High;
                }

                QualityCheck.IsTrue(dosage.HumanReadable?.Length > 0, ConfidenceEnum.None, dosage,
                    "Failed to parse the sig");
                QualityCheck.IsNotNull(dosage.Dose, ConfidenceEnum.None, dosage, "No dose information present");
                QualityCheck.IsTrue(dosage.HumanReadable?.Length >= 4, ConfidenceEnum.None, dosage,
                    "Original sig too short or ambiguous");
                QualityCheck.IsTrue(
                    dosage.Frequency != null && dosage.Frequency.ToString().Length > 0,
                    ConfidenceEnum.None,
                    dosage,
                    "Frequency missing or ambiguous");
            }
        }

        /// <inheritdoc />
        public void AnalyzeMedicationComponent(MedicationComponent medicationComponent)
        {
            medicationComponent.Confidence = ConfidenceEnum.High;
        }
    }
}