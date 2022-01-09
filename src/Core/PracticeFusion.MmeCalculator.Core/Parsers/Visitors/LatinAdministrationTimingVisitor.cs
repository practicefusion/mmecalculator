using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;

namespace PracticeFusion.MmeCalculator.Core.Parsers.Visitors
{
    internal class LatinAdministrationTimingVisitor : IVisitorUpdator<DefaultParser.LatinAdministrationTimingContext, Frequency>
    {
        public void VisitRoot(DefaultParser.LatinAdministrationTimingContext context, Frequency result)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            result.ContainsLatinAbbreviations = true;

            // could start with EVERY, so use the .Stop token
            switch (context.Stop.Type)
            {
                case DefaultLexer.HS:
                    result.When.Add(EventTimingEnum.BedTime);
                    break;

                case DefaultLexer.QAC:
                    result.When.Add(EventTimingEnum.BeforeEveryMeal);
                    break;

                case DefaultLexer.QPC:
                    result.When.Add(EventTimingEnum.AfterEveryMeal);
                    break;

                default:
                    throw new ParsingException(
                        $"Expected administration timing, but cannot parse '{context.GetOriginalTextWithSpacing()}'");
            }
        }
    }
}
