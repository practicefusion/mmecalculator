using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeFusion.MmeCalculator.Core.Messages;
using PracticeFusion.MmeCalculator.Core.Services;
using System.Collections.Generic;

namespace PracticeFusion.MmeCalculator.UnitTests.Services
{
    [TestClass]
    public class JsonUtilsTests
    {
        private static CalculatedResult _entity;

        private static CalculationRequest BasicCalculationRequest => new()
        {
            RequestId = "1",
            CalculationItems = new List<CalculationItem>
            {
                new()
                {
                    RequestItemId = "1",
                    RxCui = "261106",
                    Sig = "1 tablet q 4-6 hours with water prn pain x 30 days"
                }
            }
        };

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            ICalculator calculator = DefaultServices.Calculator;
            _entity = calculator.Calculate(BasicCalculationRequest);
        }

        [TestMethod]
        public void SerializedEntityIsValid()
        {
            var jsonString = JsonUtils.Serialize(_entity);
            var converted = JsonUtils.Deserialize<CalculatedResult>(jsonString);
            converted.Should().BeEquivalentTo(_entity);
        }

        [TestMethod]
        public void SerializedEntityIsFormatted()
        {
            var jsonString = JsonUtils.Serialize(_entity);
            jsonString.Should().Contain("\n");
        }

        [TestMethod]
        public void SerializedEntityContainsEnumsAsStrings()
        {
            var jsonString = JsonUtils.Serialize(_entity);
            jsonString.Should().Contain("WithLiquid");
        }

        [TestMethod]
        public void UnformattedSerializedStringCanBeFormatted()
        {
            var jsonString = JsonUtils.Serialize(_entity, false);
            jsonString.Should().NotContain("\n");
            var formatted = JsonUtils.JsonFormat(jsonString);
            formatted.Should().Contain("\n");
        }

        [TestMethod]
        public void SerializedEntitiesShouldContainReadOnlyProperties()
        {
            var anonymous = new { Name = "Value" };
            var jsonString = JsonUtils.Serialize(anonymous);
            jsonString.Should().Contain("Name");
        }

        [TestMethod]
        public void DebugIncludesReadOnlyProperties()
        {
            var anonymous = new { Name = "Value" };
            var debugString = JsonUtils.Debug(anonymous);
            debugString.Should().Contain("Name");
        }

        [TestMethod]
        public void UnformattedSerializedStringIsValidEntityAfterFormatting()
        {
            var jsonString = JsonUtils.Serialize(_entity, false);
            jsonString.Should().NotContain("\n");
            var formatted = JsonUtils.JsonFormat(jsonString);
            formatted.Should().Contain("\n");
            var converted = JsonUtils.Deserialize<CalculatedResult>(formatted);
            converted.Should().BeEquivalentTo(_entity);
        }

        [TestMethod]
        public void SerializedEntityCanBeUnformatted()
        {
            var jsonString = JsonUtils.Serialize(_entity, false);
            jsonString.Should().NotContain("\n");
        }

        [TestMethod]
        public void SerializedToUtf8BytesEntityIsValid()
        {
            var bytes = JsonUtils.SerializeToUtf8Bytes(_entity);
            var converted = JsonUtils.DeserializeFromUtf8Bytes<CalculatedResult>(bytes);
            converted.Should().BeEquivalentTo(_entity);
        }
    }
}