using System;

namespace PracticeFusion.MmeCalculator.Core.Entities
{
    /// <summary>
    ///     The medication or sig route
    /// </summary>
    [Serializable]
    public enum RouteEnum
    {
        /// <summary>
        ///     Orally
        /// </summary>
        [ParseableEnum("by mouth", "by mouth")]
        Orally,

        /// <summary>
        ///     Sublingually
        /// </summary>
        [ParseableEnum("sublingually", "sublingually")]
        Sublingually,

        /// <summary>
        ///     By feeding or gastrostromy tube
        /// </summary>
        [ParseableEnum("by feeding tube", "by feeding tube")]
        FeedingTube,

        /// <summary>
        ///     Transdermal
        /// </summary>
        [ParseableEnum("transdermally", "transdermally")]
        Transdermally,

        /// <summary>
        ///     Topically
        /// </summary>
        [ParseableEnum("topically", "topically")]
        Topically,

        /// <summary>
        ///     Nasally
        /// </summary>
        [ParseableEnum("nasally", "nasally")] Nasally,

        /// <summary>
        ///     Per nostril
        /// </summary>
        [ParseableEnum("per nostril", "per nostril")]
        PerNostril,

        /// <summary>
        ///     Intranasally
        /// </summary>
        [ParseableEnum("intranasally", "intranasally")]
        Intranasally,

        /// <summary>
        ///     Rectal
        /// </summary>
        [ParseableEnum("rectal", "rectal")] Rectal
    }
}