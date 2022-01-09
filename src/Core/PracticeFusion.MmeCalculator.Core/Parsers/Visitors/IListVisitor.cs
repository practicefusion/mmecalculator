using System.Collections.Generic;
using Antlr4.Runtime;

namespace PracticeFusion.MmeCalculator.Core.Parsers.Visitors
{
    internal interface IListVisitor<TParserRuleContext, TOutput> : IVisitorCreator<TParserRuleContext, TOutput> where TParserRuleContext : ParserRuleContext
    {
        List<TOutput> VisitAllRoot(TParserRuleContext[] contexts);
    }
}
