using System;

namespace PracticeFusion.MmeCalculator.Core.Messages
{
    /// <summary>
    ///     An rxnorm code and a sig to calculate.
    /// </summary>
    [Serializable]
    public class CalculationItem
    {
        /// <summary>
        ///     Should include the request item id. If it is not provided, it will be set by the server.
        /// </summary>
        public string? RequestItemId { get; set; }

        /// <summary>
        ///     RxNorm RxCUI
        /// </summary>
        public string? RxCui { get; set; }

        /// <summary>
        ///     The sig
        /// </summary>
        public string? Sig { get; set; }
    }
}