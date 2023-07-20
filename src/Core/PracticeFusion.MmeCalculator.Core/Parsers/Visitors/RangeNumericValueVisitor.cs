using PracticeFusion.MmeCalculator.Core.Parsers.Generated;
using System;

namespace PracticeFusion.MmeCalculator.Core.Parsers.Visitors
{
    internal class
        RangeNumericValueVisitor : IVisitorCreator<DefaultParser.RangeNumericValueContext, Tuple<decimal, decimal>>
    {
        public Tuple<decimal, decimal> VisitRoot(DefaultParser.RangeNumericValueContext context)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            var visitor = new NumericValueVisitor();
            var min = visitor.VisitRoot(context.numericValue(0));
            var max = visitor.VisitRoot(context.numericValue(1));
            return new Tuple<decimal, decimal>(min, max);
        }
    }
}