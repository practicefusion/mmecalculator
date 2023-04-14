using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeFusion.MmeCalculator.Core.Services;

namespace PracticeFusion.MmeCalculator.UnitTests.Services
{
    [TestClass]
    public class StringPreprocessorTests
    {
        private readonly IStringPreprocessor _stringPreprocessor = new StringPreprocessor();

        [TestMethod]
        public void NormalizeUnnecessaryChars()
        {
            var result = _stringPreprocessor.Normalize(@"a!a$a%a^a#a'a""a*a[a]a;a:a,a<a>a?a_a+a");
            result.Should().BeEquivalentTo("a a a a a a a a a a a a a a a a a a a");
        }

        [TestMethod]
        public void NormalizeLeavesColonsInTimes()
        {
            var result = _stringPreprocessor.Normalize(@"a!a$a%a^a#a'a""a*a[a]a;a:a,a<a>a?a_a+08:00");
            result.Should().BeEquivalentTo("a a a a a a a a a a a a a a a a a a 08:00");
        }

        [TestMethod]
        public void NormalizeLeavesPeriodsInDecimals()
        {
            var result = _stringPreprocessor.Normalize(@"a!a$a%a^a#a'a""a*a[a]a;a:a,a<a>a?a_a+8.00");
            result.Should().BeEquivalentTo("a a a a a a a a a a a a a a a a a a 8.00");
        }

        [TestMethod]
        public void NormalizeLeavesCommasInNumbersWithThousands()
        {
            var result = _stringPreprocessor.Normalize(@"a!a$a%a^a#a'a""a*a[a]a;a:a,a<a>a?a_a+5,000");
            result.Should().BeEquivalentTo("a a a a a a a a a a a a a a a a a a 5,000");
        }

        [TestMethod]
        public void NormalizeExtraSpaces()
        {
            var result = _stringPreprocessor.Normalize(@"a a  a   a    a     a      ");
            result.Should().BeEquivalentTo("a a a a a a");
        }

        [TestMethod]
        public void NormalizeToLowerCase()
        {
            var result = _stringPreprocessor.Normalize(@"A a A a A");
            result.Should().BeEquivalentTo("a a a a a");
        }

        [TestMethod]
        public void NormalizeTwentyFour()
        {
            var result = _stringPreprocessor.Normalize(@"23 twenty-four 25");
            result.Should().BeEquivalentTo("23 24 25");
        }

        [TestMethod]
        public void NormalizeFortyEight()
        {
            var result = _stringPreprocessor.Normalize(@"47 forty-eight 49");
            result.Should().BeEquivalentTo("47 48 49");
        }

        [TestMethod]
        public void NormalizeSeventyTwo()
        {
            var result = _stringPreprocessor.Normalize(@"71 seventy-two 73");
            result.Should().BeEquivalentTo("71 72 73");
        }

        [TestMethod]
        public void NormalizeOneAndHalf()
        {
            var result = _stringPreprocessor.Normalize(@"one and a half");
            result.Should().BeEquivalentTo("1.5");
        }

        [TestMethod]
        public void NormalizeOneHalf()
        {
            var result = _stringPreprocessor.Normalize(@"onehalf");
            result.Should().BeEquivalentTo("0.5");
        }

        [TestMethod]
        public void NormalizeTwoAndHalf()
        {
            var result = _stringPreprocessor.Normalize(@"two and half");
            result.Should().BeEquivalentTo("2.5");
        }

        [TestMethod]
        public void NormalizeOne()
        {
            var result = _stringPreprocessor.Normalize(@"0 one 2");
            result.Should().BeEquivalentTo("0 1 2");
        }

        [TestMethod]
        public void NormalizeTwo()
        {
            var result = _stringPreprocessor.Normalize(@"1 two 3");
            result.Should().BeEquivalentTo("1 2 3");
        }

        [TestMethod]
        public void NormalizeThree()
        {
            var result = _stringPreprocessor.Normalize(@"2 three 4");
            result.Should().BeEquivalentTo("2 3 4");
        }

        [TestMethod]
        public void NormalizeFour()
        {
            var result = _stringPreprocessor.Normalize(@"3 four 5");
            result.Should().BeEquivalentTo("3 4 5");
        }

        [TestMethod]
        public void NormalizeFive()
        {
            var result = _stringPreprocessor.Normalize(@"4 five 6");
            result.Should().BeEquivalentTo("4 5 6");
        }

        [TestMethod]
        public void NormalizeSix()
        {
            var result = _stringPreprocessor.Normalize(@"5 six 7");
            result.Should().BeEquivalentTo("5 6 7");
        }

        [TestMethod]
        public void NormalizeSeven()
        {
            var result = _stringPreprocessor.Normalize(@"6 seven 8");
            result.Should().BeEquivalentTo("6 7 8");
        }

        [TestMethod]
        public void NormalizeEight()
        {
            var result = _stringPreprocessor.Normalize(@"7 eight 9");
            result.Should().BeEquivalentTo("7 8 9");
        }

        [TestMethod]
        public void NormalizeNine()
        {
            var result = _stringPreprocessor.Normalize(@"8 nine 10");
            result.Should().BeEquivalentTo("8 9 10");
        }

        [TestMethod]
        public void NormalizeTen()
        {
            var result = _stringPreprocessor.Normalize(@"9 ten 11");
            result.Should().BeEquivalentTo("9 10 11");
        }

        [TestMethod]
        public void NormalizeTwelve()
        {
            var result = _stringPreprocessor.Normalize(@"11 twelve 13");
            result.Should().BeEquivalentTo("11 12 13");
        }

        [TestMethod]
        public void NormalizeHalfA()
        {
            var result = _stringPreprocessor.Normalize(@"half a tablet");
            result.Should().BeEquivalentTo("0.5 tablet");
        }

        [TestMethod]
        public void NormalizeFractionsGTOne()
        {
            var result = _stringPreprocessor.Normalize(@"take 3 1/2 tablets");
            result.Should().BeEquivalentTo("take 3.5 tablets");
        }

        [TestMethod]
        public void DoNotNormalizeFractionsGTOneWithNoLeadingIntegerSpace()
        {
            var result = _stringPreprocessor.Normalize(@"take 31/2 tablets");
            result.Should().BeEquivalentTo("take 31/2 tablets");
        }

        [TestMethod]
        public void NormalizeFractionsLTOne()
        {
            var result = _stringPreprocessor.Normalize(@"take 1/2 tablets");
            result.Should().BeEquivalentTo("take 0.5 tablets");
        }

        [TestMethod]
        public void NormalizeNumberPairs()
        {
            var result = _stringPreprocessor.Normalize(@"take 3 (3) tablets");
            result.Should().BeEquivalentTo("take 3 tablets");
        }

        [TestMethod]
        public void NormalizeNumbersInParensAfterAllOtherChanges()
        {
            var result = _stringPreprocessor.Normalize(@"(3) tablets");
            result.Should().BeEquivalentTo("3 tablets");
        }

        [TestMethod]
        public void NormalizeInterpolatedPatchCount()
        {
            var result = _stringPreprocessor.Normalize(@"apply patch every 72 hours");
            result.Should().BeEquivalentTo("apply 1 patch every 72 hours");
        }

        [TestMethod]
        public void NormalizeMootInstructions()
        {
            var result = _stringPreprocessor.Normalize(@"apply 1 patch and changing every 72 hours");
            result.Should().BeEquivalentTo("apply 1 patch every 72 hours");
        }

        [TestMethod]
        public void NormalizeChangeEveryInstructions()
        {
            var result = _stringPreprocessor.Normalize(@"change every 72 hours");
            result.Should().BeEquivalentTo("1 every 72 hours");
            result = _stringPreprocessor.Normalize(@"change q72 hours");
            result.Should().BeEquivalentTo("1 q72 hours");
        }
    }
}