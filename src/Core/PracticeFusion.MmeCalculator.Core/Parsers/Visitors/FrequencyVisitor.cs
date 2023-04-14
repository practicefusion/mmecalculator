using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;
using System;
using System.Collections.Generic;

namespace PracticeFusion.MmeCalculator.Core.Parsers.Visitors
{
    internal class FrequencyVisitor : IManyToOneVisitor<DefaultParser.FrequencyContext, Frequency>
    {
        private readonly LatinAdministrationTimingVisitor _latinAdministrationTimingVisitor = new();
        private readonly LatinFrequencyVisitor _latinFrequencyVisitor = new();
        private readonly SpecialFrequencyVisitor _specialFrequencyVisitor = new();

        public Frequency VisitAllRoot(DefaultParser.FrequencyContext[] contexts)
        {
            if (contexts == null || contexts.Length == 0)
            {
                throw new ParsingException("Empty context.");
            }

            Frequency frequency = VisitRoot(contexts);
            Frequency.Rationalize(frequency);

            return frequency;
        }

        public Frequency VisitRoot(DefaultParser.FrequencyContext context)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            return VisitRoot(new[] { context });
        }

        private Frequency VisitRoot(DefaultParser.FrequencyContext[] contexts)
        {
            if (contexts == null || contexts.Length == 0)
            {
                throw new ParsingException("Empty context.");
            }

            var result = new Frequency();
            contexts.SetStartAndStopIndex(result);

            foreach (DefaultParser.FrequencyContext frequencyContext in contexts)
            {
                if (frequencyContext.specialFrequency() != null)
                {
                    _specialFrequencyVisitor.VisitRoot(frequencyContext.specialFrequency(), result);
                }

                if (frequencyContext.basicFrequency() != null)
                {
                    VisitBasicFrequency(frequencyContext.basicFrequency(), result);
                }

                if (frequencyContext.dayFrequency() != null)
                {
                    VisitDayFrequency(frequencyContext.dayFrequency(), result);
                }

                if (frequencyContext.latinFrequency() != null)
                {
                    _latinFrequencyVisitor.VisitRoot(frequencyContext.latinFrequency(), result);
                }

                if (frequencyContext.administrationTiming() != null)
                {
                    VisitAdministrationTiming(frequencyContext.administrationTiming(), result);
                }
            }

            return result;
        }

        private void VisitBasicFrequency(DefaultParser.BasicFrequencyContext context, Frequency frequency)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            var interval = new Interval();
            context.SetStartAndStopIndex(interval);

            interval.ExpressAsPer = context.PER() != null;
            interval.ContainsLatinAbbreviations = context.Q_Q() != null;
            frequency.ContainsLatinAbbreviations = interval.ContainsLatinAbbreviations;

            if (context.frequencyVal() != null)
            {
                VisitFrequencyVal(context.frequencyVal(), interval);
            }

            if (context.periodVal() != null)
            {
                if (context.periodVal().numericValue() != null)
                {
                    interval.Period = new NumericValueVisitor().VisitRoot(context.periodVal().numericValue());
                    interval.PeriodMax = interval.Period;
                }
                else
                {
                    Tuple<decimal, decimal> minMax =
                        new RangeNumericValueVisitor().VisitRoot(context.periodVal().rangeNumericValue());
                    interval.Period = minMax.Item1;
                    interval.PeriodMax = minMax.Item2;
                }
            }

            if (context.period() != null)
            {
                VisitPeriod(context.period(), interval);
            }

            if (context.periodly() != null)
            {
                VisitPeriodly(context.periodly(), interval);
            }

            // 5 times qd | once qod | etc.
            if (context.latinFrequency() != null)
            {
                var mergeFrequency = new Frequency();
                _latinFrequencyVisitor.VisitRoot(context.latinFrequency(), mergeFrequency);
                if (mergeFrequency.ContainsLatinAbbreviations)
                {
                    frequency.ContainsLatinAbbreviations = true;
                }

                // merge in the timing, and merge the interval
                if (mergeFrequency.When.Count > 0)
                {
                    frequency.When.AddRange(mergeFrequency.When);
                }

                if (mergeFrequency.Intervals.Count > 0)
                {
                    Interval? mergeInterval = mergeFrequency.Intervals[0];

                    // merge the frequency
                    if (interval.Freq < mergeInterval.Freq || interval.FreqMax < mergeInterval.FreqMax)
                    {
                        interval.Freq = mergeInterval.Freq;
                        interval.FreqMax = mergeInterval.FreqMax;
                    }

                    // merge the period timing
                    if (interval.Period < mergeInterval.Period || interval.PeriodMax < mergeInterval.PeriodMax)
                    {
                        interval.Period = mergeInterval.Period;
                        interval.PeriodMax = mergeInterval.PeriodMax;
                    }

                    // merge the period unit
                    if (mergeInterval.PeriodUnit != null)
                    {
                        if (interval.PeriodUnit != null && interval.PeriodUnit != mergeInterval.PeriodUnit)
                        {
                            throw new ParsingException(
                                $"Ambiguous periods: cannot combine '{interval}' and '{mergeInterval}'");
                        }

                        interval.PeriodUnit = mergeInterval.PeriodUnit;
                    }
                }
            }

            frequency.Intervals.Add(interval);
        }

        private static void VisitDayFrequency(DefaultParser.DayFrequencyContext context, Frequency frequency)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            if (context.dayOfTheWeek() != null && context.dayOfTheWeek().Length > 0)
            {
                var dayOfTheWeekVisitor = new DayOfTheWeekVisitor();
                frequency.DaysOfWeek = new List<DayOfWeek>();
                foreach (DefaultParser.DayOfTheWeekContext dayOfTheWeek in context.dayOfTheWeek())
                {
                    frequency.DaysOfWeek.Add(dayOfTheWeekVisitor.VisitRoot(dayOfTheWeek));
                }
            }
        }

        private void VisitAdministrationTiming(DefaultParser.AdministrationTimingContext context, Frequency frequency)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            if (context.latinAdministrationTiming() != null)
            {
                _latinAdministrationTimingVisitor.VisitRoot(context.latinAdministrationTiming(), frequency);
            }

            if (context.specificTimes() != null)
            {
                VisitSpecificTimes(context.specificTimes(), frequency);
            }

            if (context.timeOfDay() != null)
            {
                VisitTimeOfDay(context.timeOfDay(), frequency);
            }

            if (context.timingEvent() != null)
            {
                VisitTimingEvent(context.timingEvent(), frequency);
            }
        }

        private static void VisitSpecificTimes(DefaultParser.SpecificTimesContext contexts, Frequency result)
        {
            if (contexts == null)
            {
                throw new ParsingException("Empty context.");
            }

            foreach (DefaultParser.SpecificTimeContext specificTimeContext in contexts.specificTime())
            {
                var candidateTime = specificTimeContext.GetOriginalTextWithSpacing();
                if (DateTime.TryParse(candidateTime, out DateTime parseResult))
                {
                    result.TimeOfDay.Add(parseResult.ToString("HH:mm"));
                }
                else
                {
                    throw new ParsingException(
                        $"Expected time of day in hour, or hour:minute format, but found '{candidateTime}'");
                }
            }
        }

        private static void VisitTimeOfDay(DefaultParser.TimeOfDayContext context, Frequency result)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            if (context.periodBeforeOrAfter() != null)
            {
                throw new ParsingException(
                    $"Cannot parse timing instructions: '{context.GetOriginalTextWithSpacing()}'");
            }

            if (context.MORNING() != null)
            {
                result.When.Add(EventTimingEnum.Morning);
            }

            if (context.AFTERNOON() != null)
            {
                result.When.Add(EventTimingEnum.InTheAfternoon);
            }

            if (context.NOON() != null || context.MIDDAY() != null)
            {
                if (context.BEFORE() != null)
                {
                    result.When.Add(EventTimingEnum.BeforeNoon);
                }

                if (context.AFTER() != null)
                {
                    result.When.Add(EventTimingEnum.AfterNoon);
                }

                if (context.AT() != null)
                {
                    result.When.Add(EventTimingEnum.AtNoon);
                }
            }

            if (context.EVENING() != null || context.NIGHT() != null)
            {
                result.When.Add(EventTimingEnum.Night);
            }

            if (context.BEDTIME() != null)
            {
                result.When.Add(EventTimingEnum.BedTime);
            }
        }

        private static void VisitTimingEventMeal(DefaultParser.TimingEventContext context, Frequency result, bool every,
            bool specific,
            EventTimingEnum before, EventTimingEnum with, EventTimingEnum after)
        {
            // when "every" or "each" is present, infer 3 (all meals)
            // when there is a specific meal (breakfast, lunch, dinner), infer 1.
            // otherwise, infer at least 1
            result.Intervals.Add(InferMealInterval(every ? 3 : 1));

            if (context.BEFORE() != null)
            {
                result.When.Add(before);
            }

            if (context.WITH() != null)
            {
                result.When.Add(with);
            }

            if (context.AFTER() != null)
            {
                result.When.Add(after);
            }
        }

        private static Interval InferMealInterval(int countOfMeals)
        {
            return new Interval
            {
                Freq = countOfMeals,
                FreqMax = countOfMeals,
                Period = 1,
                PeriodMax = 1,
                PeriodUnit = PeriodEnum.Day,
                ExpressAsPer = false,
                Inferred = true
            };
        }

        private static void VisitTimingEvent(DefaultParser.TimingEventContext context, Frequency result)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            // we will eventually get to offsetTimings, but for now:
            if (context.periodBeforeOrAfter() != null)
            {
                throw new ParsingException(
                    $"Identified an administration timing, but cannot parse offset timings yet '{context.GetOriginalTextWithSpacing()}'");
            }

            var every = context.EVERY() != null || context.EACH() != null;
            if (context.meals()?.BREAKFAST() != null)
            {
                VisitTimingEventMeal(context, result, every, true, EventTimingEnum.BeforeBreakfast,
                    EventTimingEnum.WithBreakfast, EventTimingEnum.AfterBreakfast);
            }

            if (context.meals()?.LUNCH() != null)
            {
                VisitTimingEventMeal(context, result, every, true, EventTimingEnum.BeforeLunch,
                    EventTimingEnum.WithLunch, EventTimingEnum.AfterLunch);
            }

            if (context.meals()?.DINNER() != null)
            {
                VisitTimingEventMeal(context, result, every, true, EventTimingEnum.BeforeDinner,
                    EventTimingEnum.WithDinner, EventTimingEnum.AfterDinner);
            }

            if (context.meals()?.MEAL() != null)
            {
                if (every)
                {
                    VisitTimingEventMeal(context, result, every, false, EventTimingEnum.BeforeEveryMeal,
                        EventTimingEnum.WithEveryMeal, EventTimingEnum.AfterEveryMeal);
                }
                else
                {
                    VisitTimingEventMeal(context, result, every, false, EventTimingEnum.BeforeMeals,
                        EventTimingEnum.WithMeals, EventTimingEnum.AfterMeals);
                }
            }
        }

        private static void VisitFrequencyVal(DefaultParser.FrequencyValContext context, Interval interval)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            if (context.Start.Type == DefaultLexer.ONCE)
            {
                interval.Freq = 1;
                interval.FreqMax = 1;
                return;
            }

            if (context.Start.Type == DefaultLexer.TWICE)
            {
                interval.Freq = 2;
                interval.FreqMax = 2;
                return;
            }

            if (context.Start.Type == DefaultLexer.THRICE)
            {
                interval.Freq = 3;
                interval.FreqMax = 3;
                return;
            }

            if (context.numericValue() != null)
            {
                interval.Freq = new NumericValueVisitor().VisitRoot(context.numericValue());
                interval.FreqMax = interval.Freq;
                return;
            }

            if (context.rangeNumericValue() != null)
            {
                Tuple<decimal, decimal> minMax = new RangeNumericValueVisitor().VisitRoot(context.rangeNumericValue());
                interval.Freq = minMax.Item1;
                interval.FreqMax = minMax.Item2;
            }
        }

        private static void VisitPeriod(DefaultParser.PeriodContext context, Interval interval)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            if (context.ordinalNumeric() != null)
            {
                interval.Period = new OrdinalNumericVisitor().VisitRoot(context.ordinalNumeric());
                interval.PeriodMax = interval.Period;
            }
            else if (context.OTHER() != null)
            {
                // as in every OTHER, or a period count of 2
                interval.Period = 2;
                interval.PeriodMax = 2;
            }
            else
            {
                // the period is implicitly 1, as in
                // 'every day' is equivalent to 'every one day'
                // assuming there is no period/period max already set:
                if (interval.Period == 0 && interval.PeriodMax == 0)
                {
                    interval.Period = 1;
                    interval.PeriodMax = 1;
                }
            }

            interval.PeriodUnit = new PeriodEnumVisitor().VisitRoot(context.periodEnum());
        }

        private static void VisitPeriodly(DefaultParser.PeriodlyContext context, Interval interval)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            interval.Period = 1;
            interval.PeriodMax = 1;
            interval.PeriodUnit = new PeriodlyVisitor().VisitRoot(context);
        }
    }
}