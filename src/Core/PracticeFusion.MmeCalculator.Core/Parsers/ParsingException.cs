using System;
using System.Runtime.Serialization;

namespace PracticeFusion.MmeCalculator.Core.Parsers
{
    /// <summary>
    /// A general exception for parsing errors
    /// </summary>
    [Serializable]
    public class ParsingException : Exception
    {
        /// <inheritdoc />
        public ParsingException()
        {
        }

        /// <inheritdoc />
        public ParsingException(string message) : base(message)
        {
        }

        /// <inheritdoc />
        public ParsingException(string message, Exception inner) : base(message, inner)
        {
        }

        /// <inheritdoc />
        protected ParsingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
