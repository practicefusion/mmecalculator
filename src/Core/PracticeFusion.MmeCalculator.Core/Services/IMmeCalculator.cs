using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Messages;

namespace PracticeFusion.MmeCalculator.Core.Services
{
    /// <summary>
    /// The MME Calculator interface
    /// </summary>
    public interface IMmeCalculator
    {
        /// <summary>
        /// For a given medication component that contains an opioid, calculate the <see cref="MmeCalculatorResult"/>.
        /// </summary>
        /// <param name="medComponent"></param>
        /// <param name="dose"></param>
        /// <param name="route"></param>
        MmeCalculatorResult Calculate(MedicationComponent medComponent, Dose dose, Route? route);

        /// <summary>
        /// Converts a given dose (with potentially a different unit of measure) into the same
        /// unit of measure in the medication component. This ensures correct calculations.
        /// </summary>
        /// <param name="medComponent"></param>
        /// <param name="dose"></param>
        /// <returns></returns>
        decimal ConvertSigDoseToMedicationComponentStrength(MedicationComponent medComponent, Dose dose);

        /// <summary>
        /// Calculate the conversion factor
        /// </summary>
        /// <param name="opioid"></param>
        /// <param name="maxDailyDose"></param>
        /// <param name="opioidForm"></param>
        /// <param name="route"></param>
        /// <param name="opioidUom"></param>
        /// <returns></returns>
        decimal CalculateConversionFactor(
            OpioidEnum opioid,
            decimal maxDailyDose,
            Form? opioidForm,
            Route? route,
            UnitOfMeasureEnum? opioidUom);

        /// <summary>
        /// Calculate the conversion factor
        /// </summary>
        /// <param name="opioid"></param>
        /// <returns></returns>
        decimal CalculateConversionFactor(OpioidAnalysis opioid);
    }
}
