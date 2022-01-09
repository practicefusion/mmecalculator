using Antlr4.Runtime;

namespace PracticeFusion.MmeCalculator.Core.Parsers.Visitors
{
    internal interface IVisitor<TParserRuleContext, TOutput> where TParserRuleContext: ParserRuleContext
    {
    }

    internal interface IVisitorCreator<TParserRuleContext, TOutput> : IVisitor<TParserRuleContext, TOutput> where TParserRuleContext : ParserRuleContext
    {
        TOutput VisitRoot(TParserRuleContext context);
    }

    internal interface IVisitorUpdator<TParserRuleContext, TOutput> : IVisitor<TParserRuleContext, TOutput> where TParserRuleContext : ParserRuleContext
    {
        void VisitRoot(TParserRuleContext context, TOutput result);
    }

}
