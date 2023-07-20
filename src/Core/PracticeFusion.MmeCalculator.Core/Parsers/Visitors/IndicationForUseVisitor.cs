using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;

namespace PracticeFusion.MmeCalculator.Core.Parsers.Visitors
{
    internal class IndicationForUseVisitor : IManyToOneVisitor<DefaultParser.IndicationForUseContext, IndicationForUse>
    {
        public IndicationForUse VisitAllRoot(DefaultParser.IndicationForUseContext[] contexts)
        {
            if (contexts == null)
            {
                throw new ParsingException("Empty context.");
            }

            if (contexts.Length > 1)
            {
                // pretty strict interpretation, leaving it off for now.
                // throw new ParsingException("Ambiguous indications for use: there are multiple indications for use.");
            }

            return VisitRoot(contexts[0]);
        }

        public IndicationForUse VisitRoot(DefaultParser.IndicationForUseContext context)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            var result = new IndicationForUse();
            context.SetStartAndStopIndex(result);

            if (context.indicationPrecursor() != null)
            {
                result.IndicationPrecursor = VisitIndicationPrecursor(context.indicationPrecursor());
                if (ContainsLatinAbbreviations(context.indicationPrecursor()))
                {
                    result.ContainsLatinAbbreviations = true;
                }
            }
            else
            {
                result.IndicationPrecursor = "for";
            }

            if (context.indicationValue() != null)
            {
                result.Indication = VisitIndicationValue(context.indicationValue());
            }

            return result;
        }

        private static string VisitIndicationPrecursor(DefaultParser.IndicationPrecursorContext context)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            return "as needed";
        }

        private static bool ContainsLatinAbbreviations(DefaultParser.IndicationPrecursorContext context)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            return context.PRN() != null;
        }

        private static string VisitIndicationValue(DefaultParser.IndicationValueContext context)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            return context.GetOriginalTextWithSpacing();
        }
    }
}