using System;
using System.Collections.Generic;
using System.Reflection;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Services;

namespace PracticeFusion.MmeCalculator.UnitTests.Services.ParsingTests
{
    [TestClass]
    public class MmeCalculatorTests
    {
        private readonly IMmeCalculator
            _mmeCalculator = new Core.Services.MmeCalculator();

        private static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[]
                {
                    1, OpioidEnum.Buprenorphine, 1m, 1m, UnitOfMeasureEnum.MicrogramPerHour, UnitOfMeasureEnum.MicrogramPerHour,
                    new [] {FormEnum.Patch}, 0m, 0m
                },
                new object[]
                {
                    2, OpioidEnum.Buprenorphine, 1m, 1m, UnitOfMeasureEnum.Milligram, UnitOfMeasureEnum.Milligram, new [] {FormEnum.Tablet}, 0m, 0m
                },
                new object[]
                {
                    3, OpioidEnum.Fentanyl, 100m, 1m, UnitOfMeasureEnum.Microgram, UnitOfMeasureEnum.Microgram, new [] {FormEnum.Tablet}, 2.4m,
                    2.4m
                },
                new object[]
                {
                    3, OpioidEnum.Fentanyl, 100m, 1m, UnitOfMeasureEnum.Microgram, UnitOfMeasureEnum.Microgram, new [] {FormEnum.Sublingual, FormEnum.Tablet}, 0.13m,
                    0.13m
                },
                new object[]
                {
                    4, OpioidEnum.Fentanyl, 100m, 1m, UnitOfMeasureEnum.Microgram, UnitOfMeasureEnum.Microgram, new [] {FormEnum.Patch}, 2.4m, 2.4m
                },
                new object[]
                {
                    5, OpioidEnum.Methadone, 1m, 1m, UnitOfMeasureEnum.Milligram, UnitOfMeasureEnum.Milligram, new [] {FormEnum.Dose}, 4m, 4m
                },
                new object[]
                {
                    6, OpioidEnum.Methadone, 1m, 21m, UnitOfMeasureEnum.Milligram, UnitOfMeasureEnum.Milligram, new [] {FormEnum.Dose}, 8m, 168m
                },
                new object[]
                {
                    7, OpioidEnum.Methadone, 1m, 41m, UnitOfMeasureEnum.Milligram, UnitOfMeasureEnum.Milligram, new [] {FormEnum.Dose}, 10m, 410m
                },
                new object[]
                {
                    8, OpioidEnum.Methadone, 1m, 61m, UnitOfMeasureEnum.Milligram, UnitOfMeasureEnum.Milligram, new [] {FormEnum.Dose}, 12m, 732m
                },

                // sig: total daily dose of 61mcg of methadone per day is < 20mg/day, conversion factor 4: 0.244 MME
                new object[]
                {
                    9, OpioidEnum.Methadone, 1m, 61m, UnitOfMeasureEnum.Milligram, UnitOfMeasureEnum.Microgram, new [] {FormEnum.Dose}, 4m, 0.244m
                },
            };

        [DataTestMethod]
        [DynamicData(nameof(TestData), DynamicDataDisplayName = "DisplayName")]
        public void LookupConversionFactorTest(
            int id,
            OpioidEnum opioid,
            decimal opioidStrength,
            decimal dosesPerDay,
            UnitOfMeasureEnum uom,
            UnitOfMeasureEnum sigUom,
            FormEnum[] forms,
            decimal expectedFactor,
            decimal maximumMmePerDay)
        {
            Form formEntity = new Form() { ValueEnums = new List<FormEnum>(forms) };

            UnitOfMeasure sigUomEntity = new UnitOfMeasure() { ValueEnum = sigUom };
            DoseUnit doseUnit = new DoseUnit() { Form = formEntity, UnitOfMeasure = sigUomEntity };
            Dose dose = new Dose() { MaxDose = dosesPerDay, MinDose = dosesPerDay, DoseUnit = doseUnit };

            var medComponent = new MedicationComponent()
            {
                Opioid = new Opioid() { ValueEnum = opioid },
                Name = Enum.GetName(typeof(OpioidEnum), opioid),
                IsOpioid = true,
                Strength = opioidStrength,
                UnitOfMeasure = new UnitOfMeasure() { ValueEnum = uom },
                Form = formEntity
            };

            var result = _mmeCalculator.Calculate(medComponent, dose, null);
            result.OpioidConversionFactor.Should().Be(expectedFactor);
            result.MaximumMmePerDay.Should().Be(maximumMmePerDay);
        }

        public static string DisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null)
            {
                var opioid = new Opioid()
                {
                    ValueEnum = (OpioidEnum)data[1]
                };

                var medComponent = new MedicationComponent()
                {
                    Opioid = opioid,
                    Name = opioid.ToString(),
                    IsOpioid = true,
                    Strength = decimal.Parse(data[2].ToString() ?? throw new InvalidOperationException()),
                    UnitOfMeasure = new UnitOfMeasure() { ValueEnum = (UnitOfMeasureEnum)data[5] },
                    Form = new Form() { ValueEnums = new List<FormEnum>((FormEnum[])data[6])}
                };
                return $"{methodInfo.Name} ({data[0]} : {data[1]} : {medComponent} {medComponent.Form})";
            }

            return null;
        }
    }
}
