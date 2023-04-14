using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PracticeFusion.MmeCalculator.Core.Messages;
using PracticeFusion.MmeCalculator.Core.Services;
using System;
using System.Collections.Generic;

namespace PracticeFusion.MmeCalculator.UnitTests.Services
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void ThrowsExceptionWhenArgumentsAreNull()
        {
            var calculator = new Calculator(
                MoqServices.Logger<Calculator>().Object,
                MoqServices.DistributedCache.Object,
                MoqServices.MedicationParser.Object,
                MoqServices.SigParser.Object,
                MoqServices.MmeCalculator.Object,
                MoqServices.QualityAnalyzer.Object);

            calculator.Invoking(x => x.Calculate(null)).Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void WhenParsingSigWillParseAndAnalyze()
        {
            Mock<ISigParser> sigParserMock = MoqServices.SigParser;
            sigParserMock.Reset();
            sigParserMock.Setup(x => x.Parse(It.IsAny<string>())).Returns(new ParsedSig());

            Mock<IQualityAnalyzer> qualityAnalyzerMock = MoqServices.QualityAnalyzer;
            qualityAnalyzerMock.Reset();

            var calculator = new Calculator(
                MoqServices.Logger<Calculator>().Object,
                MoqServices.DistributedCache.Object,
                MoqServices.MedicationParser.Object,
                sigParserMock.Object,
                MoqServices.MmeCalculator.Object,
                qualityAnalyzerMock.Object);

            ParsedSig response = calculator.ParseSig("take 1 pill by mouth bid");

            sigParserMock.Verify(x => x.Parse(It.IsAny<string>()), Times.Once);
            sigParserMock.VerifyNoOtherCalls();

            qualityAnalyzerMock.Verify(x => x.AnalyzeParsedSig(response), Times.Once);
            qualityAnalyzerMock.VerifyNoOtherCalls();
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

            var requestWithNullItems = new CalculationRequest { RequestId = Guid.NewGuid().ToString() };
            CalculatedResult response = calculator.Calculate(requestWithNullItems);
            response.CalculatedResultAnalysis.Should().BeEquivalentTo(new CalculatedResultAnalysis());
            response.ParsedResults.Should().BeEquivalentTo(new List<ParsedResult>());
            response.RequestId.Should().BeEquivalentTo(requestWithNullItems.RequestId);
        }
    }
}