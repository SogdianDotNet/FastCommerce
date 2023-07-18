using FastCommerce.Domain.Entities.Tax;

namespace FastCommerce.Domain.Entities.Common;

public class Country : Entity
{
    /// <summary>
    /// Name.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Code.
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    /// IsoA2.
    /// </summary>
    public string? IsoA2 { get; set; }

    /// <summary>
    /// VatRates.
    /// </summary>
    public ICollection<VatRate>? VatRates { get; set; }
}
