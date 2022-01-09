using System;

namespace PracticeFusion.MmeCalculator.Core.Entities
{
    /// <summary>
    /// Dose delivery method, containing one <see cref="DoseDeliveryMethodEnum"/>.
    /// </summary>
    /// <inheritdoc />
    [Serializable]
    public class DoseDeliveryMethod : EnumParsedEntity<DoseDeliveryMethodEnum>
    {
    }
}
