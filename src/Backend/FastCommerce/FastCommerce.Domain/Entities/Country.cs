using FastCommerce.Domain.Entities.Base;

namespace FastCommerce.Domain.Entities;

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
    /// VatRates.
    /// </summary>
    public ICollection<VatRate>? VatRates { get; set; }
}
