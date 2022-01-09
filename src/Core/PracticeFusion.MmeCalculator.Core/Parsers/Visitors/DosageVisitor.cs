using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;

namespace PracticeFusion.MmeCalculator.Core.Parsers.Visitors
{
    internal class DosageVisitor : IVisitorCreator<DefaultParser.DosageContext, Dosage>
    {
        public Dosage VisitRoot(DefaultParser.DosageContext context)
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

            if (context.ambiguousDose() != null)
            {
                result.Dose = new DoseVisitor().VisitAmbiguousDose(context.ambiguousDose());
            }

            if (context.route() != null && context.route().Length > 0)
            {
                result.Route = new RouteVisitor().VisitAllRoot(context.route());
            }

            if (context.frequencies() != null && context.frequencies().Length > 0)
            {
                if (context.frequencies().Length > 1)
                {
                    throw new ParsingException("Ambiguous frequencies: multiple frequencies.");
                }

                result.Frequency = new FrequencyVisitor().VisitAllRoot(context.frequencies()[0].frequency());
            }

            if (context.duration() != null && context.duration().Length > 0)
            {
                result.Duration = new DurationVisitor().VisitAllRoot(context.duration());
            }

            if (context.indicationForUse() != null && context.indicationForUse().Length > 0)
            {
                result.IndicationForUse = new IndicationForUseVisitor().VisitAllRoot(context.indicationForUse());
            }

            if (context.additionalInstruction() != null && context.additionalInstruction().Length > 0)
            {
                result.AdditionalInstruction =
                    new AdditionalInstructionVisitor().VisitAllRoot(context.additionalInstruction());
            }

            return result;
        }
    }
}
