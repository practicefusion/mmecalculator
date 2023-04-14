using System.Collections.Generic;
using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Dfa;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Sharpen;
using PracticeFusion.MmeCalculator.Core.Messages;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;

namespace PracticeFusion.MmeCalculator.Core.Parsers
{
    /// <inheritdoc />
    /// <remarks>
    /// Using the strictest rules in the grammar for assessing the errors
    /// </remarks>
    internal class RuleConfidenceErrorListener : BaseErrorListener
    {
        private readonly List<(ConfidenceEnum, string, List<string>)> _reporting;

        /// <summary>
        /// Pass in a list of tuples to track errors from a parse.
        /// </summary>
        /// <param name="reporting"></param>
        public RuleConfidenceErrorListener(List<(ConfidenceEnum Confidence, string ConfidenceReason, 
            List<string> expectedRules)> reporting)
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
                $"Syntax error: unexpected '{offendingSymbol.Text}' at Ln {line}, Col {charPositionInLine}.", 
                GetExpectedRules(recognizer)));
        }
        
        /// <inheritdoc />
        public override void ReportAmbiguity(Parser recognizer, DFA dfa, int startIndex, int stopIndex, bool exact, BitSet ambigAlts, ATNConfigSet configs)
        {
            _reporting.Add((ConfidenceEnum.None, $"Ambiguous expression: '{recognizer.TokenStream.GetText(new Interval(startIndex, stopIndex))}'", new List<string>()));
        }

        private List<string> GetExpectedRules(IRecognizer recognizer)
        {
            HashSet<ATNState> completed = new HashSet<ATNState>();
            List<string> ruleNames = GetNextRulesOrTokens((DefaultParser)recognizer, recognizer.Atn.states[recognizer.State], completed);
            return ruleNames;
        }

        private List<string> GetNextRulesOrTokens(DefaultParser parser, ATNState state, HashSet<ATNState> completed)
        {
            List<string> result = new List<string>();

            if (completed.Contains(state))
            {
                return result;
            }
            else
            {
                completed.Add(state);
            }
            
            foreach (Transition transition in state.TransitionsArray)
            {
                if (transition.TransitionType == TransitionType.RULE)
                {
                    result.Add(parser.RuleNames[((RuleTransition)transition).ruleIndex]);
                }
                else if (transition.IsEpsilon)
                {
                    result.AddRange(GetNextRulesOrTokens(parser, transition.target, completed));
                }
                else
                {
                    if(transition.Label != null)
                        result.Add(transition.Label.ToString(parser.Vocabulary));
                }
            }

            return result;
        }
    }
}
