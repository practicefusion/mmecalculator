using System;
using System.IO;
using System.Threading.Tasks;
using PracticeFusion.MmeCalculator.Core.Messages;
using PracticeFusion.MmeCalculator.Core.Services;

namespace PracticeFusion.MmeCalculator.Cli
{
    static class ParseSigPipeline
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
                if (parts.Length < 1 || parts.Length > 2)
                {
                    throw new Exception("Expecting a tab delimited line with id (optional) and sig");
                }

                var id = parts.Length > 1 ? parts[0] : count.ToString();
                var sig = parts[parts.Length - 1];
                var result = calculator.ParseSig(sig);

                // write the line to the output
                await WriteFormattedParseSigResult(tw, id, sig, result, outputFormat);

                // update the event counter
                DefaultEventCounterSource.Log.IncrementCalculations();
            }

            // output the performance data
            await Console.Error.WriteLineAsync($"\nCompleted: {count} sigs processed.");
        }
        
        private static async Task WriteFormattedParseSigResult(TextWriter tw, string id, string originalSig, ParsedSig result, OutputFileFormat outputFormat)
        {
            if (result.Confidence == ConfidenceEnum.High)
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
