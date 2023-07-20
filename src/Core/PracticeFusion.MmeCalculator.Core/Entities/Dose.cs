using System;

namespace PracticeFusion.MmeCalculator.Core.Entities
{
    /// <summary>
    ///     Dose
    /// </summary>
    /// <inheritdoc />
    [Serializable]
    public class Dose : BaseParsedEntity
    {
        /// <summary>
        ///     The minimum dose
        /// </summary>
        public decimal MinDose { get; set; }

        /// <summary>
        ///     The maximum dose
        /// </summary>
        public decimal MaxDose { get; set; }

        /// <summary>
        ///     An optional unit of measure conversion, e.g. 1 mg (1 ml)
        /// </summary>
        public DoseConversion? DoseConversion { get; set; }

        /// <summary>
        ///     Indicates the dose has a different minimum and maximum value.
        /// </summary>
        public bool Complex { get; set; }

        /// <summary>
        ///     The dose unit (form or unit of measure)
        /// </summary>
        public DoseUnit? DoseUnit { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            if (Complex)
            {
                return
                    $"{MinDose:G29}-{MaxDose:G29}{(DoseUnit != null && DoseUnit.ToString().Length > 0 ? " " + DoseUnit.Pluralize(MaxDose) : string.Empty)}{(DoseConversion != null ? " (" + DoseConversion + ")" : string.Empty)}";
            }

            return
                $"{MinDose:G29}{(DoseUnit != null && DoseUnit.ToString().Length > 0 ? " " + DoseUnit.Pluralize(MinDose) : string.Empty)}{(DoseConversion != null ? " (" + DoseConversion + ")" : string.Empty)}";
        }
    }
}