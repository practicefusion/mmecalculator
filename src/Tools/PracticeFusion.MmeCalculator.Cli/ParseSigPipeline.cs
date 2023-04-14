using PracticeFusion.MmeCalculator.Core.Messages;
using PracticeFusion.MmeCalculator.Core.Services;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PracticeFusion.MmeCalculator.Cli
{
    internal static class ParseSigPipeline
    {
        internal static async Task Execute(FileInfo input, FileInfo output, bool overwrite,
            OutputFileFormat outputFormat)
        {
            // create the parser
            ICalculator calculator = DefaultServices.Calculator;

            // wire up in and out
            using TextReader tr = FileUtils.GetInputStream(input);
            using TextWriter tw = FileUtils.GetOutputStream(output, overwrite);

            // process input
            var count = 0;
            while (await tr.ReadLineAsync() is { } line)
            {
                count++;

                // perform the operation
                var parts = line.Split('\t');
                if (parts.Length is < 1 or > 2)
                {
                    throw new Exception("Expecting a tab delimited line with id (optional) and sig");
                }

                var id = parts.Length > 1 ? parts[0] : count.ToString();
                var sig = parts[^1];
                ParsedSig result = calculator.ParseSig(sig);

                // write the line to the output
                await WriteFormattedParseSigResult(tw, id, sig, result, outputFormat);

                // update the event counter
                DefaultEventCounterSource.Log.IncrementCalculations();
            }

            // output the performance data
            await Console.Error.WriteLineAsync($"\nCompleted: {count} sigs processed.");
        }

        private static async Task WriteFormattedParseSigResult(TextWriter tw, string id, string originalSig,
            ParsedSig result, OutputFileFormat outputFormat)
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