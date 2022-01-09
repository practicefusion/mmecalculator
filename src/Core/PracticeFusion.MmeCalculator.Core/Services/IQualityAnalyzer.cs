using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Messages;

namespace PracticeFusion.MmeCalculator.Core.Services
{
    /// <summary>
    /// Analyze the quality of the various results of calculations and parses, and
    /// update the confidence.
    /// </summary>
    public interface IQualityAnalyzer
    {
        /// <summary>
        /// Analyze the calculated result
        /// </summary>
        /// <param name="calculatedResult"></param>
        void AnalyzeCalculatedResult(CalculatedResult calculatedResult);

        /// <summary>
        /// Analyze the opioids in the calculated result
        /// </summary>
        /// <param name="calculatedResult"></param>
        void AnalyzeOpioids(CalculatedResult calculatedResult);

        /// <summary>
        /// Analyze a parsed result (including sig and medication)
        /// </summary>
        /// <param name="parsedResult"></param>
        void AnalyzeParsedResult(ParsedResult parsedResult);

        /// <summary>
        /// Analyze a parsed sig
        /// </summary>
        /// <param name="parsedSig"></param>
        void AnalyzeParsedSig(ParsedSig parsedSig);

        /// <summary>
        /// Analyze a parsed medication
        /// </summary>
        /// <param name="parsedMedication"></param>
        void AnalyzeParsedMedication(ParsedMedication parsedMedication);

        /// <summary>
        /// Analyze a dosage from a sig
        /// </summary>
        /// <param name="dosage"></param>
        void AnalyzeDosage(Dosage dosage);

        /// <summary>
        /// Analyze a component in a medication
        /// </summary>
        /// <param name="medicationComponent"></param>
        void AnalyzeMedicationComponent(MedicationComponent medicationComponent);
    }
}
