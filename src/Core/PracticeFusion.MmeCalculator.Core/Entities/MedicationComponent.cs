using System;
using System.Collections.Generic;
using PracticeFusion.MmeCalculator.Core.Messages;

namespace PracticeFusion.MmeCalculator.Core.Entities
{
    /// <summary>
    /// A component of a medication, indicating whether it is an opioid or non-opioid component.
    /// </summary>
    /// <inheritdoc cref="BaseParsedEntity"/>
    /// <inheritdoc cref="IConfidence"/>
    [Serializable]
    public class MedicationComponent : BaseParsedEntity, IConfidence
    {
        /// <summary>
        /// Description
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Strength
        /// </summary>
        public decimal Strength { get; set; }

        /// <summary>
        /// Indicates if the component is an opioid
        /// </summary>
        public bool IsOpioid { get; set; }

        /// <summary>
        /// Opioid
        /// </summary>
        public Opioid? Opioid { get; set; }

        /// <summary>
        /// The computed conversion factor for the opioid
        /// </summary>
        public decimal OpioidConversionFactor { get; set; }

        /// <summary>
        /// The unit of measure
        /// </summary>
        public UnitOfMeasure? UnitOfMeasure { get; set; }

        /// <summary>
        /// The form of the medication (all components share the same form)
        /// </summary>
        public Form? Form { get; set; }

        /// <inheritdoc />
        public ConfidenceEnum Confidence { get; set; } = ConfidenceEnum.None;

        /// <inheritdoc />
        public List<string> ConfidenceReasons { get; set; } = new();

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{Name} {Strength}{(UnitOfMeasure != null ? " " + Pluralize(Strength) : string.Empty)}";
        }
        
        internal string Pluralize(decimal count)
        {
            if (UnitOfMeasure != null)
            {
                return UnitOfMeasure.Pluralize(count);
            }

            return string.Empty;
        }
    }
}
