using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PracticeFusion.MmeCalculator.RxNavRxNormResolver.Entities
{
    /// <summary>
    /// Property concepts
    /// </summary>
    public class PropertyConceptGroup
    {
        /// <summary>
        /// Property concepts
        /// </summary>
        [JsonPropertyName("propConcept")]
        public List<PropertyConcept>? PropertyConcepts { get; set; }
    }
}
