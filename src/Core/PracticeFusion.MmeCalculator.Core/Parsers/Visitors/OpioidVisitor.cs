using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;

namespace PracticeFusion.MmeCalculator.Core.Parsers.Visitors
{
    internal class OpioidVisitor : IVisitorCreator<DefaultParser.OpioidContext, Opioid>
    {
        public Opioid VisitRoot(DefaultParser.OpioidContext context)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            var result = new Opioid();
            context.SetStartAndStopIndex(result);

            result.ValueEnum = GetOpioidEnum(context);

            return result;
        }

        private static OpioidEnum GetOpioidEnum(DefaultParser.OpioidContext context)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            return context.Start.Type switch
            {
                DefaultLexer.BUPRENORPHINE => OpioidEnum.Buprenorphine,
                DefaultLexer.BUTORPHANOL => OpioidEnum.Butorphanol,
                DefaultLexer.CODEINE => OpioidEnum.Codeine,
                DefaultLexer.DIHYDROCODEINE => OpioidEnum.Dihydrocodeine,
                DefaultLexer.FENTANYL => OpioidEnum.Fentanyl,
                DefaultLexer.HYDROCODONE => OpioidEnum.Hydrocodone,
                DefaultLexer.HYDROMORPHONE => OpioidEnum.Hydromorphone,
                DefaultLexer.LEVORPHANOL => OpioidEnum.Levorphanol,
                DefaultLexer.MEPERIDINE => OpioidEnum.Meperidine,
                DefaultLexer.METHADONE => OpioidEnum.Methadone,
                DefaultLexer.MORPHINE => OpioidEnum.Morphine,
                DefaultLexer.OPIUM => OpioidEnum.Opium,
                DefaultLexer.OXYCODONE => OpioidEnum.Oxycodone,
                DefaultLexer.OXYMORPHONE => OpioidEnum.Oxymorphone,
                DefaultLexer.PENTAZOCINE => OpioidEnum.Pentazocine,
                DefaultLexer.TAPENTADOL => OpioidEnum.Tapentadol,
                DefaultLexer.TRAMADOL => OpioidEnum.Tramadol,
                _ => throw new ParsingException(
                    $"Identified possible opioid, but cannot map '{context.GetOriginalTextWithSpacing()}'")
            };
        }
    }
}
