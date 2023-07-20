using PracticeFusion.MmeCalculator.Core.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticeFusion.MmeCalculator.Core.Entities
{
    /// <summary>
    ///     Frequency
    /// </summary>
    /// <inheritdoc />
    [Serializable]
    public class Frequency : BaseParsedEntity
    {
        /// <summary>
        ///     Indicates whether the frequency contains latin abbreviations like "bid"
        /// </summary>
        public bool ContainsLatinAbbreviations { get; set; }

        /// <summary>
        ///     Intervals, e.g. "2 times every hour"
        /// </summary>
        public List<Interval> Intervals { get; set; } = new();

        /// <summary>
        ///     Event timing, see <see cref="EventTimingEnum" />
        /// </summary>
        public List<EventTimingEnum> When { get; set; } = new();

        /// <summary>
        ///     One or more specific times of day, e.g. "8 am"
        /// </summary>
        public List<string> TimeOfDay { get; set; } = new();

        /// <summary>
        ///     One or more days of the week
        /// </summary>
        public List<DayOfWeek> DaysOfWeek { get; set; } = new();

        /// <summary>
        ///     The maximum daily frequency, or shortest intervals in a given day.
        /// </summary>
        public decimal MaximumDailyFrequency
        {
            get
            {
                // maximum intervals in a day
                var intervalMax = Intervals.Count > 0 ? Intervals.Max(x => x.MaximumDailyFrequency) : 0;

                // if there are no intervals in a day, but there are DaysOfWeek, count that as 1
                // e.g. take 1 tablet every Monday
                if (intervalMax == 0 && DaysOfWeek.Count > 0)
                {
                    intervalMax = 1;
                }

                // get the highest frequency
                // return Math.Max(intervalMax, MaximumDailyTiming);
                return Math.Max(intervalMax, MaximumDailyTiming);
            }
        }

        private decimal MaximumDailyTiming => Math.Max(TimeOfDay.Count, When.Count(x => !x.EventTimingAboutFood()));

        internal static void Rationalize(Frequency frequency)
        {
            // multiple intervals would be "twice a day three times a day four times a day"
            // we may dig into that but for now, with only frequency and period to work with,
            // it is unlikely that we could parse this.
            if (frequency.Intervals.Count > 2)
            {
                throw new ParsingException(
                    $"Ambiguous frequency: cannot parse frequencies with more than two intervals: '{frequency.HumanReadable}'");
            }

            RationalizeEventsWithProximity(frequency);

            // When no interval is present, infer one
            RationalizeInjectInferredIntervalWhenNotPresent(frequency);

            // When there are mergeable intervals, merge them
            RationalizeMergeIntervals(frequency);

            RationalizeMinMustNotBeGreaterThanMax(frequency);
            RationalizeDaysOfTheWeek(frequency);
            RationalizeFrequencyMustHavePeriod(frequency);
            RationalizeMaxIntervalsAndTimingsAreEquivalent(frequency);
            RationalizeCannotHaveMoreThanOneTimingWhenFoodIsInvolved(frequency);
        }

        private static void RationalizeCannotHaveMoreThanOneTimingWhenFoodIsInvolved(Frequency frequency)
        {
            if (frequency.When.Count > 1 &&
                frequency.When.Any(x => x.EventTimingAboutFood()))
            {
                throw new ParsingException($"Ambiguous event timing directions '{frequency.HumanReadable}'");
            }
        }

        private static void RationalizeEventsWithProximity(Frequency frequency)
        {
            // Event timing with proximity will be calculated as two separate events for timing purposes.
            // This means that "night" and "bedtime" would be two separate times. We prefer "bedtime".
            if (frequency.When.Count > 0 &&
                frequency.When.Contains(EventTimingEnum.Night) &&
                frequency.When.Contains(EventTimingEnum.BedTime))
            {
                frequency.When.Remove(EventTimingEnum.Night);
            }
        }

        private static void RationalizeMaxIntervalsAndTimingsAreEquivalent(Frequency frequency)
        {
            // if there are any items in the time-of-day list, and the count of that list
            // is not the same as the daily frequency (i.e. "2 times" vs "8am, noon and 6pm")

            // however, it is common enough to express it as "once daily at 8am and 6pm".
            // so we only examine frequencies greater than 1.
            var maxInterval = frequency.Intervals.Count > 0 ? frequency.Intervals.Max(x => x.MaximumDailyFrequency) : 0;
            if (maxInterval > 1)
            {
                var maxTiming = frequency.MaximumDailyTiming;

                if (maxTiming > 0 && maxTiming != maxInterval)
                {
                    throw new ParsingException(
                        $"Ambiguous frequency: contradicting directions '{frequency.HumanReadable}'");
                }
            }
        }

        private static void RationalizeFrequencyMustHavePeriod(Frequency frequency)
        {
            // if there is a frequency, but no period, mark as ambiguous
            // e.g. take 1 tablet 3 times
            if (frequency.Intervals.Any(x => x.Freq > 0) && frequency.Intervals.TrueForAll(x => !x.PeriodUnit.HasValue))
            {
                throw new ParsingException("Ambiguous frequency: there is no period.");
            }
        }

        private static void RationalizeMergeIntervals(Frequency frequency)
        {
            // merge duplicates: e.g. "bid daily" should be expressed as
            // "2 times every day", not "2 times every day every day"

            // combine intervals with the same period, so that expressions like
            // "2 times a day every other day" are merged into "2 times every other day"

            // but should not merge if either is inferred
            if (frequency.Intervals.Count(x => !x.Inferred) > 1)
            {
                // merge if possible
                var mergedInterval = Interval.MergeInterval(frequency.Intervals[0], frequency.Intervals[1]);

                if (mergedInterval == null)
                {
                    throw new ParsingException(
                        $"Ambiguous frequency: could not combine intervals '{frequency.HumanReadable}'");
                }

                frequency.Intervals.Clear();
                frequency.Intervals.Add(mergedInterval);
            }
        }

        private static void RationalizeDaysOfTheWeek(Frequency frequency)
        {
            // if days of the week are present, and the periodUnit is "day",
            // then the periodMax MUST be 1, this prevents statements like:
            // every other day on Monday and Tuesday.
            if (frequency.DaysOfWeek is { Count: > 0 })
            {
                foreach (Interval? interval in frequency.Intervals)
                {
                    if (interval.PeriodUnit == PeriodEnum.Day && interval.PeriodMax != 1)
                    {
                        throw new ParsingException(
                            $"Ambiguous frequency: days of the week require a period of 1 day, found {interval.PeriodMax}");
                    }
                }
            }
        }

        private static void RationalizeMinMustNotBeGreaterThanMax(Frequency frequency)
        {
            // mins must be not be greater than max
            foreach (Interval? interval in frequency.Intervals)
            {
                if (interval.Freq > interval.FreqMax || interval.Period > interval.PeriodMax)
                {
                    throw new ParsingException(
                        "Unexpected frequency and period values must not be greater than the respective max value.");
                }
            }
        }

        private static void RationalizeInjectInferredIntervalWhenNotPresent(Frequency frequency)
        {
            if ((frequency.TimeOfDay.Count > 0 || frequency.When.Count > 0) && frequency.Intervals.Count == 0)
            {
                var maxTiming = frequency.MaximumDailyTiming;

                frequency.Intervals.Add(
                    new Interval
                    {
                        Freq = maxTiming,
                        FreqMax = maxTiming,
                        Period = 1,
                        PeriodMax = 1,
                        PeriodUnit = PeriodEnum.Day,
                        Inferred = true
                    });
            }
        }

        /// <inheritdoc />
        public override string ToString()
        {
            // (times and period) (timing) (days of the week)
            // e.g. "(once a day) (at bedtime) (on Mondays and Thursdays)"

            var sb = new StringBuilder();

            // times and period
            if (Intervals.Count > 0)
            {
                foreach (Interval? interval in Intervals.Where(x => !x.Inferred))
                {
                    sb.AppendFormat("{0}{1}", sb.Length > 0 ? " " : "", interval.ToString(DaysOfWeek?.Count > 0));
                }
            }

            // timing
            if (When.Count > 0)
            {
                ExpressTiming(sb);
            }

            // time of day
            if (TimeOfDay.Count > 0)
            {
                ExpressTimeOfDay(sb);
            }

            // days of the week
            if (DaysOfWeek?.Count > 0)
            {
                ExpressDaysOfWeek(sb);
            }

            return sb.ToString();
        }

        private void ExpressDaysOfWeek(StringBuilder sb)
        {
            sb.AppendFormat("{0}every ", sb.Length > 0 ? " " : "");

            for (var i = 0; i < DaysOfWeek.Count; i++)
            {
                // first or first and last
                if (i == 0 || DaysOfWeek.Count == 1)
                {
                    sb.Append(DaysOfWeek[0].ToString());
                }
                else
                {
                    // last one
                    if (i + 1 >= DaysOfWeek.Count)
                    {
                        sb.AppendFormat(" and {0}", DaysOfWeek[i].ToString());
                    }
                    else
                    {
                        // everything in the middle
                        sb.AppendFormat(", {0}", DaysOfWeek[i].ToString());
                    }
                }
            }
        }

        private void ExpressTimeOfDay(StringBuilder sb)
        {
            sb.AppendFormat("{0}at {1}", sb.Length > 0 ? " " : "", TimeOfDay[0]);

            for (var i = 1; i < TimeOfDay.Count; i++)
            {
                var joiner = ", ";
                if (i == TimeOfDay.Count - 1)
                {
                    joiner = " and ";
                }

                sb.Append(joiner + TimeOfDay[i]);
            }
        }

        private void ExpressTiming(StringBuilder sb)
        {
            if (sb.Length > 0)
            {
                sb.Append(' ');
            }

            for (var i = 0; i < When.Count; i++)
            {
                // first or first and last
                if (i == 0 || When.Count == 1)
                {
                    sb.Append(ExpressEventTiming(When[i]));
                }
                else
                {
                    // last one
                    if (i + 1 >= When.Count)
                    {
                        sb.AppendFormat(" and {0}", ExpressEventTiming(When[i]));
                    }
                    else
                    {
                        // everything in the middle
                        sb.AppendFormat(", {0}", ExpressEventTiming(When[i]));
                    }
                }
            }
        }

        private static string ExpressEventTiming(EventTimingEnum timing)
        {
            ParseableEnumAttribute data = timing.GetParseableEnumData();
            return data.FriendlyName;
        }
    }
}