using System;
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
    public class ParallelCalculatorTests
    {
        private readonly ICalculator _calculator = DefaultServices.Calculator;

        private static IEnumerable<object[]> TestData => File.ReadLines("calculator-test-data.txt")
            .Select(x => new object[] {new CalculatorTestItem(x)});


        [DataTestMethod]
        [DynamicData(nameof(TestData), DynamicDataDisplayName = "DisplayName")]
        public void BasicTests(CalculatorTestItem testItem)
        {
            CalculationRequest request = new CalculationRequest() { RequestId = testItem.Id };
            request.CalculationItems.Add(
                new CalculationItem()
                    { RequestItemId = testItem.Id, RxCui = testItem.RxCui, Sig = testItem.Instruction });

            // calculate the request
            CalculatedResult result = _calculator.Calculate(request);

            // ensure the key values are there
            result?.CalculatedResultAnalysis?.MaximumMmePerDay.Should().BeGreaterThan(0);

            // ensure the result is approximately equal (within tolerance)
            Math.Abs(result.CalculatedResultAnalysis.MaximumMmePerDay - testItem.ExpectedMme).Should().BeLessOrEqualTo(0.001M);
        }

        public static string DisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null && data[0] is CalculatorTestItem cti)
            {
                return $"{methodInfo.Name} ({cti.Id} : {cti.Instruction})";
            }

            return null;
        }
    }
}
