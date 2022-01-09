using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PracticeFusion.MmeCalculator.Core.Messages;
using PracticeFusion.MmeCalculator.Core.Services;

namespace PracticeFusion.MmeCalculator.UnitTests.Services
{
    [TestClass]
    public class QualityCheckTests
    {
        [TestMethod]
        public void IsTrueCheckLeavesConfidenceResultUnchangedWhenTrue()
        {
            Mock<IConfidence> mock = DefaultConfidenceResult();
            QualityCheck.IsTrue(true, ConfidenceEnum.None, mock.Object, null);
            Assert.AreEqual(ConfidenceEnum.High, mock.Object.Confidence);
            Assert.IsTrue(mock.Object.ConfidenceReasons.Count == 0);
        }

        [TestMethod]
        public void IsTrueCheckModifiesConfidenceResultWhenFalse()
        {
            Mock<IConfidence> mock = DefaultConfidenceResult();
            QualityCheck.IsTrue(false, ConfidenceEnum.None, mock.Object, "Reason");
            Assert.AreEqual(ConfidenceEnum.None, mock.Object.Confidence);
            Assert.IsTrue(mock.Object.ConfidenceReasons.Count == 1);
            Assert.AreEqual("Reason", mock.Object.ConfidenceReasons[0]);
        }

        [TestMethod]
        public void IsNotNullCheckLeavesConfidenceResultUnchangedWhenTrue()
        {
            Mock<IConfidence> mock = DefaultConfidenceResult();
            QualityCheck.IsNotNull<object>(new object(), ConfidenceEnum.None, mock.Object, null);
            Assert.AreEqual(ConfidenceEnum.High, mock.Object.Confidence);
            Assert.IsTrue(mock.Object.ConfidenceReasons.Count == 0);
        }

        [TestMethod]
        public void IsNotNullCheckModifiesConfidenceResultWhenFalse()
        {
            Mock<IConfidence> mock = DefaultConfidenceResult();
            QualityCheck.IsNotNull<object>(null, ConfidenceEnum.None, mock.Object, "Reason");
            Assert.AreEqual(ConfidenceEnum.None, mock.Object.Confidence);
            Assert.IsTrue(mock.Object.ConfidenceReasons.Count == 1);
            Assert.AreEqual("Reason", mock.Object.ConfidenceReasons[0]);
        }

        [TestMethod]
        public void SetLowestConfidenceSetsConfidenceCorrectlyWhenOneIsLower()
        {
            Mock<IConfidence> result = DefaultConfidenceResult();
            Mock<IConfidence> high = DefaultConfidenceResult();
            Mock<IConfidence> low = DefaultConfidenceResult(ConfidenceEnum.None);

            QualityCheck.SetLowestConfidence(result.Object, new []{ high.Object, low.Object }, "Reason" );

            Assert.AreEqual(ConfidenceEnum.None, result.Object.Confidence);
            Assert.IsTrue(result.Object.ConfidenceReasons.Count == 1);
            Assert.AreEqual("Reason", result.Object.ConfidenceReasons[0]);
        }

        [TestMethod]
        public void SetLowestConfidenceSetsConfidenceCorrectlyWhenBothAreEqual()
        {
            Mock<IConfidence> result = DefaultConfidenceResult();
            Mock<IConfidence> first = DefaultConfidenceResult(ConfidenceEnum.Medium);
            Mock<IConfidence> second = DefaultConfidenceResult(ConfidenceEnum.Medium);

            QualityCheck.SetLowestConfidence(result.Object, new[] { first.Object, second.Object }, "Reason");

            Assert.AreEqual(ConfidenceEnum.Medium, result.Object.Confidence);
            Assert.IsTrue(result.Object.ConfidenceReasons.Count == 1);
            Assert.AreEqual("Reason", result.Object.ConfidenceReasons[0]);
        }

        private static Mock<IConfidence> DefaultConfidenceResult(ConfidenceEnum confidence = ConfidenceEnum.High)
        {
            Mock<IConfidence> mock = new Mock<IConfidence>();
            mock.SetupAllProperties();
            mock.Object.Confidence = confidence;
            mock.Object.ConfidenceReasons = new List<string>();
            return mock;
        }
    }
}
