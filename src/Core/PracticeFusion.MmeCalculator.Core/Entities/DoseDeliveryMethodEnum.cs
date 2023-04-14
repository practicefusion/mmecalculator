using System;

namespace PracticeFusion.MmeCalculator.Core.Entities
{
    /// <summary>
    ///     Dose delivery method enumeration
    /// </summary>
    [Serializable]
    public enum DoseDeliveryMethodEnum
    {
        /// <summary>
        ///     Administer
        /// </summary>
        [ParseableEnum("administer", "administer")]
        Administer,

        /// <summary>
        ///     Apply
        /// </summary>
        [ParseableEnum("apply", "apply")] Apply,

        /// <summary>
        ///     Chew
        /// </summary>
        [ParseableEnum("chew", "chew")] Chew,

        /// <summary>
        ///     Chew and Swallow
        /// </summary>
        [ParseableEnum("chew and swallow", "chew and swallow")]
        ChewAndSwallow,

        /// <summary>
        ///     Dissolve
        /// </summary>
        [ParseableEnum("dissolve", "dissolve")]
        Dissolve,

        /// <summary>
        ///     Give
        /// </summary>
        [ParseableEnum("give", "give")] Give,

        /// <summary>
        ///     Infuse
        /// </summary>
        [ParseableEnum("infuse", "infuse")] Infuse,

        /// <summary>
        ///     Inhale
        /// </summary>
        [ParseableEnum("inhale", "inhale")] Inhale,

        /// <summary>
        ///     Inject
        /// </summary>
        [ParseableEnum("inject", "inject")] Inject,

        /// <summary>
        ///     Insert
        /// </summary>
        [ParseableEnum("insert", "insert")] Insert,

        /// <summary>
        ///     Place
        /// </summary>
        [ParseableEnum("place", "place")] Place,

        /// <summary>
        ///     Suck
        /// </summary>
        [ParseableEnum("suck", "suck")] Suck,

        /// <summary>
        ///     Take
        /// </summary>
        [ParseableEnum("take", "take")] Take,

        /// <summary>
        ///     Use
        /// </summary>
        [ParseableEnum("use", "use")] Use
    }
}