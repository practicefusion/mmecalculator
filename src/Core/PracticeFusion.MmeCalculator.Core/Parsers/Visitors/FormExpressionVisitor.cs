using System.Collections.Generic;
using Antlr4.Runtime;
using PracticeFusion.MmeCalculator.Core.Entities;
using PracticeFusion.MmeCalculator.Core.Parsers.Generated;

namespace PracticeFusion.MmeCalculator.Core.Parsers.Visitors
{
    internal class FormExpressionVisitor : IManyToOneVisitor<DefaultParser.FormExpressionContext, Form>
    {
        public Form VisitAllRoot(DefaultParser.FormExpressionContext[] contexts)
        {
            if (contexts == null || contexts.Length == 0)
            {
                throw new ParsingException("Empty context.");
            }

            var result = new Form();
            contexts.SetStartAndStopIndex(result);
            result.ValueEnums = new List<FormEnum>();

            foreach (var context in contexts)
            {
                result.ValueEnums.AddRange(VisitRoot(context).ValueEnums);
            }

            return result;
        }

        public Form VisitRoot(DefaultParser.FormExpressionContext context)
        {
            if (context == null)
            {
                throw new ParsingException("Empty context.");
            }

            var result = new Form();
            context.SetStartAndStopIndex(result);
            result.ValueEnums = new List<FormEnum>();

            if (context.formRoute() != null)
            {
                result.ValueEnums.Add(VisitFormEnum(context.formRoute().Start));
            }

            result.ValueEnums.Add(VisitFormEnum(context.form().Start));

            return result;
        }

        private static FormEnum VisitFormEnum(IToken token)
        {
            return token.Type switch
            {
                DefaultLexer.APPLICATION => FormEnum.Application,
                DefaultLexer.BUCCAL => FormEnum.Buccal,
                DefaultLexer.CAPSULE => FormEnum.Capsule,
                DefaultLexer.CARTRIDGE => FormEnum.Cartridge,
                DefaultLexer.DOSE or DefaultLexer.EACH => FormEnum.Dose,
                DefaultLexer.DROP => FormEnum.Drop,
                DefaultLexer.ELIXIR => FormEnum.Elixir,
                DefaultLexer.FILM => FormEnum.Film,
                DefaultLexer.INJECTABLE => FormEnum.Injectable,
                DefaultLexer.INJECTION => FormEnum.Injection,
                DefaultLexer.LIQUID => FormEnum.Liquid,
                DefaultLexer.LOLLIPOP => FormEnum.Lollipop,
                DefaultLexer.LOZENGE => FormEnum.Lozenge,
                DefaultLexer.NASAL => FormEnum.Nasal,
                DefaultLexer.ORAL => FormEnum.Oral,
                DefaultLexer.PATCH => FormEnum.Patch,
                DefaultLexer.PIECE => FormEnum.Piece,
                DefaultLexer.PILL => FormEnum.Pill,
                DefaultLexer.PUFF => FormEnum.Puff,
                DefaultLexer.RECTAL => FormEnum.Rectal,
                DefaultLexer.SOLUTION => FormEnum.Solution,
                DefaultLexer.SPRAY => FormEnum.Spray,
                DefaultLexer.SUBLINGUAL => FormEnum.Sublingual,
                DefaultLexer.SUPPOSITORY => FormEnum.Suppository,
                DefaultLexer.SUSPENSION => FormEnum.Suspension,
                DefaultLexer.SYRINGE => FormEnum.Syringe,
                DefaultLexer.SYRUP => FormEnum.Syrup,
                DefaultLexer.SYSTEM => FormEnum.System,
                DefaultLexer.TABLET => FormEnum.Tablet,
                DefaultLexer.TDP => FormEnum.Tdp,
                DefaultLexer.TRANSDERMAL => FormEnum.Transdermal,
                DefaultLexer.TROCHE => FormEnum.Troche,
                _ => throw new ParsingException($"Drug form recognized, but cannot be mapped: '{token.Text}'"),
            };
        }
    }
}
