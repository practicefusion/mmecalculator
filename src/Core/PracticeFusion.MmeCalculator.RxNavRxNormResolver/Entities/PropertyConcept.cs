using System.Text.Json.Serialization;

namespace PracticeFusion.MmeCalculator.RxNavRxNormResolver.Entities
{
    /// <summary>
    /// Property concept
    /// </summary>
    public class PropertyConcept
    {
        /// <summary>
        /// Property category
        /// </summary>
        [JsonPropertyName("propCategory")]
        public string? Category { get; set; }

        /// <summary>
        /// Property name
        /// </summary>
        [JsonPropertyName("propName")]
        public string? Name { get; set; }

        /// <summary>
        /// Property value
        /// </summary>
        [JsonPropertyName("propValue")]
        public string? Value { get; set; }
    }
}
