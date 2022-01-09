using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeFusion.MmeCalculator.Core.Messages;
using PracticeFusion.MmeCalculator.Core.Services;

namespace PracticeFusion.MmeCalculator.SystemTests
{
    // assembly marked as parallelize for tests, method level
    [TestClass]
    public class ParallelParseSigTests
    {
        private readonly ICalculator _calculator = DefaultServices.Calculator;

        private static IEnumerable<object[]> TestData => File.ReadLines("sig-test-data.txt")
            .Select(x => new object[] {new SigTestItem(x)});


        [DataTestMethod]
        [DynamicData(nameof(TestData), DynamicDataDisplayName = "DisplayName")]
        public void BasicTests(SigTestItem testItem)
        {
            // parse the sig
            ParsedSig result = _calculator.ParseSig(testItem.Sig);

            // ensure the key values are there
            if (testItem.ShouldPass)
            {
                result.Confidence.Should().Be(testItem.Confidence);
                result.ConfidenceReasons.Should().BeEmpty();
                result.HumanReadable.Should().Be(testItem.Expected);
                result.MaximumDosage.Should().NotBeNull();
                result.MaximumDosage!.HumanReadable.Should().Be(testItem.MaximumDailyDosage);
            }
            else
            {
                // check to make sure it failed correctly
                result.Confidence.Should().Be(testItem.Confidence);
                result.ConfidenceReasons.Should().BeEquivalentTo(testItem.ExpectedErrorMessages);
            }
        }

        public static string DisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null && data[0] is SigTestItem sti)
            {
                return $"{methodInfo.Name} ([SHOULD {(sti.ShouldPass ? "PASS" : "FAIL")}] {sti.Id} : {sti.Sig})";
            }

            return null;
        }
    }
}
