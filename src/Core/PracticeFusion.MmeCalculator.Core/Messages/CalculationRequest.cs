using System;
using System.Collections.Generic;

namespace PracticeFusion.MmeCalculator.Core.Messages
{
    /// <summary>
    /// A calculation request
    /// </summary>
    [Serializable]
    public class CalculationRequest
    {
        /// <summary>
        /// A unique identifier for this request. May be used for caching.
        /// </summary>
        public string? RequestId { get; set; }

        /// <summary>
        /// The list of <see cref="CalculationItems"/> to calculate.
        /// </summary>
        public List<CalculationItem> CalculationItems { get; set; } = new();
    }
}
