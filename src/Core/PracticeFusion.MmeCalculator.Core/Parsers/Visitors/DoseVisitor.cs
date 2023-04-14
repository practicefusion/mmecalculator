using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;
using System;

namespace PracticeFusion.MmeCalculator.Core.Parsers.Visitors
{
    internal class DoseVisitor : IVisitorCreator<DefaultParser.DoseContext, Dose>
    {
        public Dose VisitRoot(DefaultParser.DoseContext context)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            return VisitDoseAndCheckForConversion(context, true);
        }

        public Dose VisitAmbiguousDose(DefaultParser.AmbiguousDoseContext context)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            var result = new Dose();
            VisitDoseVal(context.doseVal(), result);
            return result;
        }

        private static void VisitDoseVal(DefaultParser.DoseValContext context, Dose dose)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            if (context.numericValue() != null)
            {
                dose.Complex = false;
                dose.MinDose = new NumericValueVisitor().VisitRoot(context.numericValue());
                dose.MaxDose = dose.MinDose;
            }
            else
            {
                dose.Complex = true;
                Tuple<decimal, decimal> range = new RangeNumericValueVisitor().VisitRoot(context.rangeNumericValue());
                dose.MinDose = range.Item1;
                dose.MaxDose = range.Item2;
            }
        }

        private static void VisitRangeNumericValueWithUOM(DefaultParser.RangeNumericValueWithUOMContext context,
            Dose dose)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            var min = new NumericValueVisitor().VisitRoot(context.numericValue(0));
            UnitOfMeasure minDoseUnit = new DoseUnitOfMeasureVisitor().VisitRoot(context.doseUnitOfMeasure(0));

            var max = new NumericValueVisitor().VisitRoot(context.numericValue(1));
            UnitOfMeasure maxDoseUnit = new DoseUnitOfMeasureVisitor().VisitRoot(context.doseUnitOfMeasure(1));

            dose.Complex = true;
            dose.MinDose = min;
            dose.MaxDose = max;

            // if the UOMs are not the same bail
            if (minDoseUnit.ValueEnum != maxDoseUnit.ValueEnum)
            {
                throw new ParsingException(
                    $"Different units of measure between the min ({minDoseUnit.ValueEnum}) and max ({maxDoseUnit.ValueEnum}) values in the range.");
            }

            dose.DoseUnit = new DoseUnit { UnitOfMeasure = minDoseUnit };
        }

        private Dose VisitDoseAndCheckForConversion(DefaultParser.DoseContext context, bool checkForConversion)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            var result = new Dose();
            context.SetStartAndStopIndex(result);

            if (context.doseVal() != null)
            {
                // parse the doseval
                VisitDoseVal(context.doseVal(), result);

                // parse doseunit
                result.DoseUnit = new DoseUnitVisitor().VisitRoot(context.doseUnit());
            }
            else
            {
                // parse rangeNumberValueWithUOM
                VisitRangeNumericValueWithUOM(context.rangeNumericValueWithUOM(), result);
            }

            // there might be a conversion as an inner dose, but...
            // only check for conversion once--parseable but invalid: '1-2 mg (1-2 ml (1-2 mg (...)))'
            if (context.dose() != null && checkForConversion)
            {
                Dose conversion = VisitDoseAndCheckForConversion(context.dose(), false);
                result.DoseConversion = new DoseConversion
                {
                    Complex = conversion.Complex,
                    MaxDose = conversion.MaxDose,
                    MinDose = conversion.MinDose,
                    UnitOfMeasure = conversion.DoseUnit?.UnitOfMeasure
                };
            }

            return result;
        }
    }
}