using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;

namespace PracticeFusion.MmeCalculator.Core.Parsers.Visitors
{
    internal class DoseUnitVisitor : IVisitorCreator<DefaultParser.DoseUnitContext, DoseUnit>
    {
        private readonly FormExpressionVisitor _formVisitor = new();

        public DoseUnit VisitRoot(DefaultParser.DoseUnitContext context)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            var result = new DoseUnit();
            context.SetStartAndStopIndex(result);

            if (context.formExpression() != null)
            {
                result.Form = _formVisitor.VisitRoot(context.formExpression());
            }
            else
            {
                result.UnitOfMeasure = new DoseUnitOfMeasureVisitor().VisitRoot(context.doseUnitOfMeasure());
            }

            return result;
        }
    }
}