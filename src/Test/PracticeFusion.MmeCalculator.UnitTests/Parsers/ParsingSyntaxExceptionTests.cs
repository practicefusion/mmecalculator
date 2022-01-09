using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeFusion.MmeCalculator.Core.Messages;
using PracticeFusion.MmeCalculator.Core.Parsers;
using PracticeFusion.MmeCalculator.Core.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PracticeFusion.MmeCalculator.UnitTests.Parsers
{
    [TestClass]
    public class ParsingSyntaxExceptionTests
    {
        private static readonly string message = "Test message";
        private static readonly List<(ConfidenceEnum, string)> allSyntaxErrors = new()
        {
            (ConfidenceEnum.High, "High confidence"),
            (ConfidenceEnum.Medium, "Medium confidence"),
            (ConfidenceEnum.Low, "Low confidence"),
            (ConfidenceEnum.None, "No confidence")
        };

        [TestMethod]
        public void ParsingSyntaxExceptionConstructorTest()
        {
            ParsingSyntaxException ex = new();
            ex.AllSyntaxErrors.Should().BeEmpty();
        }

        [TestMethod]
        public void ParsingSyntaxExceptionConstructorWithSyntaxErrors()
        {
            ParsingSyntaxException ex = new(allSyntaxErrors);
            ex.AllSyntaxErrors.Should().BeEquivalentTo(allSyntaxErrors);
        }

        [TestMethod]
        public void ParsingSyntaxExceptionWithMessage()
        {
            ParsingSyntaxException ex = new(message);
            ex.AllSyntaxErrors.Should().BeEmpty();
            ex.Message.Should().Be(message);
        }

        [TestMethod]
        public void ParsingSyntaxExceptionWithMessageAndInnerException()
        {
            ParsingSyntaxException ex = new(message, new Exception("Inner exception"));
            ex.AllSyntaxErrors.Should().BeEmpty();
            ex.Message.Should().Be(message);
            ex.InnerException.Should().NotBeNull();
            ex.InnerException.Message.Should().Be("Inner exception");
        }

        [TestMethod]
        public void ShouldBeSerializable()
        {
            ParsingSyntaxException ex = new(allSyntaxErrors);
            string exceptionToString = ex.ToString();

            ex.Should().BeBinarySerializable();
        }

        [TestMethod]
        public void NullInfoShouldThrowExceptionGetObjectData()
        {
            ParsingSyntaxException ex = new(allSyntaxErrors);
            ex.Invoking(x => x.GetObjectData(null, new StreamingContext())).Should().Throw<ArgumentNullException>()
                .WithMessage("Value cannot be null. (Parameter 'info')");
        }
    }
}