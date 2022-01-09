using System;

namespace PracticeFusion.MmeCalculator.Core.Entities
{
    /// <summary>
    /// Timing using events rather than time of day
    /// </summary>
    [Serializable]
    public enum EventTimingEnum
    {
        /// <summary>
        /// After noon
        /// </summary>
        AfterNoon,

        /// <summary>
        /// At noon
        /// </summary>
        AtNoon,

        /// <summary>
        /// Before noon
        /// </summary>
        BeforeNoon,

        /// <summary>
        /// Morning
        /// </summary>
        Morning,

        /// <summary>
        /// Night
        /// </summary>
        Night,

        /// <summary>
        /// Bedtime
        /// </summary>
        BedTime,

        /// <summary>
        /// Before every meal
        /// </summary>
        BeforeEveryMeal,

        /// <summary>
        /// After every meal
        /// </summary>
        AfterEveryMeal,

        /// <summary>
        /// With every meal
        /// </summary>
        WithEveryMeal
    }
}
