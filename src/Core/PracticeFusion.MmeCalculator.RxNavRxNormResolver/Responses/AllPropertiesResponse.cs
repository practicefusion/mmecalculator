using PracticeFusion.MmeCalculator.RxNavRxNormResolver.Entities;
using System.Text.Json.Serialization;

namespace PracticeFusion.MmeCalculator.RxNavRxNormResolver.Responses
{
    /// <summary>
    ///     All properties
    /// </summary>
    public class AllPropertiesResponse
    {
        /// <summary>
        ///     Property concept group
        /// </summary>
        [JsonPropertyName("propConceptGroup")]
        public PropertyConceptGroup? PropertyConceptGroup { get; set; }
    }
}