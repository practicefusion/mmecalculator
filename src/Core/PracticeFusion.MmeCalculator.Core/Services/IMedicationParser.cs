using PracticeFusion.MmeCalculator.Core.Messages;

namespace PracticeFusion.MmeCalculator.Core.Services
{
    /// <summary>
    /// Parse medications
    /// </summary>
    public interface IMedicationParser
    {
        /// <summary>
        /// Use the RxCUI to resolve the drug and return an RxNorm drug name
        /// </summary>
        /// <param name="rxCui"></param>
        /// <returns></returns>
        string GetDrugNameFromRxCui(string rxCui);

        /// <summary>
        /// Parse the medication from the RxNorm drug name
        /// </summary>
        /// <param name="rxCui"></param>
        /// <param name="rxNormName"></param>
        /// <returns></returns>
        ParsedMedication Parse(string rxCui, string rxNormName);
    }
}
