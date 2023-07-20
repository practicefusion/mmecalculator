using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Messages;

namespace PracticeFusion.MmeCalculator.Core.Services
{
    /// <inheritdoc />
    public class MmeCalculator : IMmeCalculator
    {
        private readonly IOpioidConversionFactor _conversionFactor;
        private readonly ILogger<MmeCalculator> _logger;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="opioidConversionFactor"></param>
        public MmeCalculator(ILogger<MmeCalculator> logger, IOpioidConversionFactor opioidConversionFactor)
        {
            _logger = logger;
            _conversionFactor = opioidConversionFactor;
        }

        /// <summary>
        ///     Constructor uses <see cref="NullLogger" />.
        /// </summary>
        public MmeCalculator() : this(NullLogger<MmeCalculator>.Instance, new OpioidConversionFactor())
        {
        }

        /// <inheritdoc />
        public MmeCalculatorResult Calculate(MedicationComponent medComponent, Dose dose, Route? route)
        {
            using (_logger.BeginScope("Calculating for medication '{medComponent}' and dose '{dose}", medComponent,
                       dose))
            {
                var result = new MmeCalculatorResult
                {
                    MaximumMmePerDay = 0m, OpioidMaximumDailyDose = 0m, OpioidConversionFactor = 0m
                };

                if (!medComponent.IsOpioid || medComponent.Opioid == null)
                {
                    return result;
                }

                if (dose == null || dose.MaxDose == 0)
                {
                    return result;
                }

                // set the conversion factor on the medComponent
                result.OpioidMaximumDailyDose = ConvertSigDoseToMedicationComponentStrength(medComponent, dose);
                result.OpioidConversionFactor = CalculateConversionFactor(
                    medComponent.Opioid.ValueEnum,
                    result.OpioidMaximumDailyDose,
                    medComponent.Form,
                    route,
                    medComponent.UnitOfMeasure?.ValueEnum);
                result.MaximumMmePerDay += result.OpioidMaximumDailyDose * result.OpioidConversionFactor;

                return result;
            }
        }

        /// <inheritdoc />
        public decimal ConvertSigDoseToMedicationComponentStrength(MedicationComponent medComponent, Dose dose)
        {
            using (_logger.BeginScope("Calculating for medication '{medComponent}' and dose '{dose}'", medComponent,
                       dose))
            {
                var convertedDose = dose.MaxDose;

                // basic representation
                if ((dose.DoseUnit == null || medComponent?.UnitOfMeasure == null) && medComponent != null)
                {
                    return convertedDose * medComponent.Strength;
                }

                // if there is no sig uom (1 tablet of tramadol 50mg) = 50mg
                if (dose.DoseUnit?.UnitOfMeasure == null && medComponent != null)
                {
                    return convertedDose * medComponent.Strength;
                }

                // UOM conversion factor: convert sig 500mcg to .5mg for med strength in mg.
                if (medComponent != null)
                {
                    var uomConversionFactor = ConversionUtils.UnitOfMeasureConversionFactor(
                        medComponent.UnitOfMeasure?.ValueEnum,
                        dose.DoseUnit?.UnitOfMeasure?.ValueEnum);
                    if (uomConversionFactor != 0)
                    {
                        convertedDose *= uomConversionFactor;
                    }
                }

                // convert concentrations: sig 1ml, med 20mg/ml = 20mg
                if (medComponent != null)
                {
                    var concentrationFactor = ConversionUtils.ConcentrationConversionFactor(
                        dose.DoseUnit?.UnitOfMeasure?.ValueEnum,
                        medComponent.Strength,
                        medComponent.UnitOfMeasure?.ValueEnum);
                    if (concentrationFactor != 1)
                    {
                        convertedDose *= concentrationFactor;
                    }
                }

                return convertedDose;
            }
        }

        /// <inheritdoc />
        public decimal CalculateConversionFactor(
            OpioidEnum opioid,
            decimal maxDailyDose,
            Form? opioidForm,
            Route? route,
            UnitOfMeasureEnum? opioidUom)
        {
            using (_logger.BeginScope(
                       "Calculating conversion factor for '{opioid}', '{maxDailyDose}', '{opioid}', '{opioidForm}'",
                       opioid,
                       maxDailyDose,
                       opioid,
                       opioidForm))
            {
                var result =
                    _conversionFactor.LookupConversionFactor(opioid, maxDailyDose, opioidUom, opioidForm, route);
                _logger.LogTrace("Conversion factor = {result}", result);
                return result;
            }
        }

        /// <inheritdoc />
        public decimal CalculateConversionFactor(OpioidAnalysis opioid)
        {
            return CalculateConversionFactor(opioid.Opioid, opioid.TotalDailyDose, opioid.Form, null,
                opioid.TotalDailyDoseUom);
        }
    }
}