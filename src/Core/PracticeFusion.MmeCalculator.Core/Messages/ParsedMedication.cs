using System;
using System.Collections.Generic;
using System.Linq;
using PracticeFusion.MmeCalculator.Core.Entities;

namespace PracticeFusion.MmeCalculator.Core.Messages
{
    /// <summary>
    /// The result of parsing an RxNorm medication
    /// </summary>
    /// <inheritdoc cref="BaseParsedEntity"/>
    /// <inheritdoc cref="IConfidence"/>
    [Serializable]
    public class ParsedMedication : BaseParsedEntity, IConfidence
    {
        /// <summary>
        /// The original RxNorm text of the medication
        /// </summary>
        public string? OriginalMedication { get; set; }

        /// <summary>
        /// The pre-processed text of the medication
        /// </summary>
        public string? PreprocessedMedication { get; set; }

        /// <summary>
        /// The requested RxCUI
        /// </summary>
        public string? RxCui { get; set; }

        /// <summary>
        /// Each of the components in the medication
        /// </summary>
        public List<MedicationComponent> MedicationComponents { get; set; } = new();

        /// <inheritdoc />
        public ConfidenceEnum Confidence { get; set; } = ConfidenceEnum.None;

        /// <inheritdoc />
        public List<string> ConfidenceReasons { get; set; } = new();

        /// <inheritdoc />
        public override string ToString()
        {
            return string.Join(" / " , MedicationComponents.Select(x => x.HumanReadable).ToArray());
        }
    }
}
