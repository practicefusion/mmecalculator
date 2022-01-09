using System;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;

namespace PracticeFusion.MmeCalculator.Core.Parsers.Visitors
{
    internal class NumericValueVisitor : IVisitorCreator<DefaultParser.NumericValueContext, decimal>
    {
        public decimal VisitRoot(DefaultParser.NumericValueContext context)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            try
            {
                if (context.wordNumber() != null)
                {
                    return VisitWordNumber(context.wordNumber());
                }

                //// validate the numeric string is valid, as .NET will parse "1,2" as "12" even with
                //// invariant culture.
                string numericValue = context.GetText();

                // while a regex would be simpler here, the performance hit of the typical
                // numeric pattern matching rules is too high, so instead we will walk through 
                // every digit from left to right, if we find a comma, we'll look ahead to make
                // sure the next three chars are digits.
                //
                // if the fourth character is a digit, no commas allowed.
                // 
                // should pass: 1,500
                // should fail: 1,5
                // should fail: 4500,500
                bool passedDecimal = false;
                bool commasAllowed = true;
                bool commaFound = false;
                char[] chars = numericValue.ToCharArray();
                for (int i = 0; i < chars.Length; i++)
                {
                    var c = chars[i];
                    if (char.IsNumber(c))
                    {
                        // this will prevent 4500,500
                        if (!commaFound && i == 3)
                        {
                            commasAllowed = false;
                        }
                        continue;
                    }

                    if (c == '.')
                    {
                        passedDecimal = true;
                        continue;
                    }

                    if (c == ',')
                    {
                        commaFound = true;

                        // if commas not allowed, no commas.
                        if (!commasAllowed)
                        {
                            throw new ParsingException($"Failed to parse {numericValue} as a valid number.");
                        }

                        // if we're already in the decimal, no commas.
                        if (passedDecimal)
                        {
                            throw new ParsingException($"Failed to parse {numericValue} as a valid number.");
                        }

                        // there should be at least three chars left
                        if (i + 3 >= chars.Length)
                        {
                            throw new ParsingException($"Failed to parse {numericValue} as a valid number.");
                        }

                        // look ahead exactly 3
                        for (int x = 1; x <= 3 && i + x < chars.Length; x++)
                        {
                            if (!char.IsNumber(chars[i + x]))
                            {
                                throw new ParsingException($"Failed to parse {numericValue} as a valid number.");
                            }
                        }

                        // the 4th should be ',' or '.' or end of string
                        if (i + 4 < chars.Length)
                        {
                            if (chars[i + 4] != ',' && chars[i + 4] != '.')
                            {
                                throw new ParsingException($"Failed to parse {numericValue} as a valid number.");
                            }
                        }

                        // all checks met
                        continue;
                    }

                    // matched nothing, so throw (for example, 1/4)
                    throw new ParsingException($"Failed to parse {numericValue} as a valid number.");
                }

                return decimal.Parse(numericValue);
            }
            catch (Exception e)
            {
                throw new ParsingException("Expected a numeric value", e);
            }
        }

        private static decimal VisitWordNumber(DefaultParser.WordNumberContext context)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            var result = 0m;

            for (var i = 0; i < context.ChildCount; i++)
            {
                // ignore the AND and A_AN
                if (context.children[i] is DefaultParser.WordDigitContext x)
                {
                    decimal digits = VisitWordDigit(x);

                    // peek forward: if the next is 'half', and this is one,
                    // then we can ignore it ('one half' vs. 'one and one half')
                    if (digits == 1m && i + 1 < context.ChildCount && context.children[i + 1] is DefaultParser.WordDigitContext y &&
                        y.Start.Type == DefaultLexer.HALF)
                    {
                        continue;
                    }

                    result += digits;
                }
            }

            return result;
        }

        private static decimal VisitWordDigit(DefaultParser.WordDigitContext context)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            return context.Start.Type switch
            {
                DefaultLexer.ONE => 1m,
                DefaultLexer.TWO => 2m,
                DefaultLexer.THREE => 3m,
                DefaultLexer.FOUR => 4m,
                DefaultLexer.FIVE => 5m,
                DefaultLexer.SIX => 6m,
                DefaultLexer.SEVEN => 7m,
                DefaultLexer.EIGHT => 8m,
                DefaultLexer.NINE => 9m,
                DefaultLexer.TEN => 10m,
                DefaultLexer.TWELVE => 12m,
                DefaultLexer.HALF => 0.5m,
                DefaultLexer.TWENTY => 20m,
                DefaultLexer.THIRTY => 30m,
                DefaultLexer.FORTY => 40m,
                DefaultLexer.SEVENTY => 70m,
                _ => throw new ParsingException($"Expecting a digit expressed as a word, but cannot map: '{context.Start.Text}'")
            };
        }
    }
}
