using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using PracticeFusion.MmeCalculator.Core.Messages;
using PracticeFusion.MmeCalculator.Core.Parsers;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;
using PracticeFusion.MmeCalculator.Core.Parsers.Visitors;

namespace PracticeFusion.MmeCalculator.Core.Services
{
    /// <inheritdoc />
    public class MedicationParser : IMedicationParser
    {
        private readonly string _cachePrefix = "{ParsedMedication}";
        private readonly IDistributedCache? _distributedCache;
        private readonly ILogger _logger;
        private readonly IRxNormInformationResolver _rxNormResolver;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="distributedCache"></param>
        /// <param name="rxNormResolver"></param>
        public MedicationParser(
            ILogger<MedicationParser> logger,
            IDistributedCache? distributedCache,
            IRxNormInformationResolver rxNormResolver)
        {
            _logger = logger;
            _distributedCache = distributedCache;
            _rxNormResolver = rxNormResolver;
        }

        /// <summary>
        /// Constructor uses <see cref="NullLogger"/> and sets <see cref="IDistributedCache"/> to null.
        /// </summary>
        /// <param name="rxNormResolver"></param>
        public MedicationParser(IRxNormInformationResolver rxNormResolver) : this(
            NullLogger<MedicationParser>.Instance,
            null,
            rxNormResolver)
        {
        }

        /// <inheritdoc />
        public string GetDrugNameFromRxCui(string rxCui)
        {
            using (_logger.BeginScope("Looking up drug from RxCUI '{rxCui}", rxCui))
            {
                var key = $"{_cachePrefix}{{{rxCui}}}";

                if (_distributedCache != null && _distributedCache.TryGetValue(key, out string cachedResult))
                {
                    return cachedResult;
                }

                string rxNormName = _rxNormResolver.ResolveRxNormCode(rxCui);

                if (_distributedCache != null && !_distributedCache.Exists(key))
                {
                    _distributedCache.Set(key, rxNormName);
                }

                return rxNormName;
            }
        }

        /// <inheritdoc />
        public ParsedMedication Parse(string rxCui, string rxNormName)
        {
            using (_logger.BeginScope("Parsing medication from '{rxCui}' '{rxNormName}'", rxCui, rxNormName))
            {
                var key = $"{_cachePrefix}{{{rxCui}}}{{{rxNormName}}}";

                if (_distributedCache != null && _distributedCache.TryGetValue(key, out ParsedMedication cachedResult))
                {
                    return cachedResult;
                }

                // a very normalized structure, this is clean enough to not preprocess.
                var preprocessedMedication = rxNormName;

                try
                {
                    ICharStream stream = CharStreams.fromString(preprocessedMedication);
                    var lexer = new DefaultLexer(stream);
                    ITokenStream tokens = new CommonTokenStream(lexer);
                    var parser = new DefaultParser(tokens);

                    // set up the list of errors
                    List<(ConfidenceEnum Confidence, string ConfidenceReason)> parserErrors =
                        new List<(ConfidenceEnum Confidence, string ConfidenceReason)>();
                    parser.RemoveErrorListeners();
                    parser.AddErrorListener(new ConfidenceErrorListener(parserErrors));

                    // parse
                    DefaultParser.MedicationContext tree = parser.medication();

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
                    var visitor = new MedicationVisitor();
                    ParsedMedication result = visitor.VisitRoot(tree);
                    result.OriginalMedication = rxNormName;
                    result.PreprocessedMedication = preprocessedMedication;
                    result.RxCui = rxCui;

                    // cache the result
                    if (_distributedCache != null && !_distributedCache.Exists(key))
                    {
                        _distributedCache.Set(key, result);
                    }

                    return result;
                }
                catch (ParsingSyntaxException e)
                {
                    var result = new ParsedMedication()
                        { OriginalMedication = rxNormName, PreprocessedMedication = preprocessedMedication, RxCui = rxCui };

                    result.MedicationComponents.Clear();
                    result.Confidence = ConfidenceEnum.None;
                    result.ConfidenceReasons.AddRange(e.AllSyntaxErrors.Select(x => x.Item2).ToArray());

                    return result;
                }
                catch (ParsingException e)
                {
                    var result = new ParsedMedication()
                        { OriginalMedication = rxNormName, PreprocessedMedication = preprocessedMedication, RxCui = rxCui };

                    result.MedicationComponents.Clear();
                    result.Confidence = ConfidenceEnum.None;
                    result.ConfidenceReasons.Add(e.Message);

                    return result;
                }
            }
        }
    }
}
