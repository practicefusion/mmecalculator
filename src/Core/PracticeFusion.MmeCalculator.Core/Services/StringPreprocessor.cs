using System.Text.RegularExpressions;

namespace PracticeFusion.MmeCalculator.Core.Services
{
    /// <inheritdoc />
    public class StringPreprocessor : IStringPreprocessor
    {
        /// <inheritdoc />
        public string Normalize(string inbound)
        {
            Regex.CacheSize = 1000;
            // lowercase
            string normalized = inbound.ToLowerInvariant();

            // reduce 's to s
            normalized = Regex.Replace(normalized, @"(\s*\'s)", "s", RegexOptions.Compiled);

            // remove unnecessary chars
            // SEMICOLON: unless surrounded by digits, like time
            // PERIOD: unless surrounded by digits, like a decimal
            // COMMA: unless  surrounded by digits, like thousands separator
            var unnecessaryCharsPattern = @"([\!\$\%\^\#\'\""\*\[\]\;\<\>\?_\+]|(?!<[0-9]):(?![0-9])|(?!<[0-9])[\.\,](?![0-9]))+";
            normalized = Regex.Replace(normalized, unnecessaryCharsPattern, " ", RegexOptions.Compiled);

            // replace more than one space with a single space
            var spacingPattern = @"\s\s*";
            normalized = Regex.Replace(normalized, spacingPattern, " ", RegexOptions.Compiled);

            // replace words with numbers
            normalized = Regex.Replace(normalized, @"\btwenty(?:-|\s)*four\b", "24", RegexOptions.Compiled);
            normalized = Regex.Replace(normalized, @"\b(forty|fourty)(?:-|\s)*eight\b", "48", RegexOptions.Compiled);
            normalized = Regex.Replace(normalized, @"\bseventy(?:-|\s)*two\b", "72", RegexOptions.Compiled);
            normalized = Regex.Replace(normalized, @"\b(1|one) and(\s(a|one))?\shalf\b", "1.5", RegexOptions.Compiled);
            normalized = Regex.Replace(normalized, @"\b(one-half|onehalf|one half)\b", "0.5", RegexOptions.Compiled);
            normalized = Regex.Replace(normalized, @"\b(2|two) and\s?(a|one|\s)?half\b", "2.5", RegexOptions.Compiled);
            normalized = Regex.Replace(normalized, @"\bone\b", "1", RegexOptions.Compiled);
            normalized = Regex.Replace(normalized, @"\btwo\b|\b2nd\b", "2", RegexOptions.Compiled);
            normalized = Regex.Replace(normalized, @"\bthree\b|\b3rd\b", "3", RegexOptions.Compiled);
            normalized = Regex.Replace(normalized, @"\bfour\b", "4", RegexOptions.Compiled);
            normalized = Regex.Replace(normalized, @"\bfive\b", "5", RegexOptions.Compiled);
            normalized = Regex.Replace(normalized, @"\bsix\b", "6", RegexOptions.Compiled);
            normalized = Regex.Replace(normalized, @"\bseven\b", "7", RegexOptions.Compiled);
            normalized = Regex.Replace(normalized, @"\beight\b", "8", RegexOptions.Compiled);
            normalized = Regex.Replace(normalized, @"\bnine\b", "9", RegexOptions.Compiled);
            normalized = Regex.Replace(normalized, @"\bten\b", "10", RegexOptions.Compiled);
            normalized = Regex.Replace(normalized, @"\btwelve\b", "12", RegexOptions.Compiled);
            normalized = Regex.Replace(normalized, @"\bhalf a(?:n)?\b|\bhalf\b", "0.5", RegexOptions.Compiled);

            // replace fractions
            normalized = Regex.Replace(normalized, @"(\d) 1(\\|\/)2", "$1.5", RegexOptions.Compiled);
            normalized = Regex.Replace(normalized, @"1(\\|\/)2", "0.5", RegexOptions.Compiled);

            // replace pairs of numbers "take 1 (1) tablets" -> "take 1 tablets"
            normalized = Regex.Replace(normalized, @"(\d+)\s\(\1\)", "$1", RegexOptions.Compiled);

            // replace strip off parens around single numbers (only after pairs have been normalized).
            normalized = Regex.Replace(normalized, @"\((\d+)\)", "$1", RegexOptions.Compiled);

            // replace (s) with just s: milliliter(s) -> milliliters
            normalized = Regex.Replace(normalized, @"(\s*\(s\))", "s", RegexOptions.Compiled);

            // replace "1 once" with just "1"
            normalized = Regex.Replace(normalized, @"(1 once)", "1", RegexOptions.Compiled);

            // replace "once every" with just "every"
            normalized = Regex.Replace(normalized, @"once every", "every", RegexOptions.Compiled);

            // replace "once", "twice", "thrice"
            normalized = Regex.Replace(normalized, @"once", "1 time", RegexOptions.Compiled);
            normalized = Regex.Replace(normalized, @"twice", "2 times", RegexOptions.Compiled);
            normalized = Regex.Replace(normalized, @"thrice", "3 times", RegexOptions.Compiled);

            // interpolate "place|apply|change patch" to "place|apply|change 1 patch"
            normalized = Regex.Replace(normalized, @"\b(replace|place|apply|change)\spatch\s", "$1 1 patch ", RegexOptions.Compiled);

            // interpolate "change every" -> "change 1 every"
            normalized = Regex.Replace(normalized, @"^change (every|q)", "change 1 $1", RegexOptions.Compiled);

            // remove "and change/replace"
            normalized = Regex.Replace(
                normalized,
                @"((and\s)?(chang(e|ed|ing)?|replac(e|ed|ing)?)\s)",
                "",
                RegexOptions.Compiled);

            // w/o to without
            normalized = Regex.Replace(normalized, @"w/o|w\\o", "without", RegexOptions.Compiled);
            normalized = Regex.Replace(normalized, @"w/\s*", "with ", RegexOptions.Compiled);

            return normalized.Trim();
        }
    }
}
