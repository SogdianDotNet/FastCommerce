using FastCommerce.Domain.Entities.Discounts;
using FastCommerce.Domain.Entities.Tax;

namespace FastCommerce.Domain.Entities.Catalog;

public class ProductPrice : Entity
{
    /// <summary>
    /// Price.
    /// </summary>
    public decimal Price { get; set; } = 0.00m;

    /// <summary>
    /// ActiveFrom.
    /// </summary>
    public DateTime ActiveFrom { get; set; }

    /// <summary>
    /// ActiveTo.
    /// </summary>
    public DateTime? ActiveTo { get; set; }

    /// <summary>
    /// ProductId.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Product.
    /// </summary>
    public virtual Product? Product { get; set; }

    /// <summary>
    /// VatRate.
    /// </summary>
    public virtual VatRate? VatRate { get; set; }

    /// <summary>
    /// Discounts.
    /// </summary>
    public virtual ICollection<Discount>? Discounts { get; set; }
}
