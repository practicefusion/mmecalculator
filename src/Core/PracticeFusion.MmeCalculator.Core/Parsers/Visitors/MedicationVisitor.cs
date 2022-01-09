using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Messages;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;

namespace PracticeFusion.MmeCalculator.Core.Parsers.Visitors
{
    internal class MedicationVisitor : IVisitorCreator<DefaultParser.MedicationContext, ParsedMedication>
    {
        private readonly FormExpressionVisitor _formExpressionVisitor = new();
        private readonly OpioidVisitor _opioidVisitor = new();
        private readonly NumericValueVisitor _numericValueVisitor = new();
        private readonly DoseUnitOfMeasureVisitor _doseUnitOfMeasureVisitor = new();

        public ParsedMedication VisitRoot(DefaultParser.MedicationContext context)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            var result = new ParsedMedication();
            foreach (DefaultParser.MedicationComponentContext medicationComponentContext in context.medicationComponent())
            {
                result.MedicationComponents.Add(VisitMedicationComponent(medicationComponentContext));
            }

            if (context.drugForm() != null)
            {
                Form form = _formExpressionVisitor.VisitAllRoot(context.drugForm().formExpression());

                foreach (MedicationComponent medicationComponent in result.MedicationComponents)
                {
                    medicationComponent.Form = form;
                }
            }

            return result;
        }

        private MedicationComponent VisitMedicationComponent(DefaultParser.MedicationComponentContext context)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            var result = new MedicationComponent();
            context.SetStartAndStopIndex(result);

            if (context.simpleMedicationComponent() != null)
            {
                VisitSimpleMedicationComponent(context.simpleMedicationComponent(), result);
            }
            else
            {
                VisitComplexMedicationComponent(context.complexMedicationComponent(), result);
            }

            return result;
        }

        private void VisitStrength(DefaultParser.StrengthContext context, MedicationComponent result)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            result.Strength = _numericValueVisitor.VisitRoot(context.numericValue());
            result.UnitOfMeasure = _doseUnitOfMeasureVisitor.VisitRoot(context.doseUnitOfMeasure());
        }

        private void VisitSimpleMedicationComponent(DefaultParser.SimpleMedicationComponentContext context, MedicationComponent result)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            VisitStrength(context.strength(), result);

            // either an opioid
            if (context.opioid() != null)
            {
                result.IsOpioid = true;
                if (context.description() != null && context.description().Length > 0)
                {
                    result.Description = context.description().GetOriginalTextWithSpacing();
                }

                result.Opioid = _opioidVisitor.VisitRoot(context.opioid());
                result.Name = result.Opioid.ToString();
            }
            else
            {
                // or a non-opioid
                result.IsOpioid = false;
                result.Name = context.nonOpioid().GetOriginalTextWithSpacing();
            }
        }

        private void VisitComplexMedicationComponent(DefaultParser.ComplexMedicationComponentContext context, MedicationComponent result)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            if (context.strength().Length == 0)
            {
                throw new ParsingException(
                    $"Cannot include medications with multiple strengths for a single component in calculations: '{context.GetOriginalTextWithSpacing()}'");
            }

            // Medications like: 1ml hydromorphone hcl 4mg/ml
            // will have more than one set of numbers that could be considered the strength.
            // The first is the dose size, the second is the concentration, and we want the
            // concentration for MME calculations: so we will always take the last matched strength.
            var strengthCount = context.strength().Length;
            VisitStrength(context.strength()[strengthCount - 1], result);

            // either an opioid
            if (context.opioid() != null)
            {
                result.IsOpioid = true;
                result.Opioid = _opioidVisitor.VisitRoot(context.opioid());
                result.Name = result.Opioid.ToString();
            }
            else
            {
                // or a non-opioid
                result.IsOpioid = false;
                result.Name = context.nonOpioid().GetOriginalTextWithSpacing();
            }
        }
    }
}
