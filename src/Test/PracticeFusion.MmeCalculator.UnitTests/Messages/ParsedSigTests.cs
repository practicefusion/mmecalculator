using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeFusion.MmeCalculator.Core.Messages;
using PracticeFusion.MmeCalculator.Core.Services;

namespace PracticeFusion.MmeCalculator.UnitTests.Messages
{
    [TestClass]
    public class ParsedSigTests
    {
        private readonly ISigParser _sigParser = DefaultServices.SigParser;

        [TestMethod]
        public void ParsedSigIndicatesItContainsLatinWhenLatinIsPresentInRoute()
        {
            ParsedSig result = _sigParser.Parse("take 1 tablet po twice a day as needed for pain");
            result.ContainsLatinAbbreviations.Should().BeTrue();
        }

        [TestMethod]
        public void ParsedSigIndicatesItContainsLatinWhenLatinIsPresentInFrequency()
        {
            ParsedSig result = _sigParser.Parse("take 1 tablet by mouth bid as needed for pain");
            result.ContainsLatinAbbreviations.Should().BeTrue();
        }

        [TestMethod]
        public void ParsedSigIndicatesItContainsLatinWhenLatinIsPresentInIndication()
        {
            ParsedSig result = _sigParser.Parse("take 1 tablet by mouth twice a day prn pain");
            result.ContainsLatinAbbreviations.Should().BeTrue();
        }

        [TestMethod]
        public void ParsedSigIndicatesItDoseNotContainLatinWhenLatinIsNotPresent()
        {
            ParsedSig result = _sigParser.Parse("take 1 tablet by mouth twice a day as needed for pain");
            result.ContainsLatinAbbreviations.Should().BeFalse();
        }
    }
}