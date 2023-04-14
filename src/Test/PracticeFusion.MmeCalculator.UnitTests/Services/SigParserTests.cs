using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PracticeFusion.MmeCalculator.Core.Messages;
using PracticeFusion.MmeCalculator.Core.Services;

namespace PracticeFusion.MmeCalculator.UnitTests.Services
{
    [TestClass]
    public class SigParserTests
    {

        [TestMethod]
        public void WhenParsingSigStrictWillReturnSigSuggestions()
        {
            var sigParser = new SigParser();
            var response = sigParser.ParseStrict("take every");
            response.SigSuggestions.Should().Contain(new List<string>{"doseVal", "rangeNumericValueWithUOM"});
        }

        [TestMethod]
        public void CalculateWithMissingRequestPropertiesWillReturnAnEmptyResult()
        {
            var calculator = new Calculator(
                MoqServices.Logger<Calculator>().Object,
                MoqServices.DistributedCache.Object,
                MoqServices.MedicationParser.Object,
                MoqServices.SigParser.Object,
                MoqServices.MmeCalculator.Object,
                MoqServices.QualityAnalyzer.Object);

            var requestWithNullItems = new CalculationRequest() { RequestId = Guid.NewGuid().ToString() };
            var response = calculator.Calculate(requestWithNullItems);
            response.CalculatedResultAnalysis.Should().BeEquivalentTo(new CalculatedResultAnalysis());
            response.ParsedResults.Should().BeEquivalentTo(new List<ParsedResult>());
            response.RequestId.Should().BeEquivalentTo(requestWithNullItems.RequestId);
        }
    }
}
