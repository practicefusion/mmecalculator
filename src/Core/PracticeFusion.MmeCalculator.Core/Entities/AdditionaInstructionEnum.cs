using System;

namespace PracticeFusion.MmeCalculator.Core.Entities
{
    /// <summary>
    /// Additional instruction enum
    /// </summary>
    [Serializable]
    public enum AdditionalInstructionEnum
    {
        /// <summary>
        /// Unknown
        /// </summary>
        Unknown,

        /// <summary>
        /// With food
        /// </summary>
        [ParseableEnum("with food", "with food")]
        WithFood,

        /// <summary>
        /// With liquid
        /// </summary>
        [ParseableEnum("with liquid", "with liquid")]
        WithLiquid,

        /// <summary>
        /// As directed
        /// </summary>
        [ParseableEnum("as directed", "as directed")]
        AsDirected,

        /// <summary>
        /// Before meals
        /// </summary>
        [ParseableEnum("before meals", "before meals")]
        BeforeMeals,

        /// <summary>
        /// During meals
        /// </summary>
        [ParseableEnum("with meals", "with meals")]
        WithMeals,

        /// <summary>
        /// After meals
        /// </summary>
        [ParseableEnum("after meals", "after meals")]
        AfterMeals,
        
        /// <summary>
        /// Before eating
        /// </summary>
        [ParseableEnum("before eating", "before eating")]
        BeforeEating,

        /// <summary>
        /// After eating
        /// </summary>
        [ParseableEnum("after eating", "after eating")]
        AfterEating,

        /// <summary>
        /// Empty stomach
        /// </summary>
        [ParseableEnum("on an empty stomach", "on an empty stomach")]
        EmptyStomach,

        /// <summary>
        /// do not swallow
        /// </summary>
        [ParseableEnum("do not swallow", "do not swallow")]
        DoNotSwallow,
    }
}
