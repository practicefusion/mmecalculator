using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Messages;
using PracticeFusion.MmeCalculator.Core.Services;
using System.Collections.Generic;

namespace PracticeFusion.MmeCalculator.UnitTests.Services
{
    [TestClass]
    public class QualityAnalyzerTests
    {
        [TestMethod]
        public void DefaultCalculatedResultHasHighConfidence()
        {
            var qualityAnalyzer = new QualityAnalyzer(
                MoqServices.Logger<QualityAnalyzer>().Object,
                MoqServices.MmeCalculator.Object);
            CalculatedResult calculatedResult = DefaultEntities.CalculatedResult;
            qualityAnalyzer.AnalyzeCalculatedResult(calculatedResult);
            calculatedResult.CalculatedResultAnalysis.Confidence.Should().Be(ConfidenceEnum.High);
        }

        [TestMethod]
        public void IncompleteCalculatedResultHasNoConfidence()
        {
            var qualityAnalyzer = new QualityAnalyzer(
                MoqServices.Logger<QualityAnalyzer>().Object,
                MoqServices.MmeCalculator.Object);
            CalculatedResult calculatedResult = DefaultEntities.IncompleteCalculatedResult;
            qualityAnalyzer.AnalyzeCalculatedResult(calculatedResult);
            calculatedResult.CalculatedResultAnalysis.Confidence.Should().Be(ConfidenceEnum.None);
        }

        [TestMethod]
        public void NullParsedResultsReturnsNoConfidence()
        {
            var qualityAnalyzer = new QualityAnalyzer(
                MoqServices.Logger<QualityAnalyzer>().Object,
                MoqServices.MmeCalculator.Object);
            CalculatedResult calculatedResult = DefaultEntities.CalculatedResult;
            calculatedResult.ParsedResults = null;
            qualityAnalyzer.AnalyzeCalculatedResult(calculatedResult);
            calculatedResult.CalculatedResultAnalysis.Confidence.Should().Be(ConfidenceEnum.None);
        }

        [TestMethod]
        public void EmptyParsedResultsReturnsNoConfidence()
        {
            var qualityAnalyzer = new QualityAnalyzer(
                MoqServices.Logger<QualityAnalyzer>().Object,
                MoqServices.MmeCalculator.Object);
            CalculatedResult calculatedResult = DefaultEntities.CalculatedResult;
            calculatedResult.ParsedResults = new List<ParsedResult>();
            qualityAnalyzer.AnalyzeCalculatedResult(calculatedResult);
            calculatedResult.CalculatedResultAnalysis.Confidence.Should().Be(ConfidenceEnum.None);
        }

        [TestMethod]
        public void MissingCalculatedResultAnalysisCreated()
        {
            var qualityAnalyzer = new QualityAnalyzer(
                MoqServices.Logger<QualityAnalyzer>().Object,
                MoqServices.MmeCalculator.Object);
            CalculatedResult calculatedResult = DefaultEntities.CalculatedResult;
            calculatedResult.CalculatedResultAnalysis = null;
            qualityAnalyzer.AnalyzeCalculatedResult(calculatedResult);
            calculatedResult.CalculatedResultAnalysis.Should().NotBeNull();
        }

        [TestMethod]
        public void LowestConfidenceParsedResultSetsTheOverallConfidence()
        {
            var qualityAnalyzer = new QualityAnalyzer(
                MoqServices.Logger<QualityAnalyzer>().Object,
                MoqServices.MmeCalculator.Object);
            CalculatedResult calculatedResult = DefaultEntities.CalculatedResult;

            // no dosages should result in no confidence for the parsed result
            calculatedResult.ParsedResults[0].ParsedSig.Dosages = new List<Dosage>();

            qualityAnalyzer.AnalyzeCalculatedResult(calculatedResult);
            calculatedResult.CalculatedResultAnalysis.Confidence.Should().Be(ConfidenceEnum.None);
        }
    }
}