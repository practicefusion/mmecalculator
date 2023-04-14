using System;
using System.Collections.Generic;
using PracticeFusion.MmeCalculator.Core.Messages;
using System.Linq;
using System.Runtime.Serialization;

namespace PracticeFusion.MmeCalculator.Core.Parsers
{
    /// <summary>
    /// A syntax exception for parsing errors
    /// </summary>
    [Serializable]
    public class ParsingSyntaxException : ParsingException
    {
        private readonly List<(ConfidenceEnum, string, List<string>)> _reporting;

        /// <summary>
        /// All reported syntax errors
        /// </summary>
        public List<(ConfidenceEnum, string, List<string>)> AllSyntaxErrors => _reporting;

        /// <inheritdoc />
        public ParsingSyntaxException()
        {
            _reporting = new List<(ConfidenceEnum, string, List<string>)>();
        }
        
        /// <summary>
        /// Pass in a list of syntax issues, expressed as tuples of <see cref="ConfidenceEnum"/> and <see cref="string"/>
        /// </summary>
        /// <param name="reporting"></param>
        public ParsingSyntaxException(List<(ConfidenceEnum, string)> reporting)
        {
            _reporting = reporting.Select(x => (x.Item1, x.Item2, new List<string>())).ToList();
        }

        /// <summary>
        /// Pass in a list of syntax issues, expressed as tuples of <see cref="ConfidenceEnum"/>, <see cref="string"/>,
        /// and <see cref="T:System.Collections.Generic.List`1(System.String)" />.
        /// </summary>
        /// <param name="reporting"></param>
        public ParsingSyntaxException(List<(ConfidenceEnum, string, List<string>)> reporting)
        {
            _reporting = reporting;
        }
        
        /// <inheritdoc />
        public ParsingSyntaxException(string message) : base(message)
        {
            _reporting = new List<(ConfidenceEnum, string, List<string>)>();
        }

        /// <inheritdoc />
        public ParsingSyntaxException(string message, Exception inner) : base(message, inner)
        {
            _reporting = new List<(ConfidenceEnum, string, List<string>)>();
        }

        /// <inheritdoc />
        protected ParsingSyntaxException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            _reporting = (List<(ConfidenceEnum, string, List<string>)>)info
                .GetValue("Reporting", typeof(List<(ConfidenceEnum, string, List<string>)>))!;
        }

        /// <inheritdoc />
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }
            info.AddValue("Reporting", _reporting);
            base.GetObjectData(info, context);
        }
    }
}
