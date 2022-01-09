using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PracticeFusion.MmeCalculator.Core.Entities;

namespace PracticeFusion.MmeCalculator.Core.Messages
{
    /// <summary>
    /// Parse a sig
    /// </summary>
    /// <inheritdoc cref="BaseParsedEntity"/>
    /// <inheritdoc cref="IConfidence"/>
    [Serializable]
    public class ParsedSig : BaseParsedEntity, IConfidence
    {
        /// <summary>
        /// Indicates whether any of the components of the sig contain latin abbreviations, e.g. "bid", "po", "prn"
        /// </summary>
        public bool ContainsLatinAbbreviations =>
            Dosages.Any(
                d => d.IndicationForUse is {ContainsLatinAbbreviations: true} ||
                     d.Frequency is {ContainsLatinAbbreviations: true} ||
                     d.Route is {ContainsLatinAbbreviations: true});

        /// <summary>
        /// The original sig text
        /// </summary>
        public string? OriginalSig { get; set; }

        /// <summary>
        /// The pre-processed text of the sig 
        /// </summary>
        public string? PreprocessedSig { get; set; }

        /// <summary>
        /// The maximum dosage from <see cref="Dosages"/>
        /// </summary>
        public Dose? MaximumDosage { get; set; }

        /// <summary>
        /// Each of the dosages parsed from the sig
        /// </summary>
        public List<Dosage> Dosages { get; set; } = new();

        /// <summary>
        /// Optional clarifying free text at the end of a sig
        /// </summary>
        public string? ClarifyingFreeText { get; set; }
        
        /// <inheritdoc />
        public ConfidenceEnum Confidence { get; set; } = ConfidenceEnum.None;
        
        /// <inheritdoc />
        public List<string> ConfidenceReasons { get; set; } = new();

        /// <inheritdoc />
        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (Dosage dosage in Dosages)
            {
                sb.AppendFormat("{0}{1}", sb.Length > 0 ? " " : "", dosage);
            }

            if (!string.IsNullOrEmpty(ClarifyingFreeText))
            {
                sb.AppendFormat("{0}{1}", sb.Length > 0 ? " " : "", ClarifyingFreeText);
            }

            return sb.ToString();
        }
    }
}
