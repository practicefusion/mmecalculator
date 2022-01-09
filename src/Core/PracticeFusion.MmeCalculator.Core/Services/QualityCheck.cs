using System.Collections.Generic;
using System.Linq;
using PracticeFusion.MmeCalculator.Core.Messages;

namespace PracticeFusion.MmeCalculator.Core.Services
{
    internal static class QualityCheck
    {
        public static bool IsTrue(bool condition, ConfidenceEnum confidence, IConfidence analysis, params string[] reasons)
        {
            if (!condition)
            {
                Document(confidence, analysis, reasons);
            }

            return condition;
        }

        public static bool IsNotNull<T>(
            T entity,
            ConfidenceEnum confidence,
            IConfidence analysis,
            params string[] reasons)
        {
            bool assertionResult = entity != null;

            if (!assertionResult)
            {
                Document(confidence, analysis, reasons);
            }

            return assertionResult;
        }

        public static void SetLowestConfidence(IConfidence target, IEnumerable<IConfidence> set, string reason)
        {
            IEnumerable<IConfidence> confidences = set as IConfidence[] ?? set.ToArray();
            ConfidenceEnum minConfidence = confidences.Any() ? confidences.Min(x => x.Confidence) : ConfidenceEnum.None;
            if (minConfidence != ConfidenceEnum.High && target.Confidence >= minConfidence)
            {
                target.Confidence = minConfidence;
                target.ConfidenceReasons.Add(reason);
            }
        }

        private static void Document(ConfidenceEnum confidence, IConfidence analysis, params string[] reasons)
        {
            analysis.Confidence = confidence;
            if (reasons.Length > 0)
            {
                analysis.ConfidenceReasons.AddRange(reasons);
            }
        }
    }
}
