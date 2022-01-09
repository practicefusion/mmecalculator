using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PracticeFusion.MmeCalculator.Core.Entities
{
    internal static class EnumExtensions
    {
        public static ParseableEnumAttribute GetParseableEnumData(this Enum e)
        {
            if (e.GetType().GetTypeInfo().GetMember(e.ToString()).FirstOrDefault(m => m.MemberType == MemberTypes.Field)
                ?.GetCustomAttributes(typeof(ParseableEnumAttribute), false).SingleOrDefault() is not ParseableEnumAttribute attribute)
            {
                throw new ArgumentException($"Unable to retrieve attribute for enum '{e}'");
            }

            return attribute;
        }

        public static List<ConversionFactorAttribute> GetConversionFactors(this OpioidEnum e)
        {
            if (e.GetType().GetTypeInfo().GetMember(e.ToString()).FirstOrDefault(m => m.MemberType == MemberTypes.Field)
                    ?.GetCustomAttributes(typeof(ConversionFactorAttribute), false) is not ConversionFactorAttribute[] attributes)
            {
                throw new ArgumentException($"Unable to retrieve attribute for enum '{e}'");
            }

            return attributes.ToList();
        }
    }
}
