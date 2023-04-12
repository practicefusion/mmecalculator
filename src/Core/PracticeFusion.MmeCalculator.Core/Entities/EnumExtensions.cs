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

        public static bool EventTimingAboutFood(this EventTimingEnum e)
        {
            return 
                e == EventTimingEnum.BeforeEveryMeal || 
                e == EventTimingEnum.WithEveryMeal ||
                e == EventTimingEnum.AfterEveryMeal || 
                e == EventTimingEnum.BeforeMeals || 
                e == EventTimingEnum.WithMeals ||
                e == EventTimingEnum.AfterMeals || 
                e == EventTimingEnum.BeforeBreakfast ||
                e == EventTimingEnum.WithBreakfast ||
                e == EventTimingEnum.AfterBreakfast ||
                e == EventTimingEnum.BeforeLunch ||
                e == EventTimingEnum.WithLunch ||
                e == EventTimingEnum.AfterLunch ||
                e == EventTimingEnum.BeforeDinner ||
                e == EventTimingEnum.WithDinner ||
                e == EventTimingEnum.AfterDinner;
        }
    }
}
