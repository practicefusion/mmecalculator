using Microsoft.Extensions.Logging;
using PracticeFusion.MmeCalculator.Core.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace PracticeFusion.MmeCalculator.Core.Services
{
    /// <summary>
    /// Details of a specific combination of Opioid, UOM, Max Daily Dose and Form, along with the
    /// resulting conversion factor.
    /// </summary>
    public class OpioidTransparencyDetails
    {
        /// <summary>
        /// Readable expression of opioid, unit of measure, max daily dose and form
        /// </summary>
        public string Expression { get; set; } = string.Empty;

        /// <summary>
        /// The conversion factor for the given expression
        /// </summary>
        public string ConversionFactor { get; set; } = string.Empty;
    }

    /// <summary>
    /// All transparency details available in the system
    /// </summary>
    public class AllTransparencyDetails
    {
        /// <summary>
        /// The list of opioids and the transparency details for each
        /// </summary>
        public Dictionary<OpioidEnum, List<OpioidTransparencyDetails>> Opioids { get; set; } = new();

        /// <summary>
        /// Any version information for the current service
        /// </summary>
        public Dictionary<string, string> VersionInformation { get; set; } = new();

        /// <summary>
        /// Any reference information used to build the current service
        /// </summary>
        public Dictionary<string, string> ReferenceInformation { get; set; } = new();
    }

    /// <summary>
    /// Utilities to display constants and enumerations used for calculations.
    /// </summary>
    public class TransparencyUtils
    {
        private readonly IOpioidConversionFactor _conversionFactorService;
        private readonly ILogger<TransparencyUtils> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="opioidConversionFactor"></param>
        public TransparencyUtils(ILogger<TransparencyUtils> logger, IOpioidConversionFactor opioidConversionFactor)
        {
            _logger = logger;
            _conversionFactorService = opioidConversionFactor;
        }

        /// <summary>
        /// Display all transparency details.
        /// </summary>
        /// <returns></returns>
        public AllTransparencyDetails AllDetails()
        {
            using (_logger.BeginScope("Output all transparency details"))
            {
                AllTransparencyDetails results = new();

                foreach (OpioidEnum opioid in Enum.GetValues(typeof(OpioidEnum)))
                {
                    var conversionFactors = opioid.GetConversionFactors();

                    var details = conversionFactors.Select(conversionFactor => new OpioidTransparencyDetails()
                    {
                        Expression = conversionFactor.GetConversionFactorDescription(opioid),
                        ConversionFactor = GetConversionFactorValue(opioid, conversionFactor).ToString("G29")
                    }).ToList();

                    results.Opioids.Add(opioid, details);
                }

                // FileVersionInfo
                results.VersionInformation.Add("Product Version", ProductVersion ?? "N/A");
                results.VersionInformation.Add("FileVersionInfo", GetFileVersionInfo().ToString());

                // Reference data
                results.ReferenceInformation.Add("Conversion Factor Reference",
                    "https://www.hhs.gov/guidance/sites/default/files/hhs-guidance-documents/Opioid%20Morphine%20EQ%20Conversion%20Factors%20%28vFeb%202018%29.pdf");

                return results;
            }
        }

        private decimal GetConversionFactorValue(OpioidEnum opioid, ConversionFactorAttribute conversionFactor)
        {
            UnitOfMeasureEnum uom = conversionFactor.UnitOfMeasure;
            decimal maxDailyDose = conversionFactor.MaximumDailyDose ?? 0;
            Form? form = null;
            if (conversionFactor.Forms != null)
            {
                form = new();
                form.ValueEnums.AddRange(conversionFactor.Forms);
            }

            return _conversionFactorService.LookupConversionFactor(opioid, maxDailyDose, uom, form, null);
        }

        /// <summary>
        /// The <see cref="FileVersionInfo.ProductVersion"/> of the current PracticeFusion.MmeCalculator.Core assembly
        /// </summary>
        /// <returns>The ProductVersion if it is available</returns>
        public static string? ProductVersion => TransparencyUtils.GetFileVersionInfo().ProductVersion;

        /// <summary>
        /// The complete <see cref="FileVersionInfo"/> of the current PracticeFusion.MmeCalculator.Core assembly
        /// </summary>
        /// <returns></returns>
        public static FileVersionInfo GetFileVersionInfo()
        {
            return FileVersionInfo.GetVersionInfo(Assembly.GetAssembly(typeof(TransparencyUtils))!.Location);
        }
    }
}
