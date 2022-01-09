
using System.Text.Json.Serialization;

namespace PracticeFusion.MmeCalculator.RxNavRxNormResolver.Entities
{
    /// <summary>
    /// Concept property
    /// </summary>
    public class ConceptProperty
    {
        /// <summary>
        /// RxCUI
        /// </summary>
        [JsonPropertyName("rxcui")]
        public string? RxCui { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Synonym
        /// </summary>
        [JsonPropertyName("synonym")]
        public string? Synonym { get; set; }

        /// <summary>
        /// TTY
        /// </summary>
        [JsonPropertyName("tty")]
        public string? Tty { get; set; }

        /// <summary>
        /// Language
        /// </summary>
        [JsonPropertyName("language")]
        public string? Language { get; set; }

        /// <summary>
        /// Suppress
        /// </summary>
        [JsonPropertyName("suppress")]
        public string? Suppress { get; set; }

        /// <summary>
        /// UMLS CUI
        /// </summary>
        [JsonPropertyName("umlscui")]
        public string? UmlsCui { get; set; }
    }
}
