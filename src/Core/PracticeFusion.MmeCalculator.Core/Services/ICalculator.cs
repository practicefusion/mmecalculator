using PracticeFusion.MmeCalculator.Core.Messages;

namespace PracticeFusion.MmeCalculator.Core.Services
{
    /// <summary>
    /// Calculate MMEs per day given one or more medications and sigs
    /// </summary>
    public interface ICalculator
    {
        /// <summary>
        /// The calculation request
        /// </summary>
        /// <param name="request"></param>
        /// <returns>The calculation result</returns>
        CalculatedResult Calculate(CalculationRequest request);

        /// <summary>
        /// Parse an individual sig, and return the parsed structure
        /// </summary>
        /// <param name="sig"></param>
        /// <returns>The parsed structure</returns>
        ParsedSig ParseSig(string sig);
    }
}
