using PracticeFusion.MmeCalculator.Core.Parsers.Generated;

namespace PracticeFusion.MmeCalculator.Core.Parsers.Visitors
{
    internal class DosageSeparatorVisitor : IVisitorCreator<DefaultParser.DosageSeparatorContext, string>
    {
        public string VisitRoot(DefaultParser.DosageSeparatorContext context)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            return context.GetOriginalTextWithSpacing();
        }
    }
}