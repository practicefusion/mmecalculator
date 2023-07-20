using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Dfa;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Sharpen;
using PracticeFusion.MmeCalculator.Core.Messages;
using System.Collections.Generic;
using System.IO;

namespace PracticeFusion.MmeCalculator.Core.Parsers
{
    /// <inheritdoc />
    /// <remarks>
    ///     As strict as we can be on parsing
    /// </remarks>
    internal class ConfidenceErrorListener : BaseErrorListener
    {
        private readonly List<(ConfidenceEnum, string)> _reporting;

        /// <summary>
        ///     Pass in a list of tuples to track errors from a parse.
        /// </summary>
        /// <param name="reporting"></param>
        public ConfidenceErrorListener(List<(ConfidenceEnum Confidence, string ConfidenceReason)> reporting)
        {
            _reporting = reporting;
        }

        /// <inheritdoc />
        public override void SyntaxError(
            TextWriter output,
            IRecognizer recognizer,
            IToken offendingSymbol,
            int line,
            int charPositionInLine,
            string msg,
            RecognitionException e)
        {
            _reporting.Add((ConfidenceEnum.None,
                $"Syntax error: unexpected '{offendingSymbol.Text}' at Ln {line}, Col {charPositionInLine}"));
        }

        /// <inheritdoc />
        public override void ReportAmbiguity(Parser recognizer, DFA dfa, int startIndex, int stopIndex, bool exact,
            BitSet ambigAlts, ATNConfigSet configs)
        {
            _reporting.Add((ConfidenceEnum.None,
                $"Ambiguous expression: '{recognizer.TokenStream.GetText(new Interval(startIndex, stopIndex))}'"));
        }
    }
}