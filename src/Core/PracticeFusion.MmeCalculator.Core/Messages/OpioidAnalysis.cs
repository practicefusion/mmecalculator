using System;
using System.Collections.Generic;
using PracticeFusion.MmeCalculator.Core.Entities;

namespace PracticeFusion.MmeCalculator.Core.Messages
{
    /// <summary>
    /// The analysis of a specific opioid included in any of the medications
    /// in the <see cref="CalculationRequest"/>.
    /// </summary>
    [Serializable]
    public class OpioidAnalysis
    {
        /// <summary>
        /// THe opioid
        /// </summary>
        public OpioidEnum Opioid { get; set; }

        /// <summary>
        /// The form of the opioid. 
        /// </summary>
        public Form? Form { get; set; }

        /// <summary>
        /// The route of the opioid. If there are different routes in the request,
        /// separate analyses will be create for each, to ensure the correct conversion
        /// factor is used the calculations.
        /// </summary>
        public Route? Route { get; set; }

        /// <summary>
        /// The total daily dose of <see cref="Opioid"/>
        /// </summary>
        public decimal TotalDailyDose { get; set; }

        /// <summary>
        /// The unit of measure for <see cref="TotalDailyDose"/>
        /// </summary>
        public UnitOfMeasureEnum? TotalDailyDoseUom { get; set; }

        /// <summary>
        /// The human readable display of <see cref="TotalDailyDose"/>
        /// </summary>
        public string? TddDisplay { get; set; }

        /// <summary>
        /// The conversion factor for <see cref="Opioid"/>, given the <see cref="Route"/> and <see cref="TotalDailyDose"/>.
        /// </summary>
        public decimal ConversionFactor { get; set; }

        /// <summary>
        /// The maximum MME per day for <see cref="Opioid"/>, calculated as <see cref="TotalDailyDose"/> x <see cref="ConversionFactor"/>.
        /// </summary>
        public decimal MaximumMmePerDay { get; set; }

        /// <summary>
        /// A reference to every <see cref="CalculationItem"/> (the <see cref="CalculationItem.RequestItemId"/>) used in this analysis. 
        /// </summary>
        public List<string> RelatedResults { get; set; } = new();
    }
}
