using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;

namespace PracticeFusion.MmeCalculator.Core.Parsers.Visitors
{
    internal class
        AdditionalInstructionVisitor : IManyToOneVisitor<DefaultParser.AdditionalInstructionContext,
            AdditionalInstruction>
    {
        public AdditionalInstruction VisitAllRoot(DefaultParser.AdditionalInstructionContext[] contexts)
        {
            if (contexts == null)
            {
                throw new ParsingException("Empty context.");
            }

            if (contexts.Length > 1)
            {
                throw new ParsingException(
                    "Ambiguous additional instructions: there are multiple additional instructions.");
            }

            return VisitRoot(contexts[0]);
        }

        public AdditionalInstruction VisitRoot(DefaultParser.AdditionalInstructionContext context)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            var result = new AdditionalInstruction();
            context.SetStartAndStopIndex(result);

            if (context.emptyStomach() != null)
            {
                result.ValueEnum = AdditionalInstructionEnum.EmptyStomach;
            }

            if (context.withFood() != null)
            {
                result.ValueEnum = VisitWithFood(context.withFood());
            }

            if (context.withLiquid() != null)
            {
                result.ValueEnum = AdditionalInstructionEnum.WithLiquid;
            }

            if (context.asDirected() != null)
            {
                result.ValueEnum = AdditionalInstructionEnum.AsDirected;
            }

            if (context.doNotSwallow() != null)
            {
                result.ValueEnum = AdditionalInstructionEnum.DoNotSwallow;
            }

            result.Description = context.GetOriginalTextWithSpacing();
            return result;
        }

        private static AdditionalInstructionEnum VisitWithFood(DefaultParser.WithFoodContext context)
        {
            // get the latin expressions out of the way first
            if (context.AC() != null)
            {
                return AdditionalInstructionEnum.BeforeMeals;
            }

            if (context.PC() != null)
            {
                return AdditionalInstructionEnum.AfterMeals;
            }

            // our only structure for "food" (with food)
            if (context.WITH() != null && context.FOOD() != null)
            {
                return AdditionalInstructionEnum.WithFood;
            }

            // our options for eating
            if (context.EATING() != null)
            {
                if (context.BEFORE() != null)
                {
                    return AdditionalInstructionEnum.BeforeEating;
                }

                if (context.AFTER() != null)
                {
                    return AdditionalInstructionEnum.AfterEating;
                }
            }

            if (context.MEAL() != null)
            {
                if (context.BEFORE() != null)
                {
                    return AdditionalInstructionEnum.BeforeMeals;
                }

                if (context.AFTER() != null)
                {
                    return AdditionalInstructionEnum.AfterMeals;
                }

                if (context.WITH() != null)
                {
                    return AdditionalInstructionEnum.WithMeals;
                }
            }

            return AdditionalInstructionEnum.Unknown;
        }
    }
}