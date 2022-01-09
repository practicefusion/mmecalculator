using System;
using System.Collections.Generic;
using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Messages;

namespace PracticeFusion.MmeCalculator.UnitTests
{
    internal class DefaultEntities
    {
        public static CalculatedResult CalculatedResult => new()
        {
            CalculatedResultAnalysis = CalculatedResultAnalysis,
            ParsedResults = new List<ParsedResult>() { ParsedResult },
            RequestId = Guid.NewGuid().ToString()
        };

        public static CalculatedResult IncompleteCalculatedResult => new()
        {
            CalculatedResultAnalysis = CalculatedResultAnalysis,
            ParsedResults = new List<ParsedResult>() { IncompleteParsedResult },
            RequestId = Guid.NewGuid().ToString()
        };

        public static CalculatedResultAnalysis CalculatedResultAnalysis => new()
        {
            Confidence = ConfidenceEnum.High,
            ConfidenceReasons = new List<string>(),
            MaximumMmePerDay = 22.5m,
            Opioids = new List<OpioidAnalysis>() { OpioidAnalysis }
        };

        public static Dose MaximumDailyDose => new()
        {
            MinDose = 2,
            MaxDose = 2,
            Complex = false,
            DoseUnit = new DoseUnit() { Form = Form(FormEnum.Tablet) }
        };

        public static OpioidAnalysis OpioidAnalysis => new()
        {
            ConversionFactor = 1.5m,
            Form = new Form() { ValueEnums = new List<FormEnum>() { FormEnum.Tablet } },
            MaximumMmePerDay = 12.0m,
            Opioid = OpioidEnum.Oxycodone,
            TotalDailyDose = 15.0m,
            TotalDailyDoseUom = UnitOfMeasureEnum.Milligram,
            RelatedResults = new List<string>() { "1" }
        };

        public static ParsedResult ParsedResult => new()
        {
            Confidence = ConfidenceEnum.High,
            ConfidenceReasons = new List<string>(),
            MaximumDailyDose = MaximumDailyDose,
            MaximumMmePerDay = 22.5m,
            ParsedMedication = ParsedMedication,
            ParsedSig = ParsedSig,
            RequestItemId = "1"
        };

        public static ParsedResult IncompleteParsedResult => new()
        {
            Confidence = ConfidenceEnum.High,
            ConfidenceReasons = new List<string>(),
            MaximumDailyDose = MaximumDailyDose,
            MaximumMmePerDay = 22.5m,
            ParsedMedication = ParsedMedication,
            ParsedSig = IncompleteParsedSig,
            RequestItemId = "1"
        };

        public static ParsedMedication ParsedMedication => new()
        {
            Confidence = ConfidenceEnum.High,
            ConfidenceReasons = new List<string>(),
            MedicationComponents = new List<MedicationComponent>() { MedicationComponent },
            OriginalMedication = "Acetaminophen 500 MG / Oxycodone Hydrochloride 7.5 MG Oral Tablet [Percocet]",
            PreprocessedMedication = "acetaminophen 500 mg / oxycodone hydrochloride 7.5 mg oral tablet percocet",
            RxCui = "1049647"
        };

        public static MedicationComponent MedicationComponent => new()
        {
            Confidence = ConfidenceEnum.High,
            ConfidenceReasons = new List<string>(),
            Form = Form(FormEnum.Tablet),
            IsOpioid = true,
            Name = "oxycodone",
            Opioid = Opioid(OpioidEnum.Oxycodone),
            Strength = 7.5m,
            UnitOfMeasure = UnitOfMeasure(UnitOfMeasureEnum.Milligram),
            OpioidConversionFactor = 1.5m
        };

        public static ParsedSig ParsedSig => new()
        {
            Confidence = ConfidenceEnum.High,
            ConfidenceReasons = new List<string>(),
            OriginalSig = "take 1 tabs bid prn chronic pain",
            PreprocessedSig = "take 1 tabs bid prn chronic pain",
            MaximumDosage = MaximumDailyDose,
            Dosages = new List<Dosage>() { Dosage }
        };

        public static ParsedSig IncompleteParsedSig => new()
        {
            Confidence = ConfidenceEnum.High,
            ConfidenceReasons = new List<string>(),
            OriginalSig = "take 1 tabs bid prn chronic pain with some extra text",
            PreprocessedSig = "take 1 tabs bid prn chronic pain with some extra text",
            MaximumDosage = MaximumDailyDose,
            Dosages = new List<Dosage>() { Dosage }
        };

        public static Dosage Dosage => new()
        {
            // "1 tablet 2 times every day as needed for chronic pain"
            Confidence = ConfidenceEnum.High,
            ConfidenceReasons = new List<string>(),
            Dose = Dose,
            Frequency = Frequency,
            IndicationForUse = AsNeeded,
            Index = 0,
            Length = 32
        };

        public static Dose Dose => new()
        {
            MinDose = 1,
            MaxDose = 1,
            Complex = false,
            DoseUnit = new DoseUnit() { Form = Form(FormEnum.Tablet) }
        };

        public static Frequency Frequency => new()
        {
            Intervals = new List<Interval>()
            {
                new()
                {
                    Freq = 2,
                    FreqMax = 2,
                    Period = 1,
                    PeriodMax = 1,
                    PeriodUnit = PeriodEnum.Day,
                }
            }
        };

        public static IndicationForUse AsNeeded => new()
        {
            IndicationPrecursor = "as needed for",
            Indication = "chronic pain"
        };

        public static MmeCalculatorResult MmeCalculatorResult => new()
        {
            MaximumMmePerDay = 22.50m,
            OpioidConversionFactor = 1.5m,
            OpioidMaximumDailyDose = 15.0m
        };

        public static Form Form(FormEnum form) => new()
        {
            ValueEnums = new List<FormEnum>() {form}
        };

        public static Opioid Opioid(OpioidEnum opioid) => new()
        {
            ValueEnum = opioid
        };

        public static UnitOfMeasure UnitOfMeasure(UnitOfMeasureEnum uom) => new()
        {
            ValueEnum = uom
        };
    }
}
