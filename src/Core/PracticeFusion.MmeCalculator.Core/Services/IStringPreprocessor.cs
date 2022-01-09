namespace PracticeFusion.MmeCalculator.Core.Services
{
    /// <summary>
    /// Normalizes a string using any set of rules, e.g. converting to lowercase, etc. for
    /// consistent and simplified parsing.
    /// </summary>
    public interface IStringPreprocessor
    {
        /// <summary>
        /// Normalize the string
        /// </summary>
        /// <param name="inbound"></param>
        /// <returns></returns>
        string Normalize(string inbound);
    }
}
