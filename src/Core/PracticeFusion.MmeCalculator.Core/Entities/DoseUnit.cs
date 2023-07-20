using System;

namespace PracticeFusion.MmeCalculator.Core.Entities
{
    /// <summary>
    ///     Dose unit (either Form or Unit of Measure)
    /// </summary>
    /// <inheritdoc />
    [Serializable]
    public class DoseUnit : BaseParsedEntity
    {
        /// <summary>
        ///     Unit of measure
        /// </summary>
        public UnitOfMeasure? UnitOfMeasure { get; set; }

        /// <summary>
        ///     Form
        /// </summary>
        public Form? Form { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            return Pluralize(1);
        }

        internal string Pluralize(decimal count)
        {
            if (UnitOfMeasure != null)
            {
                return UnitOfMeasure.Pluralize(count);
            }

            if (Form != null)
            {
                return Form.Pluralize(count);
            }

            return string.Empty;
        }
    }
}