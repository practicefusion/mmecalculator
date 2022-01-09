using System;

namespace PracticeFusion.MmeCalculator.Core.Messages
{
    /// <summary>
    /// Confidence
    /// </summary>
    [Serializable]
    public enum ConfidenceEnum
    {
        /// <summary>
        /// No confidence. The result should not be used.
        /// </summary>
        None = 0,

        /// <summary>
        /// Low confidence. May be useful for debugging.
        /// </summary>
        Low = 1,

        /// <summary>
        /// Medium confidence. There were parse errors, and the "human readable" presentation should be checked.
        /// </summary>
        Medium = 2,

        /// <summary>
        /// High confidence. It is still prudent to confirm the "human readable" presentation.
        /// </summary>
        High = 4
    }
}
