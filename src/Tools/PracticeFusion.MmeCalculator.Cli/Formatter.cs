using PracticeFusion.MmeCalculator.Core.Messages;
using PracticeFusion.MmeCalculator.Core.Services;

namespace PracticeFusion.MmeCalculator.Cli
{
    internal static class Formatter
    {
        internal static string Format(string id, string originalSig, CalculatedResult result, OutputFileFormat outputFormat)
        {
            return outputFormat switch
            {
                OutputFileFormat.Debug =>
                    $"PASS\t{id}\t{originalSig}\t{result.ParsedResults[0]!.ParsedSig!.HumanReadable}\t{result.CalculatedResultAnalysis.MaximumMmePerDay}\t{JsonUtils.Serialize(result, false)}",
                OutputFileFormat.DebugFormatted =>
                    $"PASS\t{id}\t{originalSig}\t{result.ParsedResults[0]!.ParsedSig!.HumanReadable}\t{result.CalculatedResultAnalysis.MaximumMmePerDay}\n{JsonUtils.Serialize(result)}",
                _ =>
                    $"PASS\t{id}\t{originalSig}\t{result.ParsedResults[0]!.ParsedSig!.HumanReadable}\t{result.CalculatedResultAnalysis.MaximumMmePerDay}"
            };
        }
        
        internal static string FormatError(string id, string originalSig, CalculatedResult result, OutputFileFormat outputFormat)
        {
            return outputFormat switch
            {
                OutputFileFormat.Debug =>
                    $"FAIL\t{id}\t{originalSig}\t{result.CalculatedResultAnalysis.Confidence}\t{string.Join("|", result.CalculatedResultAnalysis.ConfidenceReasons)}\t{JsonUtils.Serialize(result, false)}",
                OutputFileFormat.DebugFormatted =>
                    $"FAIL\t{id}\t{originalSig}\t{result.CalculatedResultAnalysis.Confidence}\t{string.Join("|", result.CalculatedResultAnalysis.ConfidenceReasons)}\n{JsonUtils.Serialize(result)}",
                _ =>
                    $"FAIL\t{id}\t{originalSig}\t{result.CalculatedResultAnalysis.Confidence}\t{string.Join("|", result.CalculatedResultAnalysis.ConfidenceReasons)}"
            };
        }
        
        internal static string Format(string id, string originalSig, ParsedSig result, OutputFileFormat outputFormat)
        {
            return outputFormat switch
            {
                OutputFileFormat.Debug =>
                    $"PASS\t{id}\t{originalSig}\t{result.HumanReadable}\t{result.MaximumDosage!.HumanReadable}\t{JsonUtils.Serialize(result, false)}",
                OutputFileFormat.DebugFormatted =>
                    $"PASS\t{id}\t{originalSig}\t{result.HumanReadable}\t{result.MaximumDosage!.HumanReadable}\n{JsonUtils.Serialize(result)}",
                _ => $"PASS\t{id}\t{originalSig}\t{result.HumanReadable}\t{result.MaximumDosage!.HumanReadable}"
            };
        }

        internal static string FormatError(string id, string originalSig, ParsedSig result, OutputFileFormat outputFormat)
        {
            return outputFormat switch
            {
                OutputFileFormat.Debug =>
                    $"FAIL\t{id}\t{originalSig}\t{result.Confidence}\t{string.Join("|", result.ConfidenceReasons)}\t{JsonUtils.Serialize(result, false)}",
                OutputFileFormat.DebugFormatted =>
                    $"FAIL\t{id}\t{originalSig}\t{result.Confidence}\t{string.Join("|", result.ConfidenceReasons)}\n{JsonUtils.Serialize(result)}",
                _ => $"FAIL\t{id}\t{originalSig}\t{result.Confidence}\t{string.Join("|", result.ConfidenceReasons)}"
            };
        }
    }
}
