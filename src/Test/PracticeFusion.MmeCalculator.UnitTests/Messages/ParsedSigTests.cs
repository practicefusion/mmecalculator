using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeFusion.MmeCalculator.Core.Services;

namespace PracticeFusion.MmeCalculator.UnitTests.Messages
{
    [TestClass]
    public  class ParsedSigTests
    {
        private readonly ISigParser _sigParser = DefaultServices.SigParser;

        [TestMethod]
        public void ParsedSigIndicatesItContainsLatinWhenLatinIsPresentInRoute()
        {
            var result = _sigParser.Parse("take 1 tablet po twice a day as needed for pain");
            result.ContainsLatinAbbreviations.Should().BeTrue();
        }

        [TestMethod]
        public void ParsedSigIndicatesItContainsLatinWhenLatinIsPresentInFrequency()
        {
            var result = _sigParser.Parse("take 1 tablet by mouth bid as needed for pain");
            result.ContainsLatinAbbreviations.Should().BeTrue();
        }

        [TestMethod]
        public void ParsedSigIndicatesItContainsLatinWhenLatinIsPresentInIndication()
        {
            var result = _sigParser.Parse("take 1 tablet by mouth twice a day prn pain");
            result.ContainsLatinAbbreviations.Should().BeTrue();
        }

        [TestMethod]
        public void ParsedSigIndicatesItDoseNotContainLatinWhenLatinIsNotPresent()
        {
            var result = _sigParser.Parse("take 1 tablet by mouth twice a day as needed for pain");
            result.ContainsLatinAbbreviations.Should().BeFalse();
        }

    }
}
