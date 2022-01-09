using PracticeFusion.MmeCalculator.Core.Messages;

namespace PracticeFusion.MmeCalculator.Core.Services
{
    /// <summary>
    /// Parse a sig into a structure. No analysis is performed on the result.
    /// </summary>
    public interface ISigParser
    {
        /// <summary>
        /// Parse the sig
        /// </summary>
        /// <param name="sig"></param>
        /// <returns></returns>
        ParsedSig Parse(string sig);
    }
}
