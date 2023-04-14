using PracticeFusion.MmeCalculator.Core.Services;

namespace PracticeFusion.MmeCalculator.LocalRxNormResolver
{
    /// <summary>
    ///     The client
    /// </summary>
    /// <inheritdoc />
    public class Client : IRxNormInformationResolver
    {
        /// <inheritdoc />
        public string ResolveRxNormCode(string rxNormCui)
        {
            try
            {
                return LocalData.Codes[rxNormCui] ?? string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}