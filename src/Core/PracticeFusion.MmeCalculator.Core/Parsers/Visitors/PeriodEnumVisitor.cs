using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;

namespace PracticeFusion.MmeCalculator.Core.Parsers.Visitors
{
    internal class PeriodEnumVisitor : IVisitorCreator<DefaultParser.PeriodEnumContext, PeriodEnum>
    {
        public PeriodEnum VisitRoot(DefaultParser.PeriodEnumContext context)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            return context.Start.Type switch
            {
                DefaultLexer.MILLISECOND => PeriodEnum.Millisecond,
                DefaultLexer.SECOND => PeriodEnum.Second,
                DefaultLexer.MINUTE => PeriodEnum.Minute,
                DefaultLexer.HOUR => PeriodEnum.Hour,
                DefaultLexer.DAY => PeriodEnum.Day,
                DefaultLexer.WEEK => PeriodEnum.Week,
                DefaultLexer.MONTH => PeriodEnum.Month,
                DefaultLexer.YEAR => PeriodEnum.Year,
                _ => throw new ParsingException($"Period recognized, but cannot be mapped: '{context.Start.Text}'")
            };
        }
    }
}
