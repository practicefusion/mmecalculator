using Antlr4.Runtime;

namespace PracticeFusion.MmeCalculator.Core.Parsers.Visitors
{
    internal interface IManyToOneVisitor<TParserRuleContext, TOutput> : IVisitorCreator<TParserRuleContext, TOutput>
        where TParserRuleContext : ParserRuleContext
    {
        TOutput VisitAllRoot(TParserRuleContext[] contexts);
    }
}