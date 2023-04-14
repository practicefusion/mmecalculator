using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticeFusion.MmeCalculator.Core.Entities
{
    /// <summary>
    ///     An entity that can have more than one value from an enumeration.
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <inheritdoc />
    [Serializable]
    public class MultipleEnumParsedEntity<TEnum> : BaseParsedEntity where TEnum : Enum
    {
        /// <summary>
        ///     The parsed enums from the original sig
        /// </summary>
        public List<TEnum> ValueEnums { get; set; } = new();

        /// <summary>
        ///     Exact match of <see cref="ValueEnums" />
        /// </summary>
        /// <param name="desiredEnums"></param>
        /// <returns>True if <see cref="ValueEnums" /> and <paramref name="desiredEnums" /> match exactly in length and content</returns>
        public bool ExactMatch(params TEnum[] desiredEnums)
        {
            return ValueEnums.SequenceEqual(desiredEnums);
        }

        /// <summary>
        ///     Match any <see cref="ValueEnums" />
        /// </summary>
        /// <param name="desiredEnums"></param>
        /// <returns>True if any enum in <paramref name="desiredEnums" /> is matched</returns>
        public List<TEnum> MatchAny(params TEnum[] desiredEnums)
        {
            return ValueEnums.Intersect(desiredEnums).ToList();
        }

        /// <summary>
        ///     Match all <see cref="ValueEnums" />
        /// </summary>
        /// <param name="desiredEnums"></param>
        /// <returns> True if every enum in <paramref name="desiredEnums" /> is found</returns>
        public bool MatchAll(params TEnum[] desiredEnums)
        {
            return desiredEnums.Intersect(ValueEnums).AsEnumerable().SequenceEqual(desiredEnums);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return Pluralize(1);
        }

        internal virtual string Pluralize(decimal count)
        {
            var sb = new StringBuilder();

            foreach (TEnum enumValue in ValueEnums)
            {
                ParseableEnumAttribute data = enumValue.GetParseableEnumData();
                if (sb.Length > 0)
                {
                    sb.Append(' ');
                }

                sb.Append(count <= 1 ? data.FriendlyName : data.PluralName);
            }

            return sb.ToString();
        }
    }
}