using PracticeFusion.MmeCalculator.Core.Parsers.Generated;

namespace PracticeFusion.MmeCalculator.Core.Parsers.Visitors
{
    internal class OrdinalNumericVisitor : IVisitorCreator<DefaultParser.OrdinalNumericContext, decimal>
    {
        public decimal VisitRoot(DefaultParser.OrdinalNumericContext context)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            return context.Start.Type switch
            {
                DefaultLexer.FIRST => 1,
                DefaultLexer.SECOND => 2,
                DefaultLexer.THIRD => 3,
                DefaultLexer.FOURTH => 4,
                DefaultLexer.FIFTH => 5,
                DefaultLexer.SIXTH => 6,
                DefaultLexer.SEVENTH => 7,
                _ => throw new ParsingException(
                    $"Expected an ordinal value, but cannot be mapped: '{context.Start.Text}'")
            };
        }
    }
}
