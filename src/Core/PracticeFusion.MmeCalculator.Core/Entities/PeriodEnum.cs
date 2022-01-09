using System;

namespace PracticeFusion.MmeCalculator.Core.Entities
{
    /// <summary>
    /// Period enumeration
    /// </summary>
    [Serializable]
    public enum PeriodEnum
    {
        /// <summary>
        /// Millisecond (ms)
        /// </summary>
        [ParseableEnum("millisecond", "milliseconds")]
        Millisecond,

        /// <summary>
        /// Second (s)
        /// </summary>
        [ParseableEnum("second", "seconds")] Second,

        /// <summary>
        /// Minute (m)
        /// </summary>
        [ParseableEnum("minute", "minutes")] Minute,

        /// <summary>
        /// Hour (h)
        /// </summary>
        [ParseableEnum("hour", "hours")] Hour,

        /// <summary>
        /// Day (d)
        /// </summary>
        [ParseableEnum("day", "days")] Day,

        /// <summary>
        /// Week
        /// </summary>
        [ParseableEnum("week", "weeks")] Week,

        /// <summary>
        /// Month
        /// </summary>
        [ParseableEnum("month", "months")] Month,

        /// <summary>
        /// Year (y)
        /// </summary>
        [ParseableEnum("year", "years")] Year
    }
}
