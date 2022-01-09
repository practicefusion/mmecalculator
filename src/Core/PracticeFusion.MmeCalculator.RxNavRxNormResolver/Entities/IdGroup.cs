using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PracticeFusion.MmeCalculator.RxNavRxNormResolver.Entities
{
    /// <summary>
    /// Ids
    /// </summary>
    public class IdGroup
    {
        /// <summary>
        /// Name
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// RxNorm ID
        /// </summary>
        [JsonPropertyName("rxnormId")]
        public List<string>? RxNormId { get; set; }
    }
}
