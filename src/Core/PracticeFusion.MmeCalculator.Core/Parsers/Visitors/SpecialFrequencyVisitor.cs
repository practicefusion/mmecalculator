using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;

namespace PracticeFusion.MmeCalculator.Core.Parsers.Visitors
{
    internal class SpecialFrequencyVisitor : IVisitorUpdator<DefaultParser.SpecialFrequencyContext, Frequency>
    {
        public void VisitRoot(DefaultParser.SpecialFrequencyContext context, Frequency frequency)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            // there are two special rules:
            // 1) "every 4 hours (5 times/day)"
            // 2) "as one dose"

            // first rule
            if (context.EVERY() != null)
            {
                // special case, validate that we're dealing with the numbers we expect to:
                if (context.numericValue()[0].Start.Text != "4" ||
                    context.numericValue()[1].Start.Text != "5")
                {
                    throw new ParsingException(
                        $"Cannot parse the special frequency '{context.GetOriginalTextWithSpacing()}'");
                }


                var result = new Interval();
                context.SetStartAndStopIndex(result);

                result.Freq = 5;
                result.FreqMax = 5;
                result.Period = 1;
                result.PeriodMax = 1;
                result.PeriodUnit = PeriodEnum.Day;

                frequency.Intervals.Add(result);
            }
            else
            {
                // second rule
                // validate that the number is one
                if (context.NUMBER() == null || context.NUMBER().GetText() != "1")
                {
                    throw new ParsingException(
                        $"Cannot parse the special frequency '{context.GetOriginalTextWithSpacing()}'");
                }

                var result = new Interval();
                context.SetStartAndStopIndex(result);
                result.Freq = 1;
                result.FreqMax = 1;
                result.Period = 1;
                result.PeriodMax = 1;
                result.PeriodUnit = PeriodEnum.Day;

                frequency.Intervals.Add(result);
            }
        }
    }
}