using System;
using System.IO;
using System.Threading.Tasks;
using PracticeFusion.MmeCalculator.Core.Messages;
using PracticeFusion.MmeCalculator.Core.Services;

namespace PracticeFusion.MmeCalculator.Cli
{
    static class CalculatePipeline
    {
        internal static async Task Execute(FileInfo input, FileInfo output, bool overwrite, OutputFileFormat outputFormat)
        {
            // create the parser
            ICalculator calculator = DefaultServices.Calculator;

            // wire up in and out
            using var tr = FileUtils.GetInputStream(input);
            using var tw = FileUtils.GetOutputStream(output, overwrite);

            // process input
            string line;
            int count = 0;
            while ((line = await tr.ReadLineAsync()) != null)
            {
                count++;

                // perform the operation
                var parts = line.Split('\t');
                if (parts.Length < 2 || parts.Length > 3)
                {
                    throw new Exception("Expecting a tab delimited line with id (optional), rxcui and sig");
                }

                var calculateItem = new CalculationItem();

                if (parts.Length == 3)
                {
                    calculateItem.RequestItemId = parts[0];
                    calculateItem.RxCui = parts[1];
                    calculateItem.Sig = parts[2];
                }
                else
                {
                    calculateItem.RequestItemId = count.ToString();
                    calculateItem.RxCui = parts[0];
                    calculateItem.Sig = parts[1];
                }

                var request = new CalculationRequest();
                request.CalculationItems.Add(calculateItem);
                var result = calculator.Calculate(request);

                // write the line to the output
                await WriteFormattedCalculatedResult(tw, calculateItem.RequestItemId, line, result, outputFormat);

                // update the event counter
                DefaultEventCounterSource.Log.IncrementCalculations();
            }

            // output the performance data
            await Console.Error.WriteLineAsync("\nCompleted.");
        }
        
        private static async Task WriteFormattedCalculatedResult(TextWriter tw, string id, string originalSig, CalculatedResult result, OutputFileFormat outputFormat)
        {
            if (result.CalculatedResultAnalysis.Confidence == ConfidenceEnum.High)
            {
                await tw.WriteLineAsync(Formatter.Format(id, originalSig, result, outputFormat));
            }
            else
            {
                await tw.WriteLineAsync(Formatter.FormatError(id, originalSig, result, outputFormat));
            }
        }
    }
}
