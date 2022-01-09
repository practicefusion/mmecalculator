using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;

namespace PracticeFusion.MmeCalculator.Core.Parsers.Visitors
{
    internal class DurationVisitor : IManyToOneVisitor<DefaultParser.DurationContext, Duration>
    {
        public Duration VisitAllRoot(DefaultParser.DurationContext[] contexts)
        {
            if (contexts == null)
            {
                throw new ParsingException("Empty context.");
            }

            if (contexts.Length > 1)
            {
                throw new ParsingException("Ambiguous durations: there are multiple durations.");
            }

            return VisitRoot(contexts[0]);
        }

        public Duration VisitRoot(DefaultParser.DurationContext context)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            if (context.durationStandard() != null)
            {
                return VisitDurationStandard(context.durationStandard());
            }

            if (context.durationOrdinal() != null)
            {
                return VisitDurationOrdinal(context.durationOrdinal());
            }

            if (context.durationUnbounded() != null)
            {
                return VisitDurationUnbounded(context.durationUnbounded());
            }

            throw new ParsingException($"Expected to duration, but found '{context.GetOriginalTextWithSpacing()}'");
        }

        private static Duration VisitDurationStandard(DefaultParser.DurationStandardContext context)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            var result = new Duration();
            context.SetStartAndStopIndex(result);

            VisitDurationStandard(context, result);
            return result;
        }

        private static void VisitDurationStandard(DefaultParser.DurationStandardContext context, Duration duration)
        {
            duration.Count = new NumericValueVisitor().VisitRoot(context.numericValue());
            duration.Period = new Period
            {
                ValueEnum = new PeriodEnumVisitor().VisitRoot(context.period().periodEnum())
            };
        }

        private static Duration VisitDurationOrdinal(DefaultParser.DurationOrdinalContext context)
        {
            var result = new Duration();
            context.SetStartAndStopIndex(result);
            VisitDurationOrdinal(context, result);
            return result;
        }

        private static void VisitDurationOrdinal(DefaultParser.DurationOrdinalContext context, Duration duration)
        {
            // for the first week, for the second week, etc.
            // still one week, however, we should improve this to show
            // the ordinal in the duration ToString()
            duration.Count = 1;
            duration.Period = new Period
            {
                ValueEnum = new PeriodEnumVisitor().VisitRoot(context.period().periodEnum())
            };
        }

        private static Duration VisitDurationUnbounded(DefaultParser.DurationUnboundedContext context)
        {
            var result = new Duration();
            context.SetStartAndStopIndex(result);
            VisitDurationUnbounded(context, result);
            return result;
        }

        private static void VisitDurationUnbounded(DefaultParser.DurationUnboundedContext context, Duration duration)
        {
            duration.Unbounded = true;
            duration.UnboundedMessage = context.GetOriginalTextWithSpacing();
        }
    }
}
