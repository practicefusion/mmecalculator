using System;
using System.Collections.Generic;
using System.Reflection;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Services;

namespace PracticeFusion.MmeCalculator.UnitTests.Services
{
    [TestClass]
    public class OpioidConversionFactorTests
    {
        private readonly IOpioidConversionFactor _conversionFactor = DefaultServices.OpioidConversionFactor;

        private static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[] { OpioidEnum.Buprenorphine, 1m, UnitOfMeasureEnum.Milligram, new[] {FormEnum.Tablet}, 0m },
                new object[] { OpioidEnum.Buprenorphine, 1m, UnitOfMeasureEnum.Milligram, new[] {FormEnum.Film }, 0m },
                new object[] { OpioidEnum.Buprenorphine, 1m, UnitOfMeasureEnum.MicrogramPerHour, new[] {FormEnum.Patch }, 0m },
                new object[] { OpioidEnum.Buprenorphine, 1m, UnitOfMeasureEnum.MicrogramPerHour, new[] {FormEnum.Transdermal }, 0m },
                new object[] { OpioidEnum.Buprenorphine, 1m, UnitOfMeasureEnum.Microgram, new[] {FormEnum.Film }, 0m },
                new object[] { OpioidEnum.Butorphanol, 1m, UnitOfMeasureEnum.Milligram, new[] {FormEnum.Dose }, 7m },
                new object[] { OpioidEnum.Codeine, 1m, UnitOfMeasureEnum.Milligram, new[] {FormEnum.Dose }, 0.15m },
                new object[] { OpioidEnum.Dihydrocodeine, 1m, UnitOfMeasureEnum.Milligram, new[] {FormEnum.Dose }, 0.25m },
                new object[] { OpioidEnum.Fentanyl, 100m, UnitOfMeasureEnum.Microgram, new[] {FormEnum.Buccal, FormEnum.Tablet }, 0.13m },
                new object[] { OpioidEnum.Fentanyl, 100m, UnitOfMeasureEnum.Microgram, new[] {FormEnum.Sublingual, FormEnum.Tablet }, 0.13m },
                new object[] { OpioidEnum.Fentanyl, 100m, UnitOfMeasureEnum.Microgram, new[] {FormEnum.Lozenge }, 0.13m },
                new object[] { OpioidEnum.Fentanyl, 100m, UnitOfMeasureEnum.Microgram, new[] {FormEnum.Film }, 0.18m },
                new object[] { OpioidEnum.Fentanyl, 100m, UnitOfMeasureEnum.Microgram, new[] {FormEnum.Oral, FormEnum.Spray}, 0.18m },
                new object[] { OpioidEnum.Fentanyl, 100m, UnitOfMeasureEnum.Microgram, new[] {FormEnum.Nasal, FormEnum.Spray}, 0.16m },
                new object[] { OpioidEnum.Fentanyl, 100m, UnitOfMeasureEnum.Microgram, new[] {FormEnum.Patch }, 2.4m },
                new object[] { OpioidEnum.Hydrocodone, 1m, UnitOfMeasureEnum.Milligram, new[] {FormEnum.Dose }, 1m },
                new object[] { OpioidEnum.Hydromorphone, 1m, UnitOfMeasureEnum.Milligram, new[] {FormEnum.Dose }, 4m },
                new object[] { OpioidEnum.Levorphanol, 1m, UnitOfMeasureEnum.Milligram, new[] {FormEnum.Dose }, 11m },
                new object[] { OpioidEnum.Meperidine, 1m, UnitOfMeasureEnum.Milligram, new[] {FormEnum.Dose }, 0.1m },
                new object[] { OpioidEnum.Methadone, 1m, UnitOfMeasureEnum.Milligram, new[] {FormEnum.Dose }, 4m },
                new object[] { OpioidEnum.Methadone, 20m, UnitOfMeasureEnum.Milligram, new[] {FormEnum.Dose }, 4m },
                new object[] { OpioidEnum.Methadone, 21m, UnitOfMeasureEnum.Milligram, new[] {FormEnum.Dose }, 8m },
                new object[] { OpioidEnum.Methadone, 40m, UnitOfMeasureEnum.Milligram, new[] {FormEnum.Dose }, 8m },
                new object[] { OpioidEnum.Methadone, 41m, UnitOfMeasureEnum.Milligram, new[] {FormEnum.Dose }, 10m },
                new object[] { OpioidEnum.Methadone, 60m, UnitOfMeasureEnum.Milligram, new[] {FormEnum.Dose }, 10m },
                new object[] { OpioidEnum.Methadone, 61m, UnitOfMeasureEnum.Milligram, new[] {FormEnum.Dose }, 12m },
                new object[] { OpioidEnum.Morphine, 1m, UnitOfMeasureEnum.Milligram, new[] {FormEnum.Dose }, 1m },
                new object[] { OpioidEnum.Opium, 1m, UnitOfMeasureEnum.Milligram, new[] {FormEnum.Dose }, 1m },
                new object[] { OpioidEnum.Oxycodone, 1m, UnitOfMeasureEnum.Milligram, new[] {FormEnum.Dose }, 1.5m },
                new object[] { OpioidEnum.Oxymorphone, 1m, UnitOfMeasureEnum.Milligram, new[] {FormEnum.Dose }, 3m },
                new object[] { OpioidEnum.Pentazocine, 1m, UnitOfMeasureEnum.Milligram, new[] {FormEnum.Dose }, 0.37m },
                new object[] { OpioidEnum.Tapentadol, 1m, UnitOfMeasureEnum.Milligram, new[] {FormEnum.Dose }, 0.4m },
                new object[] { OpioidEnum.Tramadol, 1m, UnitOfMeasureEnum.Milligram, new[] {FormEnum.Dose }, 0.1m },

                // different UOMs (millis->micros)
                new object[] { OpioidEnum.Tramadol, 1m * 1000, UnitOfMeasureEnum.Microgram, new[] {FormEnum.Dose }, 0.1m / 1000 },
                new object[] { OpioidEnum.Hydrocodone, 1m * 1000, UnitOfMeasureEnum.Microgram, new[] {FormEnum.Dose }, 1m / 1000 },
                new object[] { OpioidEnum.Methadone, 61m * 1000, UnitOfMeasureEnum.Microgram, new[] {FormEnum.Dose }, 12m / 1000 },

                // different UOMs (micros->millis)
                new object[] { OpioidEnum.Fentanyl, 100m / 1000, UnitOfMeasureEnum.Milligram, new[] {FormEnum.Nasal, FormEnum.Spray}, 0.16m * 1000 },
            };

        [DataTestMethod]
        [DynamicData(nameof(TestData), DynamicDataDisplayName = "DisplayName")]
        public void LookupConversionFactorTest(
            OpioidEnum opioid,
            decimal maxDailyDose,
            UnitOfMeasureEnum uom,
            FormEnum[] formEnums,
            decimal expectedFactor)
        {
            decimal factor = _conversionFactor.LookupConversionFactor(
                opioid,
                maxDailyDose,
                uom,
                new Form() { ValueEnums = new List<FormEnum>(formEnums) },
                null);

            factor.Should().Be(expectedFactor);
        }

        public static string DisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null)
            {
                var opioid = new Opioid()
                {
                    ValueEnum = (OpioidEnum)data[0]
                };

                var medComponent = new MedicationComponent()
                {
                    Opioid = opioid,
                    Name = opioid.ToString(),
                    IsOpioid = true,
                    Strength = decimal.Parse(data[1].ToString() ?? throw new InvalidOperationException()),
                    UnitOfMeasure = new UnitOfMeasure() { ValueEnum = (UnitOfMeasureEnum)data[2] },
                    Form = new Form() { ValueEnums = new List<FormEnum>((FormEnum[])data[3]) }
                };
                return $"{methodInfo.Name} ({data[0]} : {medComponent} {medComponent.Form})";
            }

            return null;
        }
    }
}
