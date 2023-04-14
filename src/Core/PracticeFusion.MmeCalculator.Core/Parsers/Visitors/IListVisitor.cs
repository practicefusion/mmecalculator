using Antlr4.Runtime;
using System.Collections.Generic;

namespace PracticeFusion.MmeCalculator.Core.Parsers.Visitors
{
    internal interface IListVisitor<TParserRuleContext, TOutput> : IVisitorCreator<TParserRuleContext, TOutput>
        where TParserRuleContext : ParserRuleContext
    {
        List<TOutput> VisitAllRoot(TParserRuleContext[] contexts);
    }
}