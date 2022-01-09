using System.Collections.Generic;
using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Messages;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;

namespace PracticeFusion.MmeCalculator.Core.Parsers.Visitors
{
    internal class SigVisitor : IVisitorCreator<DefaultParser.SigContext, ParsedSig>
    {
        public ParsedSig VisitRoot(DefaultParser.SigContext context)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            var result = new ParsedSig();
            context.SetStartAndStopIndex(result);
            result.Dosages = new List<Dosage>();

            if (context.dosage() == null)
            {
                return result;
            }

            var dosageVisitor = new DosageVisitor();
            foreach (DefaultParser.DosageContext dosageContext in context.dosage())
            {
                Dosage dosage = dosageVisitor.VisitRoot(dosageContext);
                result.Dosages.Add(dosage);
            }

            if (context.freeText() != null)
            {
                result.ClarifyingFreeText = context.freeText().GetOriginalTextWithSpacing();
            }


            return result;
        }
    }
}
