using System;
using System.Collections.Generic;
using PracticeFusion.MmeCalculator.Core.Services;

namespace PracticeFusion.MmeCalculator.Core.Messages
{
    /// <summary>
    /// The result of a <see cref="Calculator.Calculate(CalculationRequest)"/> operation.
    /// </summary>
    [Serializable]
    public class CalculatedResult
    {
        /// <summary>
        /// The RequestId (a correlation identifier) from the original <see cref="CalculationRequest"/> that was calculated.
        /// </summary>
        public string? RequestId { get; set; }

        /// <summary>
        /// Analysis and summary of the calculation.
        /// </summary>
        public CalculatedResultAnalysis CalculatedResultAnalysis { get; set; } = new();

        /// <summary>
        /// The calculated and parsed results for each of the <see cref="CalculationItem"/>s in the request.
        /// </summary>
        public List<ParsedResult> ParsedResults { get; set; } = new();
    }
}
