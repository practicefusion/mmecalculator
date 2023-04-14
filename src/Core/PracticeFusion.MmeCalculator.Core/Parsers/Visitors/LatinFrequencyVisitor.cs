using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;

namespace PracticeFusion.MmeCalculator.Core.Parsers.Visitors
{
    internal class LatinFrequencyVisitor : IVisitorUpdator<DefaultParser.LatinFrequencyContext, Frequency>
    {
        public void VisitRoot(DefaultParser.LatinFrequencyContext context, Frequency frequency)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            frequency.ContainsLatinAbbreviations = true;

            var interval = new Interval();
            context.SetStartAndStopIndex(interval);
            interval.ContainsLatinAbbreviations = true;

            switch (context.Start.Type)
            {
                // daily
                case DefaultLexer.QD:
                    interval.Freq = 1;
                    interval.FreqMax = 1;
                    interval.Period = 1;
                    interval.PeriodMax = 1;
                    interval.PeriodUnit = PeriodEnum.Day;
                    break;

                // every day at bedtime
                case DefaultLexer.QHS:
                    interval.Freq = 1;
                    interval.FreqMax = 1;
                    interval.Period = 1;
                    interval.PeriodMax = 1;
                    interval.PeriodUnit = PeriodEnum.Day;
                    frequency.When.Add(EventTimingEnum.BedTime);
                    break;

                // every other day
                case DefaultLexer.QOD:
                    interval.Freq = 1;
                    interval.FreqMax = 1;
                    interval.Period = 2;
                    interval.PeriodMax = 2;
                    interval.PeriodUnit = PeriodEnum.Day;
                    break;

                // twice a day
                case DefaultLexer.BID:
                    interval.Freq = 2;
                    interval.FreqMax = 2;
                    interval.Period = 1;
                    interval.PeriodMax = 1;
                    interval.PeriodUnit = PeriodEnum.Day;
                    break;

                // three times a day
                case DefaultLexer.TID:
                    interval.Freq = 3;
                    interval.FreqMax = 3;
                    interval.Period = 1;
                    interval.PeriodMax = 1;
                    interval.PeriodUnit = PeriodEnum.Day;
                    break;

                // four times a day
                case DefaultLexer.QID:
                    interval.Freq = 4;
                    interval.FreqMax = 4;
                    interval.Period = 1;
                    interval.PeriodMax = 1;
                    interval.PeriodUnit = PeriodEnum.Day;
                    break;

                // every morning
                case DefaultLexer.QAM:
                    interval.Freq = 1;
                    interval.FreqMax = 1;
                    interval.Period = 1;
                    interval.PeriodMax = 1;
                    interval.PeriodUnit = PeriodEnum.Day;
                    frequency.When.Add(EventTimingEnum.Morning);
                    break;

                // every afternoon
                case DefaultLexer.QPM:
                    interval.Freq = 1;
                    interval.FreqMax = 1;
                    interval.Period = 1;
                    interval.PeriodMax = 1;
                    interval.PeriodUnit = PeriodEnum.Day;
                    frequency.When.Add(EventTimingEnum.AfterNoon);
                    break;

                // every night
                case DefaultLexer.QN:
                    interval.Freq = 1;
                    interval.FreqMax = 1;
                    interval.Period = 1;
                    interval.PeriodMax = 1;
                    interval.PeriodUnit = PeriodEnum.Day;
                    frequency.When.Add(EventTimingEnum.Night);
                    break;

                default:
                    throw new ParsingException(
                        $"Expected a latin frequency abbreviation, but cannot map '{context.GetText()}'");
            }

            frequency.Intervals.Add(interval);
        }
    }
}