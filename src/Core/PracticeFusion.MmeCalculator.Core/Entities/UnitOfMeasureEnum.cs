using System;

namespace PracticeFusion.MmeCalculator.Core.Entities
{
    /// <summary>
    /// Unit of measure
    /// </summary>
    [Serializable]
    public enum UnitOfMeasureEnum
    {
        /// <summary>
        /// Centimeter (cm)
        /// </summary>
        [ParseableEnum("cm", "cm")] Centimeter,

        /// <summary>
        /// Cubic centimeter (cc)
        /// </summary>
        [ParseableEnum("cc", "cc")] CubicCentimeter,

        /// <summary>
        /// Gram (g)
        /// </summary>
        [ParseableEnum("g", "g")] Gram,

        /// <summary>
        /// Internation unit (iu)
        /// </summary>
        [ParseableEnum("iu", "iu")] InternationalUnit,

        /// <summary>
        /// Liter (l)
        /// </summary>
        [ParseableEnum("l", "l")] Liter,

        /// <summary>
        /// Milliequivalent (meq)
        /// </summary>
        [ParseableEnum("meq", "meq")] Milliequivalent,

        /// <summary>
        /// Microgram per hour (mcg/hr)
        /// </summary>
        [ParseableEnum("mcg/hr", "mcg/hr")] MicrogramPerHour,

        /// <summary>
        /// Microgram per actuation (mcg/act)
        /// </summary>
        [ParseableEnum("mcg/act", "mcg/act")] MicrogramPerActuation,

        /// <summary>
        /// Microgram (mg)
        /// </summary>
        [ParseableEnum("mcg", "mcg")] Microgram,

        /// <summary>
        /// Milligram per hour (mg/hr)
        /// </summary>
        [ParseableEnum("mg/hr", "mg/hr")] MilligramPerHour,

        /// <summary>
        /// Milligram per actuation (mg/act)
        /// </summary>
        [ParseableEnum("mg/act", "mg/act")] MilligramPerActuation,

        /// <summary>
        /// Milligram per milliliter (mg/ml)
        /// </summary>
        [ParseableEnum("mg/ml", "mg/ml")] MilligramPerMilliliter,

        /// <summary>
        /// Milligram (mg)
        /// </summary>
        [ParseableEnum("mg", "mg")] Milligram,

        /// <summary>
        /// Milliliter (ml)
        /// </summary>
        [ParseableEnum("ml", "ml")] Milliliter,

        /// <summary>
        /// Ounce (oz)
        /// </summary>
        [ParseableEnum("oz", "oz")] Ounce,

        /// <summary>
        /// Tablespoon
        /// </summary>
        [ParseableEnum("tablespoon", "tablespoons")]
        Tablespoon,

        /// <summary>
        /// Teaspoon
        /// </summary>
        [ParseableEnum("teaspoon", "teaspoons")]
        Teaspoon
    }
}
