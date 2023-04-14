using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;

namespace PracticeFusion.MmeCalculator.Core.Parsers.Visitors
{
    internal class
        DoseDeliveryMethodVisitor : IVisitorCreator<DefaultParser.DoseDeliveryMethodContext, DoseDeliveryMethod>
    {
        public DoseDeliveryMethod VisitRoot(DefaultParser.DoseDeliveryMethodContext context)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            var result = new DoseDeliveryMethod();
            context.SetStartAndStopIndex(result);

            var actionType = context.Start.Type;

            result.ValueEnum = actionType switch
            {
                DefaultLexer.ADMINISTER => DoseDeliveryMethodEnum.Administer,
                DefaultLexer.APPLY => DoseDeliveryMethodEnum.Apply,
                DefaultLexer.CHEW => context.SWALLOW() != null
                    ? DoseDeliveryMethodEnum.ChewAndSwallow
                    : DoseDeliveryMethodEnum.Chew,
                DefaultLexer.DISSOLVE => DoseDeliveryMethodEnum.Dissolve,
                DefaultLexer.GIVE => DoseDeliveryMethodEnum.Give,
                DefaultLexer.INFUSE => DoseDeliveryMethodEnum.Infuse,
                DefaultLexer.INHALE => DoseDeliveryMethodEnum.Inhale,
                DefaultLexer.INJECT => DoseDeliveryMethodEnum.Inject,
                DefaultLexer.INSERT => DoseDeliveryMethodEnum.Insert,
                DefaultLexer.PLACE => DoseDeliveryMethodEnum.Place,
                DefaultLexer.SUCK => DoseDeliveryMethodEnum.Suck,
                DefaultLexer.TAKE => DoseDeliveryMethodEnum.Take,
                DefaultLexer.USE => DoseDeliveryMethodEnum.Use,
                _ => throw new ParsingException($"Action recognized, but cannot be mapped: '{context.Start.Text}'")
            };

            return result;
        }
    }
}