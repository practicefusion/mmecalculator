// ReSharper disable UnusedAutoPropertyAccessor.Global

using System;
using System.Collections.Generic;
using System.Linq;
using PracticeFusion.MmeCalculator.Core.Messages;

namespace PracticeFusion.MmeCalculator.SystemTests
{
    public class SigTestItem
    {
        public SigTestItem()
        {
        }

        public SigTestItem(string testDataLine) : this(testDataLine.Split("\t"))
        {
        }

        public SigTestItem(string[] testData) : this(testData[0], testData[1], testData[2], testData[3], testData[4])
        {
        }

        public SigTestItem(string status, string id, string sig, string expected, string mdd)
        {
            Id = id;
            Sig = sig;

            if (status == "PASS")
            {
                ShouldPass = true;
                Confidence = ConfidenceEnum.High;
                ExpectedErrorMessages.Clear();
                Expected = expected;
                MaximumDailyDosage = mdd;
            }
            else
            {
                ShouldPass = false;
                Confidence = Enum.Parse<ConfidenceEnum>(expected);
                ExpectedErrorMessages.AddRange(mdd.Split("|").ToList());
                Expected = string.Empty;
                MaximumDailyDosage = string.Empty;
            }
        }

        public string Id { get; set; }
        public bool ShouldPass { get; set; }
        public ConfidenceEnum Confidence { get; set; }
        public List<string> ExpectedErrorMessages { get; set; } = new();
        public string Sig { get; set; }
        public string Expected { get; set; }
        public string MaximumDailyDosage { get; set; }
    }
}
