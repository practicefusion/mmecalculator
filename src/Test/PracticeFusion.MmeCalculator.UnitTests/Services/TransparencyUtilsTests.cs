using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeFusion.MmeCalculator.UnitTests.Services
{
    [TestClass]
    public class TransparencyUtilsTests
    {
        private static ILogger<TransparencyUtils> _logger = DefaultServices.LoggerFactory.CreateLogger<TransparencyUtils>();
        private static IOpioidConversionFactor _opioidConversionFactor = DefaultServices.OpioidConversionFactor;

        [TestMethod]
        public void TransparencyUtilsTest()
        {
            var transparencyUtils =
                new TransparencyUtils(_logger, _opioidConversionFactor);

            transparencyUtils.Should().NotBeNull();
        }

        [TestMethod()]
        public void AllDetailsTest()
        {
            var transparencyUtils =
                new TransparencyUtils(_logger, _opioidConversionFactor);

            var results = transparencyUtils.AllDetails();

            // Gloss over the results to be sure there's something there.
            results.VersionInformation.Should().HaveCount(2);
            results.ReferenceInformation.Should().HaveCount(1);
            results.Opioids.Should().HaveCount(17);
            results.Opioids[OpioidEnum.Fentanyl].Should().HaveCount(8);
        }

        [TestMethod()]
        public void GetFileVersionInfoTest()
        {
            TransparencyUtils.GetFileVersionInfo().Should().NotBeNull();
        }
    }
}