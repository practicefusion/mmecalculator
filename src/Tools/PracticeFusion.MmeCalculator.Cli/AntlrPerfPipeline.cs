﻿using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PracticeFusion.MmeCalculator.Cli
{
    internal static class AntlrPerfPipeline
    {
        internal static async Task Execute(FileInfo input, FileInfo output, bool overwrite,
            OutputFileFormat outputFormat)
        {
            // wire up in and out
            using TextReader tr = FileUtils.GetInputStream(input);
            await using TextWriter tw = FileUtils.GetOutputStream(output, overwrite);

            // write the header
            await tw.WriteLineAsync(
                "Sig\tTimeInPrediction\tInvocations\tTotalLook\tMaxLook\tAmbiguities\tErrors\tRule");

            // process input
            var count = 0;
            while (await tr.ReadLineAsync() is { } line)
            {
                count++;

                // perform the operation
                var parts = line.Split('\t');
                if (parts.Length < 1 || parts.Length > 2)
                {
                    throw new Exception("Expecting a tab delimited line with id (optional) and sig");
                }

                var id = parts.Length > 1 ? parts[0] : count.ToString();
                var sig = parts[^1];

                // construct parser, execute root rule
                ICharStream stream = CharStreams.fromString(sig);
                ITokenSource lexer = new DefaultLexer(stream);
                ITokenStream tokens = new CommonTokenStream(lexer);
                var parser = new DefaultParser(tokens)
                {
                    Profile = true, Interpreter = { PredictionMode = PredictionMode.LL }
                };
                parser.sig();

                DecisionInfo[] decisionInfo = parser.ParseInfo.getDecisionInfo();
                foreach (DecisionInfo x in decisionInfo)
                {
                    DecisionState decisionState = parser.Atn.GetDecisionState(x.decision);
                    var ruleName = parser.RuleNames[decisionState.ruleIndex];

                    if (x.timeInPrediction > 0)
                    {
                        await tw.WriteLineAsync(
                            $"{id}\t{x.timeInPrediction}\t{x.invocations}\t{x.LL_TotalLook}\t{x.LL_MaxLook}\t{x.ambiguities.Count}\t{x.errors.Count}\t{ruleName}");
                    }
                }

                // update the event counter
                DefaultEventCounterSource.Log.IncrementCalculations();
            }

            // output the performance data
            await Console.Error.WriteLineAsync("\nCompleted.");
        }
    }
}