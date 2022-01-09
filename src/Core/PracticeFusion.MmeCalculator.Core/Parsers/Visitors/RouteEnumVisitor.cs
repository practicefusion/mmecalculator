using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;

namespace PracticeFusion.MmeCalculator.Core.Parsers.Visitors
{
    internal class RouteEnumVisitor : IVisitorCreator<DefaultParser.RouteEnumContext, RouteEnum>
    {
        public RouteEnum VisitRoot(DefaultParser.RouteEnumContext context)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            return context.Start.Type switch
            {
                DefaultLexer.MOUTH or DefaultLexer.PO or DefaultLexer.ORAL or DefaultLexer.ORALLY => RouteEnum.Orally,
                // UNDER THE TONGUE
                DefaultLexer.UNDER or DefaultLexer.SL or DefaultLexer.SUBLINGUAL or DefaultLexer.SUBLINGUALLY => RouteEnum.Sublingually,
                // FEEDING TUBE
                DefaultLexer.FEEDING or DefaultLexer.GASTROSTOMY => RouteEnum.FeedingTube,
                DefaultLexer.NASALLY => RouteEnum.Nasally,
                DefaultLexer.INTRANASALLY => RouteEnum.Intranasally,
                DefaultLexer.EACH or DefaultLexer.PER => RouteEnum.PerNostril,
                DefaultLexer.RECTAL or DefaultLexer.RECTALLY => RouteEnum.Rectal,
                DefaultLexer.TOPICAL or DefaultLexer.TOPICALLY => RouteEnum.Topically,
                DefaultLexer.TOUPPERTORSO or DefaultLexer.ONSKIN or DefaultLexer.TOSKIN or DefaultLexer.TRANSDERMAL or DefaultLexer.TRANSDERMALLY => RouteEnum.Transdermally,
                _ => throw new ParsingException($"Route recognized, but cannot be mapped: '{context.Start.Text}'"),
            };
        }

        public static bool ContainsLatinAbbreviations(DefaultParser.RouteEnumContext context)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            if (context.Start.Type == DefaultLexer.PO)
                return true;

            return false;
        }
    }
}
