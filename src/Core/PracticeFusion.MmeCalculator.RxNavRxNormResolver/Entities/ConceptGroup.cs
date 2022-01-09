using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PracticeFusion.MmeCalculator.RxNavRxNormResolver.Entities
{
    /// <summary>
    /// Concepts
    /// </summary>
    public class ConceptGroup
    {
        /// <summary>
        /// TTY
        /// </summary>
        [JsonPropertyName("tty")]
        public string? Tty { get; set; }

        /// <summary>
        /// Concept Properties
        /// </summary>
        [JsonPropertyName("conceptProperties")]
        public List<ConceptProperty>? ConceptProperties { get; set; }
    }
}
