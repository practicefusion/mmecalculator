using PracticeFusion.MmeCalculator.Core.Entities;
using System;
using System.Collections.Generic;

namespace PracticeFusion.MmeCalculator.Core.Messages
{
    /// <summary>
    ///     The analysis of the calculated results, summing up MMEs by opioid, and linking
    ///     to the source medications and sigs that were included in the calculation.
    /// </summary>
    [Serializable]
    public class CalculatedResultAnalysis : IConfidence
    {
        /// <summary>
        ///     The maximum MME/day given the contents of the <see cref="CalculationRequest" />. Some
        ///     opioids have dose-based conversion factors, and therefore must be summed up to ascertain
        ///     the complete daily dose for that opioid (for example, <see cref="OpioidEnum.Methadone" />).
        /// </summary>
        public decimal MaximumMmePerDay { get; set; }

        /// <summary>
        ///     The analysis of each opioid include in the <see cref="CalculationRequest" />.
        /// </summary>
        public List<OpioidAnalysis> Opioids { get; set; } = new();

        /// <inheritdoc />
        public ConfidenceEnum Confidence { get; set; } = ConfidenceEnum.None;

        /// <inheritdoc />
        public List<string> ConfidenceReasons { get; set; } = new();
    }
}