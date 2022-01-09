using System;

namespace PracticeFusion.MmeCalculator.Core.Entities
{
    /// <summary>
    /// Contains the parsed opioid, from <see cref="OpioidEnum"/>.
    /// </summary>
    /// <inheritdoc />
    [Serializable]
    public class Opioid : EnumParsedEntity<OpioidEnum>
    {
    }
}
