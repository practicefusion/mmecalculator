using System;
using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Messages;
using PracticeFusion.MmeCalculator.Core.Parsers;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;
using PracticeFusion.MmeCalculator.Core.Parsers.Visitors;

namespace PracticeFusion.MmeCalculator.Core.Services
{
    /// <inheritdoc />
    public class SigParser : ISigParser
    {
        private readonly string _cachePrefix = "{ParsedSig}";
        private readonly IDistributedCache? _distributedCache;
        private readonly ILogger _logger;
        private readonly IStringPreprocessor _stringPreprocessor;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="distributedCache"></param>
        /// <param name="stringPreprocessor"></param>
        public SigParser(ILogger<SigParser> logger, IDistributedCache? distributedCache, IStringPreprocessor stringPreprocessor)
        {
            _logger = logger;
            _distributedCache = distributedCache;
            _stringPreprocessor = stringPreprocessor;
        }

        /// <summary>
        /// Constructor uses <see cref="NullLogger"/> and sets <see cref="IDistributedCache"/> to null.
        /// </summary>
        public SigParser() : this(NullLogger<SigParser>.Instance, null, new StringPreprocessor())
        {

        }

        /// <inheritdoc />
        public ParsedSig Parse(string sig)
        {
            return Parse(sig, BuildSigTree, VisitSigRoot);
        }

        /// <inheritdoc />
        public ParsedSig ParseStrict(string sig)
        {
            return Parse(sig, BuildStrictSigTree, VisitStrictSigRoot);
        }

        private ParserRuleContext BuildSigTree(DefaultParser parser) => parser.sig();

        private ParserRuleContext BuildStrictSigTree(DefaultParser parser) => parser.strictSig();

        private ParsedSig VisitSigRoot(ParserRuleContext parserRuleContext)
        {
            DefaultParser.SigContext? tree = parserRuleContext as DefaultParser.SigContext;
            if(tree != null)
            {
                var visitor = new SigVisitor();
                return visitor.VisitRoot(tree);
            }
            else
            {
                throw new InvalidCastException("Expected the parser rule context to be a SigContext.");
            }
        }

        private ParsedSig VisitStrictSigRoot(ParserRuleContext parserRuleContext)
        {
            DefaultParser.StrictSigContext? tree = parserRuleContext as DefaultParser.StrictSigContext;
            if(tree != null)
            {
                var visitor = new StrictSigVisitor();
                return visitor.VisitRoot(tree);
            }
            else
            {
                throw new InvalidCastException("Expected the parser rule context to be a StrictSigContext.");
            }
        }

        /// <inheritdoc />
        private ParsedSig Parse(string sig, Func<DefaultParser, ParserRuleContext> GetParserRuleContext, Func<ParserRuleContext, ParsedSig> VisitTree)
        {
            using (_logger.BeginScope("Parsing sig '{sig}'", sig))
            {
                var key = $"{_cachePrefix}{{{sig}}}";

                if (_distributedCache != null && _distributedCache.TryGetValue(key, out ParsedSig cachedResult))
                {
                    return cachedResult;
                }

                var preprocessedSig = string.Empty;

                try
                {
                    preprocessedSig = _stringPreprocessor.Normalize(sig);

                    ICharStream stream = CharStreams.fromString(preprocessedSig);
                    var lexer = new DefaultLexer(stream);
                    ITokenStream tokens = new CommonTokenStream(lexer);
                    var parser = new DefaultParser(tokens);

                    // set up the list of errors
                    var parserErrors =
                        new List<(ConfidenceEnum Confidence, string ConfidenceReason)>();
                    parser.RemoveErrorListeners();
                    parser.AddErrorListener(new ConfidenceErrorListener(parserErrors));

                    // parse
                    ParserRuleContext tree = GetParserRuleContext(parser);

                    // check for errors or exceptions
                    if (parser.NumberOfSyntaxErrors > 0)
                    {
                        throw new ParsingSyntaxException(parserErrors);
                    }

                    if (tree.exception != null)
                    {
                        throw new ParsingException(tree.exception.Message, tree.exception);
                    }

                    // visit the tree
                    var result = VisitTree(tree);
                    result.OriginalSig = sig;
                    result.PreprocessedSig = preprocessedSig;

                    // Add the maximum dosage
                    CalculateMaximumDosage(result);

                    // cache the result
                    if (_distributedCache != null && !_distributedCache.Exists(key))
                    {
                        _distributedCache.Set(key, result);
                    }

                    return result;
                }
                catch (ParsingSyntaxException e)
                {
                    var result = new ParsedSig { OriginalSig = sig, PreprocessedSig = preprocessedSig };

                    result.Dosages.Clear();
                    result.Confidence = ConfidenceEnum.None;
                    result.ConfidenceReasons.AddRange(e.AllSyntaxErrors.Select(x => x.Item2).ToArray());

                    return result;
                }
                catch (ParsingException e)
                {
                    var result = new ParsedSig { OriginalSig = sig, PreprocessedSig = preprocessedSig };

                    result.Dosages.Clear();
                    result.Confidence = ConfidenceEnum.None;
                    result.ConfidenceReasons.Add(e.Message);
                    if (e.InnerException is ParsingException)
                    {
                        result.ConfidenceReasons.Add(e.InnerException.Message);
                    }

                    return result;
                }
            }
        }

        private static void CalculateMaximumDosage(ParsedSig result)
        {
            if (result.Dosages.Count > 0)
            {
                Dose? maximumDailyDose = null;

                foreach (Dosage dosage in result.Dosages)
                {
                    Dose? calculated = dosage.MaximumDailyDose;
                    if (maximumDailyDose == null ||
                        calculated != null && calculated.MaxDose > maximumDailyDose.MaxDose)
                    {
                        maximumDailyDose = calculated;
                    }
                }

                result.MaximumDosage = maximumDailyDose!;
            }
        }
    }
}
