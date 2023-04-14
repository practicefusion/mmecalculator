using System.Collections.Generic;

namespace PracticeFusion.MmeCalculator.Core.Messages
{
    /// <summary>
    ///     Potentially missing components from sig
    /// </summary>
    public interface ISigSuggestions
    {
        /// <summary>
        ///     Components of the sig that might be missing,
        ///     causing a parsing failure.
        /// </summary>
        List<string> SigSuggestions { get; set; }
    }
}