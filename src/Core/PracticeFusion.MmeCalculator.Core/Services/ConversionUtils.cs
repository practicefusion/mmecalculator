using PracticeFusion.MmeCalculator.Core.Entities;

namespace PracticeFusion.MmeCalculator.Core.Services
{
    internal static class ConversionUtils
    {
        public static bool HasDenominatorUom(UnitOfMeasureEnum? uom)
        {
            return uom switch
            {
                UnitOfMeasureEnum.MilligramPerMilliliter or UnitOfMeasureEnum.MilligramPerActuation
                    or UnitOfMeasureEnum.MilligramPerHour or UnitOfMeasureEnum.MicrogramPerActuation
                    or UnitOfMeasureEnum.MicrogramPerHour => true,
                _ => false
            };
        }

        public static UnitOfMeasureEnum? GetNumeratorUom(UnitOfMeasureEnum? uom)
        {
            return uom switch
            {
                UnitOfMeasureEnum.MilligramPerMilliliter or UnitOfMeasureEnum.MilligramPerActuation
                    or UnitOfMeasureEnum.MilligramPerHour => UnitOfMeasureEnum.Milligram,
                UnitOfMeasureEnum.MicrogramPerActuation or UnitOfMeasureEnum.MicrogramPerHour =>
                    UnitOfMeasureEnum.Microgram,
                _ => uom
            };
        }

        public static UnitOfMeasureEnum? GetDenominatorUom(UnitOfMeasureEnum? uom)
        {
            return uom switch
            {
                UnitOfMeasureEnum.MilligramPerMilliliter => UnitOfMeasureEnum.Milliliter,
                _ => uom
            };
        }

        public static decimal UnitOfMeasureConversionFactor(UnitOfMeasureEnum? expectedUom, UnitOfMeasureEnum? givenUom)
        {
            if (!expectedUom.HasValue || !givenUom.HasValue)
            {
                return 0;
            }

            if (EquivalentUnitOfMeasure(expectedUom, givenUom))
            {
                return 1m;
            }

            switch (expectedUom)
            {
                case UnitOfMeasureEnum.Microgram:
                case UnitOfMeasureEnum.MicrogramPerActuation:
                case UnitOfMeasureEnum.MicrogramPerHour:
                    if (givenUom == UnitOfMeasureEnum.Milligram ||
                        givenUom == UnitOfMeasureEnum.MilligramPerActuation ||
                        givenUom == UnitOfMeasureEnum.MilligramPerHour ||
                        givenUom == UnitOfMeasureEnum.MilligramPerMilliliter)
                    {
                        return 1000m;
                    }
                    else
                    {
                        return 0m;
                    }

                case UnitOfMeasureEnum.Milligram:
                case UnitOfMeasureEnum.MilligramPerActuation:
                case UnitOfMeasureEnum.MilligramPerHour:
                case UnitOfMeasureEnum.MilligramPerMilliliter:
                    if (givenUom == UnitOfMeasureEnum.Microgram ||
                        givenUom == UnitOfMeasureEnum.MicrogramPerActuation ||
                        givenUom == UnitOfMeasureEnum.MicrogramPerHour)
                    {
                        return 1 / 1000m;
                    }
                    else
                    {
                        return 0m;
                    }

                default:
                    // they are not the same (the first check), so err on the side of caution
                    return 0m;
            }
        }

        public static bool EquivalentUnitOfMeasure(UnitOfMeasureEnum? expectedUom, UnitOfMeasureEnum? givenUom)
        {
            if (!expectedUom.HasValue || !givenUom.HasValue)
            {
                return false;
            }

            switch (expectedUom)
            {
                case UnitOfMeasureEnum.Microgram:
                case UnitOfMeasureEnum.MicrogramPerActuation:
                case UnitOfMeasureEnum.MicrogramPerHour:
                    if (givenUom == UnitOfMeasureEnum.Microgram ||
                        givenUom == UnitOfMeasureEnum.MicrogramPerActuation ||
                        givenUom == UnitOfMeasureEnum.MicrogramPerHour)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case UnitOfMeasureEnum.Milligram:
                case UnitOfMeasureEnum.MilligramPerActuation:
                case UnitOfMeasureEnum.MilligramPerHour:
                case UnitOfMeasureEnum.MilligramPerMilliliter:
                    if (givenUom == UnitOfMeasureEnum.Milligram ||
                        givenUom == UnitOfMeasureEnum.MilligramPerActuation ||
                        givenUom == UnitOfMeasureEnum.MilligramPerHour ||
                        givenUom == UnitOfMeasureEnum.MilligramPerMilliliter)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case UnitOfMeasureEnum.Milliliter:
                case UnitOfMeasureEnum.CubicCentimeter:
                    if (givenUom == UnitOfMeasureEnum.Milliliter || givenUom == UnitOfMeasureEnum.CubicCentimeter)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                default:
                    return false;
            }
        }

        internal static decimal ConcentrationConversionFactor(
            UnitOfMeasureEnum? uom,
            decimal targetConcentration,
            UnitOfMeasureEnum? targetUom)
        {
            var concentrationFactor = 1m;

            if (HasDenominatorUom(targetUom))
            {
                UnitOfMeasureEnum? denominatorUom = GetDenominatorUom(targetUom);
                if (uom == denominatorUom || EquivalentUnitOfMeasure(denominatorUom, uom))
                {
                    concentrationFactor = targetConcentration;
                }
            }

            return concentrationFactor;
        }
    }
}