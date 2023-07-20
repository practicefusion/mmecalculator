using System;

namespace PracticeFusion.MmeCalculator.Core.Entities
{
    /// <summary>
    ///     Duration, e.g. "for 30 days"
    /// </summary>
    /// <inheritdoc />
    [Serializable]
    public class Duration : BaseParsedEntity
    {
        /// <summary>
        ///     The count of periods
        /// </summary>
        public decimal Count { get; set; }

        /// <summary>
        ///     The period
        /// </summary>
        public Period? Period { get; set; }

        /// <summary>
        ///     Free text of an unbounded duration, e.g. "thereafter"
        /// </summary>
        public string? UnboundedMessage { get; set; }

        /// <summary>
        ///     True if the duration was parsed as unbounded, e.g. "thereafter"
        /// </summary>
        public bool Unbounded { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            if (Unbounded)
            {
                return UnboundedMessage!;
            }

            return $"for {Count} {Period!.Pluralize(Count)}";
        }
    }
}