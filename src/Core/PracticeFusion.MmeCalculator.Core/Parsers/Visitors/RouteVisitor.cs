using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;
using System.Collections.Generic;
using System.Linq;

namespace PracticeFusion.MmeCalculator.Core.Parsers.Visitors
{
    internal class RouteVisitor : IManyToOneVisitor<DefaultParser.RouteContext, Route>
    {
        public Route VisitAllRoot(DefaultParser.RouteContext[] contexts)
        {
            if (contexts == null)
            {
                throw new ParsingException("Empty context.");
            }

            var result = new Route();
            contexts.SetStartAndStopIndex(result);
            result.ValueEnums = new List<RouteEnum>();

            foreach (DefaultParser.RouteContext routeContext in contexts)
            {
                Route route = VisitRoot(routeContext);

                // merge the routes
                if (route.ContainsLatinAbbreviations)
                {
                    result.ContainsLatinAbbreviations = true;
                }

                // if the route instructions are not the same, exit
                if (result.RouteInstruction != null && result.RouteInstruction != route.RouteInstruction)
                {
                    throw new ParsingException(
                        $"Cannot parse multiple routes '{contexts.GetOriginalTextWithSpacing()}'");
                }

                // merge the route instruction
                result.RouteInstruction = route.RouteInstruction;

                // merge route enums
                result.ValueEnums.AddRange(route.ValueEnums);
            }

            // whittle the enums down to uniques
            if (result.ValueEnums.Count > 1)
            {
                result.ValueEnums = result.ValueEnums.GroupBy(r => r.ToString()).Select(g => g.First()).ToList();
            }

            return result;
        }

        public Route VisitRoot(DefaultParser.RouteContext context)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            var route = new Route();
            context.SetStartAndStopIndex(route);

            route.ValueEnums = new List<RouteEnum>();

            if (context.routeInstruction() != null)
            {
                route.RouteInstruction = new RouteInstructionVisitor().VisitRoot(context.routeInstruction());
            }

            var routeEnumVisitor = new RouteEnumVisitor();
            DefaultParser.RouteEnumContext[] routeEnumContexts = context.routeEnum();
            foreach (DefaultParser.RouteEnumContext routeEnumContext in routeEnumContexts)
            {
                route.ValueEnums.Add(routeEnumVisitor.VisitRoot(routeEnumContext));
                if (RouteEnumVisitor.ContainsLatinAbbreviations(routeEnumContext))
                {
                    route.ContainsLatinAbbreviations = true;
                }
            }

            return route;
        }
    }
}