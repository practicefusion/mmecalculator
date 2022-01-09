using System;

namespace PracticeFusion.MmeCalculator.Core.Entities
{
    /// <summary>
    /// A parsed entity that contains at least an enumerated value.
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <inheritdoc />
    [Serializable]
    public class EnumParsedEntity<TEnum> : BaseParsedEntity where TEnum : Enum
    {
        /// <summary>
        /// The enumerated value parsed from the original sig.
        /// </summary>
        public TEnum? ValueEnum { get; set; }

        /// <summary>
        /// The human readable presentation
        /// </summary>
        public override string ToString()
        {
            return Pluralize(1);
        }

        internal virtual string Pluralize(decimal count)
        {
            if (ValueEnum == null)
            {
                throw new InvalidOperationException($"{nameof(ValueEnum)} is null.");
            }

            ParseableEnumAttribute data = ValueEnum.GetParseableEnumData();
            return count <= 1 ? data.FriendlyName : data.PluralName;
        }
    }
}
