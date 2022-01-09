using PracticeFusion.MmeCalculator.Core.Parsers.Generated;

namespace PracticeFusion.MmeCalculator.Core.Parsers.Visitors
{
    internal class RouteInstructionVisitor : IVisitorCreator<DefaultParser.RouteInstructionContext, string>
    {
        public string VisitRoot(DefaultParser.RouteInstructionContext context)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            return context.GetOriginalTextWithSpacing();
        }
    }
}
