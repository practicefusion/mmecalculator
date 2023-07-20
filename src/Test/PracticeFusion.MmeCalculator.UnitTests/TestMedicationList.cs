using PracticeFusion.MmeCalculator.Core.Messages;
using System.Collections.Generic;

namespace PracticeFusion.MmeCalculator.UnitTests
{
    public class TestMedicationList
    {
        public TestMedicationList()
        {
            TestItems = new List<TestItem>();
        }

        public string Id { get; set; }
        public decimal ExpectedMme { get; set; }
        public ConfidenceEnum Confidence { get; set; }
        public string Description { get; set; }
        public List<TestItem> TestItems { get; set; }
    }
}