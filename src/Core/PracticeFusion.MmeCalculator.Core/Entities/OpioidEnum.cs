using System;

namespace PracticeFusion.MmeCalculator.Core.Entities
{
    /// <summary>
    /// The active opioid
    ///
    /// from: https://www.hhs.gov/guidance/sites/default/files/hhs-guidance-documents/Opioid%20Morphine%20EQ%20Conversion%20Factors%20%28vFeb%202018%29.pdf
    /// which is pointed at from: https://www.hhs.gov/guidance/document/opioid-oral-morphine-milligram-equivalent-mme-conversion-factors-0
    /// </summary>
    [Serializable]
    public enum OpioidEnum
    {
        /// <summary>
        /// Buprenorphine
        /// The April 2017 version of the document noted above (no longer available) included several variations of conversion factors
        /// for buprenorphine. The current document states:
        ///
        /// "Buprenorphine products are listed but do not have an associated MME conversion factor. These buprenorphine products, as partial opioid
        /// agonists, are not expected to be associated with overdose risk in the same dose-dependent manner as doses for full agonist opioids.
        /// The conversion factors for drugs prescribed or provided as part of medication-assisted treatment for opioid use disorder should not be
        /// used to benchmark against dosage thresholds meant for opioids prescribed for pain."
        /// 
        /// In order to match as closely as possible the concept of "...listed but do not have an associated MME conversion factor", we keep
        /// buprenorphine present, with a 0 conversion factor.
        /// </summary>
        [ParseableEnum("buprenorphine", "buprenorphine")] 
        [ConversionFactor(UnitOfMeasureEnum.Milligram, "Film", 0)]
        [ConversionFactor(UnitOfMeasureEnum.Milligram, "Tablet", 0)]
        [ConversionFactor(UnitOfMeasureEnum.MicrogramPerHour, "Patch", 0)]
        [ConversionFactor(UnitOfMeasureEnum.Microgram, "Film", 0)]
        Buprenorphine,

        /// <summary>
        /// Butorphanol
        /// </summary>
        [ParseableEnum("butorphanol", "butorphanol")]
        [ConversionFactor(UnitOfMeasureEnum.Milligram, 7)]
        Butorphanol,

        /// <summary>
        /// Codeine
        /// </summary>
        [ParseableEnum("codeine", "codeine")]
        [ConversionFactor(UnitOfMeasureEnum.Milligram, 0.15)]
        Codeine,

        /// <summary>
        /// Dihydrocodeine
        /// </summary>
        [ParseableEnum("dihydrocodeine", "dihydrocodeine")]
        [ConversionFactor(UnitOfMeasureEnum.Milligram, 0.25)]
        Dihydrocodeine,

        /// <summary>
        /// Fentanyl
        /// </summary>
        [ParseableEnum("fentanyl", "fentanyl")]
        [ConversionFactor(UnitOfMeasureEnum.Microgram, "Buccal, Tablet", 0.13)]
        [ConversionFactor(UnitOfMeasureEnum.Microgram, "Sublingual, Tablet", 0.13)]
        [ConversionFactor(UnitOfMeasureEnum.Microgram, "Lozenge", 0.13)]
        [ConversionFactor(UnitOfMeasureEnum.Microgram, "Troche", 0.13)]
        [ConversionFactor(UnitOfMeasureEnum.Microgram, "Film", 0.18)]
        [ConversionFactor(UnitOfMeasureEnum.Microgram, "Oral, Spray", 0.18)]
        [ConversionFactor(UnitOfMeasureEnum.Microgram, "Nasal, Spray", 0.16)]
        // From the 2019 PDF: "In other words, the conversion factor not accounting for days of use would be 60/25 or 2.4"
        [ConversionFactor(UnitOfMeasureEnum.Microgram, "Patch", 2.4)]
        Fentanyl,

        /// <summary>
        /// Hydrocodone
        /// </summary>
        [ParseableEnum("hydrocodone", "hydrocodone")]
        [ConversionFactor(UnitOfMeasureEnum.Milligram, 1)]
        Hydrocodone,

        /// <summary>
        /// Hydromorphone
        /// </summary>
        [ParseableEnum("hydromorphone", "hydromorphone")]
        [ConversionFactor(UnitOfMeasureEnum.Milligram, 4)]
        Hydromorphone,

        /// <summary>
        /// Levorphanol
        /// </summary>
        [ParseableEnum("levorphanol", "levorphanol")]
        [ConversionFactor(UnitOfMeasureEnum.Milligram, 11)]
        Levorphanol,

        /// <summary>
        /// Meperidine
        /// </summary>
        [ParseableEnum("meperidine", "meperidine")]
        [ConversionFactor(UnitOfMeasureEnum.Milligram, 0.1)]
        Meperidine,

        /// <summary>
        /// Methadone
        /// </summary>
        [ParseableEnum("methadone", "methadone")]
        [ConversionFactor(UnitOfMeasureEnum.Milligram, double.MinValue, 20, 4)]
        [ConversionFactor(UnitOfMeasureEnum.Milligram, 20, 40, 8)]
        [ConversionFactor(UnitOfMeasureEnum.Milligram, 40, 60, 10)]
        [ConversionFactor(UnitOfMeasureEnum.Milligram, 60, double.MaxValue, 12)]
        Methadone,

        /// <summary>
        /// Morphine
        /// </summary>
        [ParseableEnum("morphine", "morphine")]
        [ConversionFactor(UnitOfMeasureEnum.Milligram, 1)]
        Morphine,

        /// <summary>
        /// Opium
        /// </summary>
        [ParseableEnum("opium", "opium")]
        [ConversionFactor(UnitOfMeasureEnum.Milligram, 1)]
        Opium,

        /// <summary>
        /// Oxycodone
        /// </summary>
        [ParseableEnum("oxycodone", "oxycodone")]
        [ConversionFactor(UnitOfMeasureEnum.Milligram, 1.5)]
        Oxycodone,

        /// <summary>
        /// Oxymorphone
        /// </summary>
        [ParseableEnum("oxymorphone", "oxymorphone")]
        [ConversionFactor(UnitOfMeasureEnum.Milligram, 3)]
        Oxymorphone,

        /// <summary>
        /// Pentazocine
        /// </summary>
        [ParseableEnum("pentazocine", "pentazocine")]
        [ConversionFactor(UnitOfMeasureEnum.Milligram, 0.37)]
        Pentazocine,

        /// <summary>
        /// Tapentadol
        /// </summary>
        [ParseableEnum("tapentadol", "tapentadol")]
        [ConversionFactor(UnitOfMeasureEnum.Milligram, 0.4)]
        Tapentadol,

        /// <summary>
        /// Tramadol
        /// </summary>
        [ParseableEnum("tramadol", "tramadol")]
        [ConversionFactor(UnitOfMeasureEnum.Milligram, 0.1)]
        Tramadol
    }
}
