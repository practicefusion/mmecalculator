using PracticeFusion.MmeCalculator.Core.Services;
using System;

namespace PracticeFusion.MmeCalculator.Core.Messages
{
    /// <summary>
    ///     The result of a calculation from <see cref="IMmeCalculator.Calculate" />, returning the MME/day for
    ///     a specific opioid, with a given maximum daily dose, and the routes for the medication. Some opioids
    ///     return different MME values based on dose or route.
    /// </summary>
    [Serializable]
    public class MmeCalculatorResult
    {
        /// <summary>
        ///     The maximum mme per day, calculated as MDD x Conversion Factor
        /// </summary>
        public decimal MaximumMmePerDay { get; set; }

        /// <summary>
        ///     The opioid conversion factor, given the dose and route
        /// </summary>
        public decimal OpioidConversionFactor { get; set; }

        /// <summary>
        ///     The maximum daily dose of the opioid
        /// </summary>
        public decimal OpioidMaximumDailyDose { get; set; }
    }
}