using System;

namespace PracticeFusion.MmeCalculator.Core.Entities
{
    /// <summary>
    /// Additional instructions for a dosage, containing one <see cref="AdditionalInstructionEnum"/> and/or a description.
    /// </summary>
    /// <inheritdoc />
    [Serializable]
    public class AdditionalInstruction : EnumParsedEntity<AdditionalInstructionEnum>
    {
        /// <summary>
        /// Optional text included in the instruction
        /// </summary>
        public string? Description { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            if (ValueEnum == AdditionalInstructionEnum.Unknown)
            {
                return Description ?? "";
            }

            // clean up the latin, should be moved to the parser
            // as an addition to the rule.
            if (Description == "ac" || Description == "pc")
            {
                return base.ToString();
            }

            return Description ?? base.ToString();
        }
    }
}
