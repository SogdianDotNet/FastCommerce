using FastCommerce.Domain.Entities.Base;

namespace FastCommerce.Domain.Entities;

public class VatRate : Entity
{
    /// <summary>
    /// Rate.
    /// </summary>
    public decimal Rate { get; set; }

    /// <summary>
    /// ActiveFrom.
    /// </summary>
    public DateTime ActiveFrom { get; set; }

    /// <summary>
    /// ActiveTo.
    /// </summary>
    public DateTime? ActiveTo { get; set; }

    /// <summary>
    /// Country.
    /// </summary>
    public virtual Country? Country { get; set; }
}
