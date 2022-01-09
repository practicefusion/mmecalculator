using System;

namespace PracticeFusion.MmeCalculator.Core.Entities
{
    /// <summary>
    /// One or more drug forms for a given medication, see <see cref="FormEnum"/>.
    /// </summary>
    /// <inheritdoc />
    [Serializable]
    public class Form : MultipleEnumParsedEntity<FormEnum>
    {
    }
}
