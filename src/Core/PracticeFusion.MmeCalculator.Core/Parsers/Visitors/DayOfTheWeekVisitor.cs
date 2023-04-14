using PracticeFusion.MmeCalculator.Core.Parsers.Generated;
using System;

namespace PracticeFusion.MmeCalculator.Core.Parsers.Visitors
{
    internal class DayOfTheWeekVisitor : IVisitorCreator<DefaultParser.DayOfTheWeekContext, DayOfWeek>
    {
        public DayOfWeek VisitRoot(DefaultParser.DayOfTheWeekContext context)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            return context.Start.Type switch
            {
                DefaultLexer.MONDAY => DayOfWeek.Monday,
                DefaultLexer.TUESDAY => DayOfWeek.Tuesday,
                DefaultLexer.WEDNESDAY => DayOfWeek.Wednesday,
                DefaultLexer.THURSDAY => DayOfWeek.Thursday,
                DefaultLexer.FRIDAY => DayOfWeek.Friday,
                DefaultLexer.SATURDAY => DayOfWeek.Saturday,
                DefaultLexer.SUNDAY => DayOfWeek.Sunday,
                _ => throw new ParsingException($"Expecting day of the week, but cannot map: '{context.Start.Text}'")
            };
        }
    }
}