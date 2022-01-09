using PracticeFusion.MmeCalculator.Core.Entities;

namespace PracticeFusion.MmeCalculator.Core.Services
{
    /// <summary>
    /// Return the conversion factor for an opioid given the dose and optional the form and route)
    /// </summary>
    public interface IOpioidConversionFactor
    {
        /// <summary>
        /// Return the conversion factor
        /// </summary>
        /// <param name="opioid"></param>
        /// <param name="maxDailyDose"></param>
        /// <param name="uom"></param>
        /// <param name="form"></param>
        /// <param name="route"></param>
        /// <returns></returns>
        decimal LookupConversionFactor(OpioidEnum opioid, decimal maxDailyDose, UnitOfMeasureEnum? uom, Form? form, Route? route);
    }
}
