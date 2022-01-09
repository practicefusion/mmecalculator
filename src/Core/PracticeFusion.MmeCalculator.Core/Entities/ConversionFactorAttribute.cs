using PracticeFusion.MmeCalculator.Core.Services;
using System;
using System.Linq;
using System.Text;

namespace PracticeFusion.MmeCalculator.Core.Entities
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    internal sealed class ConversionFactorAttribute : Attribute
    {
        public ConversionFactorAttribute(UnitOfMeasureEnum unitOfMeasure, double conversionFactor)
        {
            UnitOfMeasure = unitOfMeasure;
            MinimumDailyDose = null;
            MaximumDailyDose = null;
            _forms = null;
            ConversionFactor = (decimal)conversionFactor;
        }

        public ConversionFactorAttribute(UnitOfMeasureEnum unitOfMeasure, double minimumDailyDose, double maximumDailyDose, double conversionFactor)
        {
            UnitOfMeasure = unitOfMeasure;
            MinimumDailyDose = minimumDailyDose == double.MinValue ? decimal.MinValue : (decimal)minimumDailyDose;
            MaximumDailyDose = maximumDailyDose == double.MaxValue ? decimal.MaxValue : (decimal)maximumDailyDose;
            _forms = null;
            ConversionFactor = (decimal)conversionFactor;
        }

        public ConversionFactorAttribute(UnitOfMeasureEnum unitOfMeasure, string forms, double conversionFactor)
        {
            UnitOfMeasure = unitOfMeasure;
            MinimumDailyDose = null;
            MaximumDailyDose = null;
            _forms = forms;
            ConversionFactor = (decimal)conversionFactor;
        }

        public ConversionFactorAttribute(
            UnitOfMeasureEnum unitOfMeasure,
            double minimumDailyDose,
            double maximumDailyDose,
            string forms,
            double conversionFactor)
        {
            UnitOfMeasure = unitOfMeasure;
            MinimumDailyDose = minimumDailyDose == double.MinValue ? decimal.MinValue : (decimal)minimumDailyDose;
            MaximumDailyDose = maximumDailyDose == double.MaxValue ? decimal.MaxValue : (decimal)maximumDailyDose;
            _forms = forms;
            ConversionFactor = (decimal)conversionFactor;
        }

        private readonly string? _forms;

        public FormEnum[]? Forms => _forms == null ? null : ParseForms(_forms);

        public UnitOfMeasureEnum UnitOfMeasure { get; }

        public decimal? MaximumDailyDose { get; }

        public decimal? MinimumDailyDose { get; }

        private static FormEnum[] ParseForms(string forms)
        {
            try
            {
                return forms.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(fe => (FormEnum)Enum.Parse(typeof(FormEnum), fe.Trim())).ToArray();
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Unable to parse FormEnum from '{forms}'", e);
            }
        }

        public decimal ConversionFactor { get; }

        public string GetConversionFactorDescription(OpioidEnum opioid)
        {
            // start with the opioid name
            StringBuilder sb = new StringBuilder(opioid.ToString());

            // add form, if present
            if (Forms != null)
            {
                foreach (var form in Forms)
                {
                    sb.Append($" {form}");
                }
            }

            // Add unit of measure
            sb.Append($" ({UnitOfMeasure.GetParseableEnumData().FriendlyName})");

            // add dose range, if present
            if (MinimumDailyDose != null)
            {
                sb.Append(
                    $" >{(MinimumDailyDose == decimal.MinValue ? 0 : MinimumDailyDose):G29}");
            }

            if (MaximumDailyDose != null && MaximumDailyDose != decimal.MaxValue)
            {
                sb.Append($", <= {MaximumDailyDose:G29}");
            }

            return sb.ToString();
        }
    }
}
