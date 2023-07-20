using Antlr4.Runtime;
using FluentAssertions;
using PracticeFusion.MmeCalculator.Core.Messages;
using PracticeFusion.MmeCalculator.Core.Parsers;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;
using PracticeFusion.MmeCalculator.Core.Parsers.Visitors;
using System;
using System.Collections.Generic;

namespace PracticeFusion.MmeCalculator.UnitTests.Parsers.Visitors
{
    internal class CoreParserTestHelper<TVisitor, TParserRuleContext, TOutput>
        where TVisitor : IVisitor<TParserRuleContext, TOutput>, new() where TParserRuleContext : ParserRuleContext
    {
        public CoreParserTestHelper()
        {
            Visitor = new TVisitor();
        }

        public TVisitor Visitor { get; }

        public DefaultParser Parser { get; private set; }

        public void NullContextShouldThrowParseException()
        {
            if (Visitor is IListVisitor<TParserRuleContext, TOutput> ilv)
            {
                // check the "VisitAllRoot" method as well
                ilv.Invoking(x => x.VisitAllRoot(null)).Should().ThrowExactly<ParsingException>()
                    .WithMessage("Empty context.");
            }

            if (Visitor is IManyToOneVisitor<TParserRuleContext, TOutput> mtov)
            {
                // check the "VisitAllRoot" method as well
                mtov.Invoking(x => x.VisitAllRoot(null)).Should().ThrowExactly<ParsingException>()
                    .WithMessage("Empty context.");
            }

            if (Visitor is IVisitorCreator<TParserRuleContext, TOutput> ivc)
            {
                ivc.Invoking(x => x.VisitRoot(null)).Should().ThrowExactly<ParsingException>()
                    .WithMessage("Empty context.");
                return;
            }

            if (Visitor is IVisitorUpdator<TParserRuleContext, TOutput> ivu)
            {
                ivu.Invoking(x => x.VisitRoot(null, default)).Should().ThrowExactly<ParsingException>()
                    .WithMessage("Empty context.");
                return;
            }

            throw new Exception($"Cannot execute null test on {typeof(TVisitor).Name}");
        }

        public DefaultParser DefaultParser(string statement)
        {
            ICharStream stream = CharStreams.fromString(statement);
            ITokenSource lexer = new DefaultLexer(stream);
            ITokenStream tokens = new CommonTokenStream(lexer);
            return new DefaultParser(tokens);
        }

        public DefaultParser DefaultParserWithParseErrors(string statement,
            out List<(ConfidenceEnum Confidence, string ConfidenceReason, List<string>)> parserErrors)
        {
            ICharStream stream = CharStreams.fromString(statement);
            ITokenSource lexer = new DefaultLexer(stream);
            ITokenStream tokens = new CommonTokenStream(lexer);
            Parser = new DefaultParser(tokens);

            // set up the list of errors
            parserErrors =
                new List<(ConfidenceEnum Confidence, string ConfidenceReason, List<string> ExpectedRules)>();
            Parser.RemoveErrorListeners();
            Parser.AddErrorListener(new RuleConfidenceErrorListener(parserErrors));

            return Parser;
        }

        public void ThrowParserErrors(DefaultParser parser, ParserRuleContext tree,
            List<(ConfidenceEnum Confidence, string ConfidenceReason, List<string>)> parserErrors)
        {
            // check for errors or exceptions
            if (parser.NumberOfSyntaxErrors > 0)
            {
                throw new ParsingSyntaxException(parserErrors);
            }

            if (tree.exception != null)
            {
                throw new ParsingException(tree.exception.Message, tree.exception);
            }
        }
    }
}