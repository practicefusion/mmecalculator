using System;

namespace PracticeFusion.MmeCalculator.Core.Entities
{
    /// <summary>
    /// An optional dose and unit of measure, e.g. 1-2 mg <strong>(1-2 ml)</strong>.
    /// Note: a dose conversion shares the same form as the main dose, if it is present.
    /// </summary>
    /// <inheritdoc />
    [Serializable]
    public class DoseConversion : BaseParsedEntity
    {
        /// <summary>
        /// The minimum conversion dose
        /// </summary>
        public decimal MinDose { get; set; }

        /// <summary>
        /// The maximum conversion dose
        /// </summary>
        public decimal MaxDose { get; set; }

        /// <summary>
        /// Indicates the conversion dose has a different minimum and maximum value.
        /// </summary>
        public bool Complex { get; set; }

        /// <summary>
        /// The unit of measure for the dose conversion
        /// </summary>
        public UnitOfMeasure? UnitOfMeasure { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            if (Complex)
            {
                return
                    $"{MinDose:G29}-{MaxDose:G29}{(UnitOfMeasure != null && UnitOfMeasure.ToString().Length > 0 ? " " + UnitOfMeasure.Pluralize(MaxDose) : string.Empty)}";
            }

            return
                $"{MinDose:G29}{(UnitOfMeasure != null && UnitOfMeasure.ToString().Length > 0 ? " " + UnitOfMeasure.Pluralize(MinDose) : string.Empty)}";
        }
    }
}
