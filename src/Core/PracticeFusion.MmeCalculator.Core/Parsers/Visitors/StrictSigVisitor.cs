using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Messages;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;
using System.Collections.Generic;

namespace PracticeFusion.MmeCalculator.Core.Parsers.Visitors
{
    internal class StrictSigVisitor : IVisitorCreator<DefaultParser.StrictSigContext, ParsedSig>
    {
        public ParsedSig VisitRoot(DefaultParser.StrictSigContext context)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            var result = new ParsedSig();
            context.SetStartAndStopIndex(result);
            result.Dosages = new List<Dosage>();

            if (context.strictDosage() == null)
            {
                return result;
            }

            var dosageVisitor = new StrictDosageVisitor();
            foreach (DefaultParser.StrictDosageContext dosageContext in context.strictDosage())
            {
                Dosage dosage = dosageVisitor.VisitRoot(dosageContext);
                result.Dosages.Add(dosage);
            }

            return result;
        }
    }
}