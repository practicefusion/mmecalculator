using Antlr4.Runtime;
using PracticeFusion.MmeCalculator.Core.Entities;
using System;
using Interval = Antlr4.Runtime.Misc.Interval;

namespace PracticeFusion.MmeCalculator.Core.Parsers.Visitors
{
    internal static class VisitorUtils
    {
        public static string GetOriginalTextWithSpacing(this ParserRuleContext context)
        {
            // check to make sure we're in a valid context
            if (context.Start == null || context.Stop == null || context.Start.StartIndex < 0 ||
                context.Stop.StopIndex < 0)
            {
                return string.Empty;
            }

            return context.Start.InputStream.GetText(Interval.Of(context.Start.StartIndex, context.Stop.StopIndex));
        }

        public static string GetOriginalTextWithSpacing(this ParserRuleContext[] contexts)
        {
            ParserRuleContext firstContext = contexts[0];
            ParserRuleContext lastContext = contexts[contexts.Length - 1];

            // check to make sure we're in a valid context
            if (firstContext.Start == null || firstContext.Stop == null || firstContext.Start.StartIndex < 0 ||
                firstContext.Stop.StopIndex < 0
                || lastContext.Start == null || lastContext.Stop == null || lastContext.Start.StartIndex < 0 ||
                lastContext.Stop.StopIndex < 0)
            {
                return string.Empty;
            }

            return firstContext.Start.InputStream.GetText(Interval.Of(firstContext.Start.StartIndex,
                lastContext.Stop.StopIndex));
        }

        public static void SetStartAndStopIndex(this ParserRuleContext context, BaseParsedEntity parsedEntity)
        {
            if (context.Start == null || context.Stop == null || context.Start.StartIndex < 0 ||
                context.Stop.StopIndex < 0)
            {
                return;
            }

            parsedEntity.Index = context.Start.StartIndex;
            parsedEntity.Length = context.Stop.StopIndex - context.Start.StartIndex + 1;
        }

        public static void SetStartAndStopIndex(this ParserRuleContext[] contexts, BaseParsedEntity parsedEntity)
        {
            var set = false;

            if (contexts.Length > 0)
            {
                foreach (ParserRuleContext context in contexts)
                {
                    if (context.Start == null || context.Stop == null || context.Start.StartIndex < 0 ||
                        context.Stop.StopIndex < 0)
                    {
                        return;
                    }

                    var start = context.Start.StartIndex;
                    var end = context.Stop.StopIndex;

                    if (!set)
                    {
                        parsedEntity.Index = start;
                        parsedEntity.Length = end - start + 1;
                        set = true;
                    }
                    else
                    {
                        var currentEnd = parsedEntity.Index + parsedEntity.Length;
                        var furthestEnd = Math.Max(currentEnd, end);

                        parsedEntity.Index = Math.Min(parsedEntity.Index, start);
                        parsedEntity.Length = furthestEnd - parsedEntity.Index + 1;
                    }
                }
            }
        }
    }
}