using System;
using System.Text;

namespace PracticeFusion.MmeCalculator.Core.Entities
{
    /// <summary>
    /// Base class for most parsed entities.
    /// </summary>
    [Serializable]
    public abstract class BaseParsedEntity
    {
        /// <summary>
        /// The start index in the original sig
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// The length in the original sig
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// The human readable presentation
        /// </summary>
        public virtual string? HumanReadable => ToString();

        /// <summary>
        /// Appends the phrases, prefixing with a space if needed
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="phrases"></param>
        protected internal static void AppendWithSpaceIfNeeded(StringBuilder sb, params string?[] phrases)
        {
            foreach (var phrase in phrases)
            {
                if (!string.IsNullOrEmpty(phrase))
                {
                    sb.AppendFormat("{0}{1}", sb.Length > 0 ? " " : "", phrase);
                }
            }
        }
    }
}
