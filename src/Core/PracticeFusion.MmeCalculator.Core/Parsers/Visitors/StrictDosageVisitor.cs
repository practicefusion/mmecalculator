using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;

namespace PracticeFusion.MmeCalculator.Core.Parsers.Visitors
{
    internal class StrictDosageVisitor : IVisitorCreator<DefaultParser.StrictDosageContext, Dosage>
    {
        public Dosage VisitRoot(DefaultParser.StrictDosageContext context)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            var result = new Dosage();
            context.SetStartAndStopIndex(result);

            if (context.dosageSeparator() != null)
            {
                var visitor = new DosageSeparatorVisitor();
                result.DosageSeparator = visitor.VisitRoot(context.dosageSeparator());
            }

            if (context.doseDeliveryMethod() != null)
            {
                var visitor = new DoseDeliveryMethodVisitor();
                result.DoseDeliveryMethod = visitor.VisitRoot(context.doseDeliveryMethod());
            }

            if (context.dose() != null)
            {
                result.Dose = new DoseVisitor().VisitRoot(context.dose());
            }

            if (context.route() != null)
            {
                result.Route = new RouteVisitor().VisitRoot(context.route());
            }

            if (context.frequencies() != null)
            {
                result.Frequency = new FrequencyVisitor().VisitAllRoot(context.frequencies().frequency());
            }

            if (context.additionalInstruction() != null)
            {
                result.AdditionalInstruction =
                    new AdditionalInstructionVisitor().VisitRoot(context.additionalInstruction());
            }

            if (context.indicationForUse() != null)
            {
                result.IndicationForUse = new IndicationForUseVisitor().VisitRoot(context.indicationForUse());
            }

            if (context.duration() != null)
            {
                result.Duration = new DurationVisitor().VisitRoot(context.duration());
            }

            return result;
        }
    }
}