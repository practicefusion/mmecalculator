using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeFusion.MmeCalculator.Core.Messages;
using PracticeFusion.MmeCalculator.Core.Services;
using PracticeFusion.MmeCalculator.LocalRxNormResolver;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PracticeFusion.MmeCalculator.UnitTests.Services.ParsingTests
{
    [TestClass]
    public class MedicationParserTests
    {
        private readonly IMedicationParser _medicationParser = new MedicationParser(new Client());

        private static IEnumerable<object[]> TestData =>
            LocalData.Codes.Select(x => new[] { x.Key, x.Value }).Where((x, i) => i % 5 == 0);

        [DataTestMethod]
        [DynamicData(nameof(TestData), DynamicDataDisplayName = "DisplayName")]
        public void RoundTripTests(string rxCui, string drugName)
        {
            RoundTripTest(rxCui, drugName);
        }

        public static string DisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null)
            {
                return string.Format("{0} ({1})", methodInfo.Name, data[1]);
            }

            return null;
        }

        // friendlyName is used by the test framework as the display name of the test
        private void RoundTripTest(string rxCui, string friendlyName)
        {
            // first pass from rxcui
            var drugName = _medicationParser.GetDrugNameFromRxCui(rxCui);
            ParsedMedication result = _medicationParser.Parse(rxCui, drugName);
            result.RxCui.Should().Be(rxCui);
            result.OriginalMedication.Should().NotBeNullOrEmpty();
            result.PreprocessedMedication.Should().NotBeNullOrEmpty();
            result.MedicationComponents.Should().NotBeNull();
        }
    }
}