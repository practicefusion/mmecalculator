using System;

namespace PracticeFusion.MmeCalculator.Core.Entities
{
    /// <summary>
    ///     Indication for use
    /// </summary>
    /// <inheritdoc />
    [Serializable]
    public class IndicationForUse : BaseParsedEntity
    {
        /// <summary>
        ///     Indicates whether the indication (precursor only) contains latin abbreviations like "prn"
        /// </summary>
        public bool ContainsLatinAbbreviations { get; set; }

        /// <summary>
        ///     Typically a phrase like "as needed"
        /// </summary>
        public string? IndicationPrecursor { get; set; }

        /// <summary>
        ///     Disease or condition, e.g. "pain"
        /// </summary>
        public string? Indication { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            var useSeparator = string.IsNullOrEmpty(IndicationPrecursor) || !IndicationPrecursor!.EndsWith("for");

            return IndicationPrecursor +
                   (!string.IsNullOrEmpty(Indication) ? (useSeparator ? " for " : " ") + Indication : "");
        }
    }
}