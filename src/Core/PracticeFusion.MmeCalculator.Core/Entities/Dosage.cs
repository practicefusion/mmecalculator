using System;
using System.Collections.Generic;
using System.Text;
using PracticeFusion.MmeCalculator.Core.Messages;

namespace PracticeFusion.MmeCalculator.Core.Entities
{
    /// <summary>
    /// Dosage
    /// </summary>
    /// <inheritdoc cref="BaseParsedEntity"/>
    /// <inheritdoc cref="IConfidence"/>
    [Serializable]
    public class Dosage : BaseParsedEntity, IConfidence
    {
        /// <summary>
        /// Separator word or phrase between dosages, e.g. "then"
        /// </summary>
        public string? DosageSeparator { get; set; }

        /// <summary>
        /// Dose delivery method, e.g. "take"
        /// </summary>
        public DoseDeliveryMethod? DoseDeliveryMethod { get; set; }

        /// <summary>
        /// Dosage dose, e.g. "1-2 tablets"
        /// </summary>
        public Dose? Dose { get; set; }

        /// <summary>
        /// Dosage frequency, e.g. "every 4-6 hours"
        /// </summary>
        public Frequency? Frequency { get; set; }

        /// <summary>
        /// Dosage routes, e.g. "by mouth"
        /// </summary>
        public Route? Route { get; set; }

        /// <summary>
        /// Dosage duration, e.g. "for 30 days"
        /// </summary>
        public Duration? Duration { get; set; }

        /// <summary>
        /// Indication for use, e.g. "as needed for pain"
        /// </summary>
        public IndicationForUse? IndicationForUse { get; set; }

        /// <summary>
        /// Additional instructions for the dosage, e.g. "with food"
        /// </summary>
        public AdditionalInstruction? AdditionalInstruction { get; set; }

        /// <summary>
        /// The maximum dose per day, using the maximum dose, and the shortest
        /// daily interval.
        /// </summary>
        public Dose? MaximumDailyDose
        {
            get
            {
                if (Dose == null)
                {
                    return null;
                }

                if (Frequency == null)
                {
                    return Dose;
                }

                decimal dose = Dose.MaxDose;
                decimal maxDose = dose * Frequency.MaximumDailyFrequency;

                var result = new Dose
                    { Complex = false, DoseUnit = Dose.DoseUnit, MaxDose = maxDose, MinDose = maxDose };

                return result;
            }
        }

        /// <inheritdoc />
        public ConfidenceEnum Confidence { get; set; } = ConfidenceEnum.None;

        /// <inheritdoc />
        public List<string> ConfidenceReasons { get; set; } = new();

        /// <inheritdoc />
        public override string ToString()
        {
            var sb = new StringBuilder();

            AppendWithSpaceIfNeeded(sb, DosageSeparator);
            AppendWithSpaceIfNeeded(sb, DoseDeliveryMethod?.ToString());
            AppendWithSpaceIfNeeded(sb, Dose?.ToString());
            AppendWithSpaceIfNeeded(sb, Route?.ToString());
            AppendWithSpaceIfNeeded(sb, Frequency?.ToString());
            AppendWithSpaceIfNeeded(sb, AdditionalInstruction?.ToString());
            AppendWithSpaceIfNeeded(sb, IndicationForUse?.ToString());
            AppendWithSpaceIfNeeded(sb, Duration?.ToString());

            return sb.ToString();
        }
    }
}
