using System;

namespace PracticeFusion.MmeCalculator.Core.Entities
{
    [AttributeUsage(AttributeTargets.Field)]
    internal sealed class ParseableEnumAttribute : Attribute
    {
        // This is a positional argument
        public ParseableEnumAttribute(
            string friendlyName,
            string pluralName,
            bool isDefault = false)
        {
            FriendlyName = friendlyName;
            PluralName = pluralName;
            IsDefault = isDefault;
        }

        public string FriendlyName { get; }

        public string PluralName { get; }

        public bool IsDefault { get; }
    }
}
