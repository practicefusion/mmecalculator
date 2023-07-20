using PracticeFusion.MmeCalculator.RxNavRxNormResolver.Entities;
using System.Text.Json.Serialization;

namespace PracticeFusion.MmeCalculator.RxNavRxNormResolver.Responses
{
    /// <summary>
    ///     Response from a drug search
    /// </summary>
    public class DrugSearchResponse
    {
        /// <summary>
        ///     Drug group
        /// </summary>
        [JsonPropertyName("drugGroup")]
        public DrugGroup? DrugGroup { get; set; }

        /// <summary>
        ///     Id Group
        /// </summary>
        [JsonPropertyName("idGroup")]
        public IdGroup? IdGroup { get; set; }
    }
}