using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeFusion.MmeCalculator.Core.Messages;
using PracticeFusion.MmeCalculator.Core.Services;

namespace PracticeFusion.MmeCalculator.UnitTests.Services
{
    [TestClass]
    public class JsonUtilsTests
    {
        private static CalculatedResult _entity;

        private static CalculationRequest BasicCalculationRequest => new()
        {
            RequestId = "1",
            CalculationItems = new List<CalculationItem>()
            {
                new()
                {
                    RequestItemId = "1", RxCui = "261106",
                    Sig = "1 tablet q 4-6 hours with water prn pain x 30 days"
                }
            }
        };

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            var calculator = DefaultServices.Calculator;
            _entity = calculator.Calculate(BasicCalculationRequest);
        }

        [TestMethod]
        public void SerializedEntityIsValid()
        {
            string jsonString = JsonUtils.Serialize(_entity);
            var converted = JsonUtils.Deserialize<CalculatedResult>(jsonString);
            converted.Should().BeEquivalentTo(_entity);
        }

        [TestMethod]
        public void SerializedEntityIsFormatted()
        {
            string jsonString = JsonUtils.Serialize(_entity);
            jsonString.Should().Contain("\n");
        }

        [TestMethod]
        public void SerializedEntityContainsEnumsAsStrings()
        {
            string jsonString = JsonUtils.Serialize(_entity);
            jsonString.Should().Contain("WithLiquid");
        }

        [TestMethod]
        public void UnformattedSerializedStringCanBeFormatted()
        {
            string jsonString = JsonUtils.Serialize(_entity, false);
            jsonString.Should().NotContain("\n");
            string formatted = JsonUtils.JsonFormat(jsonString);
            formatted.Should().Contain("\n");
        }

        [TestMethod]
        public void SerializedEntitiesShouldContainReadOnlyProperties()
        {
            var anonymous = new { Name = "Value" };
            string jsonString = JsonUtils.Serialize(anonymous);
            jsonString.Should().Contain("Name");
        }

        [TestMethod]
        public void DebugIncludesReadOnlyProperties()
        {
            var anonymous = new { Name = "Value" };
            string debugString = JsonUtils.Debug(anonymous);
            debugString.Should().Contain("Name");
        }

        [TestMethod]
        public void UnformattedSerializedStringIsValidEntityAfterFormatting()
        {
            string jsonString = JsonUtils.Serialize(_entity, false);
            jsonString.Should().NotContain("\n");
            string formatted = JsonUtils.JsonFormat(jsonString);
            formatted.Should().Contain("\n");
            var converted = JsonUtils.Deserialize<CalculatedResult>(formatted);
            converted.Should().BeEquivalentTo(_entity);
        }

        [TestMethod]
        public void SerializedEntityCanBeUnformatted()
        {
            string jsonString = JsonUtils.Serialize(_entity, false);
            jsonString.Should().NotContain("\n");
        }

        [TestMethod]
        public void SerializedToUtf8BytesEntityIsValid()
        {
            byte[] bytes = JsonUtils.SerializeToUtf8Bytes(_entity);
            var converted = JsonUtils.DeserializeFromUtf8Bytes<CalculatedResult>(bytes);
            converted.Should().BeEquivalentTo(_entity);
        }

    }
}
