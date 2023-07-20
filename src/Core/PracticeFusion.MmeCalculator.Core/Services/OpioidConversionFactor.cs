using PracticeFusion.MmeCalculator.Core.Entities;
using System;
using System.Collections.Generic;

namespace PracticeFusion.MmeCalculator.Core.Services
{
    /// <inheritdoc />
    public class OpioidConversionFactor : IOpioidConversionFactor
    {
        /// <inheritdoc />
        public decimal LookupConversionFactor(
            OpioidEnum opioid,
            decimal maxDailyDose,
            UnitOfMeasureEnum? uom,
            Form? form,
            Route? route)
        {
            List<ConversionFactorAttribute> conversionFactors = opioid.GetConversionFactors();

            if (conversionFactors.Count == 0)
            {
                return 0m;
            }

            if (conversionFactors.Count == 1)
            {
                return conversionFactors[0].ConversionFactor *
                       GetUomConversionFactor(uom, conversionFactors[0].UnitOfMeasure);
            }


            var highestConversionFactor = 0m;
            var highestUomConversionFactor = 1m;

            foreach (ConversionFactorAttribute? conversionFactor in conversionFactors)
            {
                var uomCf = GetUomConversionFactor(uom, conversionFactor.UnitOfMeasure);

                highestConversionFactor = Math.Max(conversionFactor.ConversionFactor, highestConversionFactor);

                // if the current conversion factor is the highest
                if (highestConversionFactor == conversionFactor.ConversionFactor)
                {
                    // make sure the current UOM is used as well (for highest CF)
                    highestUomConversionFactor = uomCf;
                }


                // return CF based on MDD range
                if (conversionFactor.MinimumDailyDose != null)
                {
                    // if the mdd is not between the ranges, move on
                    var min = conversionFactor.MinimumDailyDose;
                    var max = conversionFactor.MaximumDailyDose;

                    if (maxDailyDose > min && maxDailyDose <= max)
                    {
                        return conversionFactor.ConversionFactor * uomCf;
                    }

                    continue;
                }

                // return CF based on form
                if (form != null && conversionFactor.Forms != null && form.MatchAll(conversionFactor.Forms))
                {
                    return conversionFactor.ConversionFactor * uomCf;
                }
            }

            return highestConversionFactor * highestUomConversionFactor;
        }

        private static decimal GetUomConversionFactor(UnitOfMeasureEnum? sourceUom,
            UnitOfMeasureEnum conversionFactorUom)
        {
            return sourceUom.HasValue
                ? ConversionUtils.UnitOfMeasureConversionFactor(conversionFactorUom, sourceUom)
                : 1;
        }
    }
}