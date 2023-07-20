using PracticeFusion.MmeCalculator.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace PracticeFusion.MmeCalculator.Core.Parsers
{
    /// <summary>
    ///     A syntax exception for parsing errors
    /// </summary>
    [Serializable]
    public class ParsingSyntaxException : ParsingException
    {
        /// <inheritdoc />
        public ParsingSyntaxException()
        {
            AllSyntaxErrors = new List<(ConfidenceEnum, string, List<string>)>();
        }

        /// <summary>
        ///     Pass in a list of syntax issues, expressed as tuples of <see cref="ConfidenceEnum" /> and <see cref="string" />
        /// </summary>
        /// <param name="reporting"></param>
        public ParsingSyntaxException(List<(ConfidenceEnum, string)> reporting)
        {
            AllSyntaxErrors = reporting.Select(x => (x.Item1, x.Item2, new List<string>())).ToList();
        }

        /// <summary>
        ///     Pass in a list of syntax issues, expressed as tuples of <see cref="ConfidenceEnum" />, <see cref="string" />,
        ///     and <see cref="T:System.Collections.Generic.List`1(System.String)" />.
        /// </summary>
        /// <param name="reporting"></param>
        public ParsingSyntaxException(List<(ConfidenceEnum, string, List<string>)> reporting)
        {
            AllSyntaxErrors = reporting;
        }

        /// <inheritdoc />
        public ParsingSyntaxException(string message) : base(message)
        {
            AllSyntaxErrors = new List<(ConfidenceEnum, string, List<string>)>();
        }

        /// <inheritdoc />
        public ParsingSyntaxException(string message, Exception inner) : base(message, inner)
        {
            AllSyntaxErrors = new List<(ConfidenceEnum, string, List<string>)>();
        }

        /// <inheritdoc />
        protected ParsingSyntaxException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            AllSyntaxErrors = (List<(ConfidenceEnum, string, List<string>)>)info
                .GetValue("Reporting", typeof(List<(ConfidenceEnum, string, List<string>)>))!;
        }

        /// <summary>
        ///     All reported syntax errors
        /// </summary>
        public List<(ConfidenceEnum, string, List<string>)> AllSyntaxErrors { get; }

        /// <inheritdoc />
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            info.AddValue("Reporting", AllSyntaxErrors);
            base.GetObjectData(info, context);
        }
    }
}