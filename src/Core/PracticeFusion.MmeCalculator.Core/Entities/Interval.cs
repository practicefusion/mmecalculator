using System;
using System.Text;

namespace PracticeFusion.MmeCalculator.Core.Entities
{
    /// <summary>
    ///     An interval of frequency and/or period
    /// </summary>
    /// <inheritdoc />
    [Serializable]
    public class Interval : BaseParsedEntity
    {
        /// <summary>
        ///     Indicates whether the interval contains latin abbreviations like "bid"
        /// </summary>
        public bool ContainsLatinAbbreviations { get; set; }

        /// <summary>
        ///     The minimum frequency, e.g. <strong>1</strong> time per day (1 is the minimum frequency)
        /// </summary>
        public decimal Freq { get; set; }

        /// <summary>
        ///     The maximum frequency, e.g. 1-<strong>2</strong> times per day (2 is the maximum frequency)
        /// </summary>
        public decimal FreqMax { get; set; }

        /// <summary>
        ///     The minimum period, e.g. 1 time every <strong>4</strong> hours (4 is the minimum period)
        /// </summary>
        public decimal Period { get; set; }

        /// <summary>
        ///     The maximum period, e.g. 1 time every 4-<strong>6</strong> hours (6 is the maximum period)
        /// </summary>
        public decimal PeriodMax { get; set; }

        /// <summary>
        ///     Express the frequency as "per" period, e.g. once <strong>per</strong> hour
        /// </summary>
        public bool ExpressAsPer { get; set; }

        /// <summary>
        ///     The unit of time, e.g. once every <strong>week</strong>
        /// </summary>
        public PeriodEnum? PeriodUnit { get; set; }

        /// <summary>
        ///     Indicates that the Interval was inferred. It will be used for calculations,
        ///     but will be displayed as an empty string in <see cref="ToString()" />.
        /// </summary>
        public bool Inferred { get; set; }

        /// <summary>
        ///     The maximum frequency per day, calculated by multiplying the maximum frequency and the minimum period. For example,
        ///     <strong>1-2 times every 4-6 hours</strong> returns 12 (2 times every 4 hours)
        /// </summary>
        public decimal MaximumDailyFrequency
        {
            get
            {
                var freqMax = FreqMax;

                // otherwise, calculate it from the frequency/period
                int periodsPerDay;

                switch (PeriodUnit)
                {
                    case PeriodEnum.Hour:
                        periodsPerDay = 24;
                        break;

                    case PeriodEnum.Minute:
                        periodsPerDay = 24 * 60;
                        break;

                    case PeriodEnum.Second:
                        periodsPerDay = 24 * 60 * 60;
                        break;

                    case PeriodEnum.Millisecond:
                        periodsPerDay = 24 * 60 * 60 * 1000;
                        break;

                    // in case we're dealing with a period > 1 day, make sure we reset everything
                    // to 1 day: in effect, 1 per week is still 1 per day max
                    case PeriodEnum.Week:
                    case PeriodEnum.Month:
                    case PeriodEnum.Year:
                        periodsPerDay = 1;
                        freqMax = 1;
                        break;

                    default:
                        // no more than 1 day
                        periodsPerDay = 1;
                        break;
                }

                // avoid the divide-by-zero possibility
                if (Period == 0)
                {
                    return 0;
                }

                var period = periodsPerDay / Period;

                // since we're looking at maximum per day, if periodsPerDay/Period is less than 1, set it to one
                if (period < 1)
                {
                    period = 1;
                }

                // take 1 tablet daily has 0 frequency, but is implied as 1
                if (freqMax == 0)
                {
                    freqMax = 1;
                }

                return freqMax * period;
            }
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return ToString(false);
        }

        /// <summary>
        ///     Returns the interval as a string, using "a" instead of "every" where possible, eg.
        ///     "once a day" rather than "once every day".
        /// </summary>
        /// <param name="useAInsteadOfEvery">if true, substitutes "a" instead of "every"</param>
        public string ToString(bool useAInsteadOfEvery)
        {
            if (Inferred)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();

            // times and period
            ExpressFrequencyAndPeriod(sb, useAInsteadOfEvery);

            return sb.ToString();
        }

        internal static Interval? MergeInterval(Interval x, Interval y)
        {
            // if either one is "daily" (i.e. no frequency), then return the other
            // for example, "take 1 tablet every 12 hours daily" is another way of
            // saying "take 1 tablet every 12 hours".
            if (x.HasPeriod(1, PeriodEnum.Day) && x.HasFrequency(0))
            {
                return y;
            }

            if (y.HasPeriod(1, PeriodEnum.Day) && y.HasFrequency(0))
            {
                return x;
            }

            // we cannot merge if there are different period units, but we can merge if
            // either is null
            if (x.PeriodUnit != y.PeriodUnit && x.PeriodUnit != null && y.PeriodUnit != null)
            {
                return null;
            }

            // we cannot merge if the frequencies are greater than 1, and not the same
            if (x.FreqMax > 1 && y.FreqMax > 1 && x.FreqMax != y.FreqMax)
            {
                return null;
            }

            Interval merged = new();

            // identify which one was first in the stream
            Interval first = x.Index < y.Index ? x : y;
            Interval second = first == x ? y : x;

            // combine the index and lengths, starting with the first
            merged.Index = first.Index;
            merged.Length = second.Index + second.Length;

            // other properties (except for inferred--this is not inferred)
            merged.ExpressAsPer = x.ExpressAsPer || y.ExpressAsPer;
            merged.Inferred = false;

            // frequency, period and periodunit
            merged.PeriodUnit = x.PeriodUnit ?? y.PeriodUnit;

            // whoever has the greatest period
            if (x.PeriodMax > y.PeriodMax)
            {
                merged.Period = x.Period;
                merged.PeriodMax = x.PeriodMax;
            }
            else
            {
                merged.Period = y.Period;
                merged.PeriodMax = y.PeriodMax;
            }

            // whoever has the greatest frequency
            if (x.FreqMax > y.FreqMax)
            {
                merged.Freq = x.Freq;
                merged.FreqMax = x.FreqMax;
            }
            else
            {
                merged.Freq = y.Freq;
                merged.FreqMax = y.FreqMax;
            }

            return merged;
        }

        private bool HasFrequency(decimal frequencyCount)
        {
            return HasSameFrequency() && Freq == frequencyCount;
        }

        private bool HasSameFrequency()
        {
            return Freq == FreqMax;
        }

        private bool HasPeriod(decimal periodCount, PeriodEnum periodEnum)
        {
            return HasSamePeriod() && Period == periodCount && PeriodUnit == periodEnum;
        }

        private bool HasSamePeriod()
        {
            return Period == PeriodMax;
        }

        private void ExpressFrequencyAndPeriod(StringBuilder sb, bool useAInsteadOfEvery)
        {
            // special case of "5 times a day..."
            if (HasFrequency(5) && HasPeriod(1, PeriodEnum.Day))
            {
                sb.AppendFormat("{0}{1}", sb.Length > 0 ? " " : "", "every 4 hours (5 times/day)");
                return;
            }

            // no need to say "1 time every 6 hours", just enough to say "every 6 hours"
            if (HasSameFrequency() && Freq > 0)
            {
                if (Freq == 1 && ExpressAsPer)
                {
                    sb.AppendFormat("{0}{1}", sb.Length > 0 ? " " : "", "once");
                }

                if (Freq > 1)
                {
                    sb.AppendFormat("{0}{1} times", sb.Length > 0 ? " " : "", Freq);
                }
            }

            if (!HasSameFrequency())
            {
                sb.AppendFormat("{0}-{1} time{2}", Freq, FreqMax, FreqMax != 1 ? "s" : "");
            }

            if (PeriodUnit.HasValue)
            {
                if (HasSamePeriod())
                {
                    sb.AppendFormat(
                        "{0}{1} {2}{3}",
                        sb.Length > 0 ? " " : "",
                        ExpressAsPer ? "per" : useAInsteadOfEvery ? "a" : "every",
                        Period == 1 ? "" : Period + " ",
                        new Period { ValueEnum = PeriodUnit.Value }.Pluralize(Period));
                }
                else
                {
                    sb.AppendFormat(
                        "{0}every {1}-{2} {3}",
                        sb.Length > 0 ? " " : "",
                        Period,
                        PeriodMax,
                        new Period { ValueEnum = PeriodUnit.Value }.Pluralize(PeriodMax));
                }
            }
        }
    }
}