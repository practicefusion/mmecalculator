// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace PracticeFusion.MmeCalculator.UnitTests
{
    public class TestItem
    {
        public TestItem()
        {
        }

        public TestItem(string testDataLine) : this(testDataLine.Split('\t'))
        {
        }

        public TestItem(string[] testData) : this(testData[0], testData[1], testData[2], testData[3], testData[4])
        {
        }

        public TestItem(string id, string rxCui, string medName, string instruction, string expectedMme)
        {
            Id = id;
            RxCui = rxCui;
            MedName = medName;
            Instruction = instruction;
            ExpectedMme = decimal.Parse(expectedMme);
        }

        public string Id { get; set; }
        public string RxCui { get; set; }
        public string MedName { get; set; }
        public string Instruction { get; set; }
        public decimal ExpectedMme { get; set; }
    }
}
