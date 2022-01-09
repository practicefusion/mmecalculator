using System;
using System.Collections.Generic;
using PracticeFusion.MmeCalculator.Core.Entities;

namespace PracticeFusion.MmeCalculator.Core.Messages
{
    /// <summary>
    /// The result of parsing the sig and medication
    /// </summary>
    /// <inheritdoc />
    [Serializable]
    public class ParsedResult : IConfidence
    {
        /// <summary>
        /// The <see cref="CalculationItem.RequestItemId"/> from the request used to generate this result.
        /// </summary>
        public string? RequestItemId { get; set; }

        /// <summary>
        /// The parsed medication
        /// </summary>
        public ParsedMedication? ParsedMedication { get; set; }

        /// <summary>
        /// The parsed sig
        /// </summary>
        public ParsedSig? ParsedSig { get; set; }

        /// <summary>
        /// The maximum MME per day for this item. <strong>Note: </strong> this may be different from
        /// the final analysis, as some opioids have different conversion factors based on total daily dose; if
        /// a patient is taking more than one prescription daily, please check the <see cref="CalculatedResultAnalysis"/>.
        /// </summary>
        public decimal MaximumMmePerDay { get; set; }

        /// <summary>
        /// Maximum daily dose from the <see cref="ParsedSig"/>
        /// </summary>
        public Dose? MaximumDailyDose { get; set; }

        /// <inheritdoc />
        public ConfidenceEnum Confidence { get; set; } = ConfidenceEnum.None;

        /// <inheritdoc />
        public List<string> ConfidenceReasons { get; set; } = new();
    }
}
