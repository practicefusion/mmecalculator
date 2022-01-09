using System;
using System.Text;

namespace PracticeFusion.MmeCalculator.Core.Entities
{
    /// <summary>
    /// Route
    /// </summary>
    /// <inheritdoc cref="MultipleEnumParsedEntity{TEnum}"/>
    [Serializable]
    public class Route : MultipleEnumParsedEntity<RouteEnum>
    {
        /// <summary>
        /// Indicates whether the route contains latin abbreviations like "po"
        /// </summary>
        public bool ContainsLatinAbbreviations { get; set; }

        /// <summary>
        /// Optional route instruction
        /// </summary>
        public string? RouteInstruction { get; set; }

        internal override string Pluralize(decimal count)
        {
            var sb = new StringBuilder();
            var first = true;

            foreach (RouteEnum enumValue in ValueEnums)
            {
                ParseableEnumAttribute data = enumValue.GetParseableEnumData();
                string display = count <= 1 ? data.FriendlyName : data.PluralName;

                // check the first one, if it starts with "by" and we have a route instruction
                if (first && !string.IsNullOrEmpty(RouteInstruction) && display.StartsWith("by "))
                {
                    // remove "by "
                    display = display.Remove(0, 3);
                }

                if (sb.Length > 0)
                {
                    sb.Append('/');
                }

                sb.Append(display);
                first = false;
            }

            return (!string.IsNullOrEmpty(RouteInstruction) ? RouteInstruction + " " : "") + sb;
        }
    }
}
