using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;

namespace PracticeFusion.MmeCalculator.Core.Parsers.Visitors
{
    internal class PeriodlyVisitor : IVisitorCreator<DefaultParser.PeriodlyContext, PeriodEnum>
    {
        public PeriodEnum VisitRoot(DefaultParser.PeriodlyContext context)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            return context.Start.Type switch
            {
                DefaultLexer.HOURLY => PeriodEnum.Hour,
                DefaultLexer.DAILY => PeriodEnum.Day,
                DefaultLexer.WEEKLY => PeriodEnum.Week,
                DefaultLexer.MONTHLY => PeriodEnum.Month,
                DefaultLexer.YEARLY => PeriodEnum.Year,
                _ => throw new ParsingException($"Period recognized, but cannot be mapped: '{context.Start.Text}'")
            };
        }
    }
}