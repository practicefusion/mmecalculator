using System.CommandLine;
using System.CommandLine.NamingConventionBinder;
using System.IO;
using System.Threading.Tasks;

namespace PracticeFusion.MmeCalculator.Cli
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            // set up the event counter
            DefaultEventCounterSource defaultEventCounter = DefaultEventCounterSource.Log;

            // set up the event listener
            var performanceEventListener = new PerformanceEventListener();

            var rootCommand = new RootCommand();
            rootCommand.AddGlobalOption(new Option<FileInfo>(new[] { "-i", "--input" },
                "input file (if not present, will use stdin)"));
            rootCommand.AddGlobalOption(new Option<FileInfo>(new[] { "-o", "--output" },
                "output file (if not present, will use stdout)"));
            rootCommand.AddGlobalOption(new Option<bool>(new[] { "-ow", "--overwrite" }, () => false,
                "overwrite the output file if it exists"));
            rootCommand.AddGlobalOption(new Option<OutputFileFormat>(new[] { "-of", "--outputFormat" },
                () => OutputFileFormat.Basic, "output format (basic, debug)"));

            var calculateCommand = new Command("calculate")
            {
                Handler = CommandHandler.Create<FileInfo, FileInfo, bool, OutputFileFormat>(CalculatePipeline
                    .Execute)
            };
            rootCommand.AddCommand(calculateCommand);

            var parseSigCommand = new Command("parsesig")
            {
                Handler =
                    CommandHandler.Create<FileInfo, FileInfo, bool, OutputFileFormat>(ParseSigPipeline.Execute)
            };
            rootCommand.AddCommand(parseSigCommand);

            var antlrPerfCommand = new Command("antlrperf")
            {
                Handler = CommandHandler.Create<FileInfo, FileInfo, bool, OutputFileFormat>(AntlrPerfPipeline
                    .Execute)
            };
            rootCommand.AddCommand(antlrPerfCommand);

            await rootCommand.InvokeAsync(args);
        }
    }
}