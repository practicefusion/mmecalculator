using System.Collections.Generic;

namespace PracticeFusion.MmeCalculator.Core.Messages
{
    /// <summary>
    ///     Parse confidence
    /// </summary>
    public interface IConfidence
    {
        /// <summary>
        ///     Confidence of the parse for this entity
        /// </summary>
        ConfidenceEnum Confidence { get; set; }

        /// <summary>
        ///     List of reasons for the current confidence
        /// </summary>
        List<string> ConfidenceReasons { get; set; }
    }
}