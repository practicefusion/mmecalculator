using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;

namespace PracticeFusion.MmeCalculator.Core.Parsers.Visitors
{
    internal class DoseUnitOfMeasureVisitor : IVisitorCreator<DefaultParser.DoseUnitOfMeasureContext, UnitOfMeasure>
    {
        public UnitOfMeasure VisitRoot(DefaultParser.DoseUnitOfMeasureContext context)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            var result = new UnitOfMeasure();
            context.SetStartAndStopIndex(result);

            var actionType = context.Start.Type;

            result.ValueEnum = actionType switch
            {
                DefaultLexer.CENTIMETERS => UnitOfMeasureEnum.Centimeter,
                DefaultLexer.CUBICCENTIMETERS => UnitOfMeasureEnum.CubicCentimeter,
                DefaultLexer.GRAMS => UnitOfMeasureEnum.Gram,
                DefaultLexer.INTERNATIONALUNITS => UnitOfMeasureEnum.InternationalUnit,
                DefaultLexer.LITERS => UnitOfMeasureEnum.Liter,
                DefaultLexer.MILLIEQUIVALENTS => UnitOfMeasureEnum.Milliequivalent,
                DefaultLexer.MICROGRAMSPERHOUR => UnitOfMeasureEnum.MicrogramPerHour,
                DefaultLexer.MICROGRAMSPERACT => UnitOfMeasureEnum.MicrogramPerActuation,
                DefaultLexer.MICROGRAMS => UnitOfMeasureEnum.Microgram,
                DefaultLexer.MILLIGRAMSPERHOUR => UnitOfMeasureEnum.MilligramPerHour,
                DefaultLexer.MILLIGRAMSPERACT => UnitOfMeasureEnum.MilligramPerActuation,
                DefaultLexer.MILLIGRAMSPERML => UnitOfMeasureEnum.MilligramPerMilliliter,
                DefaultLexer.MILLIGRAMS => UnitOfMeasureEnum.Milligram,
                DefaultLexer.MILLILITERS => UnitOfMeasureEnum.Milliliter,
                DefaultLexer.OUNCES => UnitOfMeasureEnum.Ounce,
                DefaultLexer.TABLESPOONS => UnitOfMeasureEnum.Tablespoon,
                DefaultLexer.TEASPOONS => UnitOfMeasureEnum.Teaspoon,
                _ => throw new ParsingException(
                    $"Unit of Measure recognized, but cannot be mapped: '{context.Start.Text}'")
            };

            return result;
        }
    }
}