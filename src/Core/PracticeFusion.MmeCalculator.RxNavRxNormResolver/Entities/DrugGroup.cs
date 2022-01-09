using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PracticeFusion.MmeCalculator.RxNavRxNormResolver.Entities
{
    /// <summary>
    /// Drugs
    /// </summary>
    public class DrugGroup
    {
        /// <summary>
        /// Name
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Concept groups
        /// </summary>
        [JsonPropertyName("conceptGroup")]
        public List<ConceptGroup>? ConceptGroups { get; set; }
    }
}
