using System;

namespace PracticeFusion.MmeCalculator.Core.Entities
{
    /// <summary>
    /// Event timing enum
    /// </summary>
    [Serializable]
    public enum EventTimingEnum
    {
        /// <summary>
        /// After noon
        /// </summary>
        [ParseableEnum("after noon")]
        AfterNoon,

        /// <summary>
        /// In the afternoon
        /// </summary>
        [ParseableEnum("in the afternoon")]
        InTheAfternoon,

        /// <summary>
        /// At noon
        /// </summary>
        [ParseableEnum("at noon")]
        AtNoon,

        /// <summary>
        /// Before noon
        /// </summary>
        [ParseableEnum("before noon")]
        BeforeNoon,

        /// <summary>
        /// Morning
        /// </summary>
        [ParseableEnum("in the morning")]
        Morning,

        /// <summary>
        /// Night
        /// </summary>
        [ParseableEnum("at night")]
        Night,

        /// <summary>
        /// Bedtime
        /// </summary>
        [ParseableEnum("at bedtime")]
        BedTime,

        /// <summary>
        /// Before every meal
        /// </summary>
        [ParseableEnum("before every meal")]
        BeforeEveryMeal,

        /// <summary>
        /// After every meal
        /// </summary>
        [ParseableEnum("after every meal")]
        AfterEveryMeal,

        /// <summary>
        /// With every meal
        /// </summary>
        [ParseableEnum("with every meal")]
        WithEveryMeal,

        /// <summary>
        /// Before meals
        /// </summary>
        [ParseableEnum("before meals")]
        BeforeMeals,

        /// <summary>
        /// After every meal
        /// </summary>
        [ParseableEnum("after meals")]
        AfterMeals,

        /// <summary>
        /// With every meal
        /// </summary>
        [ParseableEnum("with meals")]
        WithMeals,

        /// <summary>
        /// Before breakfast
        /// </summary>
        [ParseableEnum("before breakfast")]
        BeforeBreakfast,

        /// <summary>
        /// With breakfast
        /// </summary>
        [ParseableEnum("with breakfast")]
        WithBreakfast,

        /// <summary>
        /// After breakfast
        /// </summary>
        [ParseableEnum("after breakfast")]
        AfterBreakfast,

        /// <summary>
        /// Before lunch
        /// </summary>
        [ParseableEnum("before lunch")]
        BeforeLunch,

        /// <summary>
        /// With lunch
        /// </summary>
        [ParseableEnum("with lunch")]
        WithLunch,

        /// <summary>
        /// After lunch
        /// </summary>
        [ParseableEnum("after lunch")]
        AfterLunch,

        /// <summary>
        /// Before dinner
        /// </summary>
        [ParseableEnum("before dinner")]
        BeforeDinner,

        /// <summary>
        /// With dinner
        /// </summary>
        [ParseableEnum("with dinner")]
        WithDinner,

        /// <summary>
        /// After dinner
        /// </summary>
        [ParseableEnum("after dinner")]
        AfterDinner,
    }
}
