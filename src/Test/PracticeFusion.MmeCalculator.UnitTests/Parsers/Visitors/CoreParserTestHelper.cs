using System;
using Antlr4.Runtime;
using FluentAssertions;
using PracticeFusion.MmeCalculator.Core.Parsers;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;
using PracticeFusion.MmeCalculator.Core.Parsers.Visitors;
using PracticeFusion.MmeCalculator.Core.Services;

namespace PracticeFusion.MmeCalculator.UnitTests.Parsers.Visitors
{
    internal class CoreParserTestHelper<TVisitor, TParserRuleContext, TOutput> where TVisitor : IVisitor<TParserRuleContext, TOutput>, new() where TParserRuleContext : ParserRuleContext
    {
        public CoreParserTestHelper()
        {
            Visitor = new TVisitor();
        }

        public TVisitor Visitor { get; }

        public void NullContextShouldThrowParseException()
        {
            if (Visitor is IListVisitor<TParserRuleContext, TOutput> ilv)
            {
                // check the "VisitAllRoot" method as well
                ilv.Invoking(x => x.VisitAllRoot(null)).Should().ThrowExactly<ParsingException>().WithMessage("Empty context.");
            }

            if (Visitor is IManyToOneVisitor<TParserRuleContext, TOutput> mtov)
            {
                // check the "VisitAllRoot" method as well
                mtov.Invoking(x => x.VisitAllRoot(null)).Should().ThrowExactly<ParsingException>().WithMessage("Empty context.");
            }

            if (Visitor is IVisitorCreator<TParserRuleContext, TOutput> ivc)
            {
                ivc.Invoking(x => x.VisitRoot(null)).Should().ThrowExactly<ParsingException>().WithMessage("Empty context.");
                return;
            }

            if (Visitor is IVisitorUpdator<TParserRuleContext, TOutput> ivu)
            {
                ivu.Invoking(x => x.VisitRoot(null, default)).Should().ThrowExactly<ParsingException>().WithMessage("Empty context.");
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
    }
}
