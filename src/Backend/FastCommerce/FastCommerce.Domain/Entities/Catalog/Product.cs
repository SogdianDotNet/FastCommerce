using FastCommerce.Domain.Entities.Vendors;

namespace FastCommerce.Domain.Entities.Catalog;

public class Product : Entity
{
    /// <summary>
    /// Name.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Description.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// ActiveFrom.
    /// </summary>
    public DateTime ActiveFrom { get; set; }

    /// <summary>
    /// ActiveTo.
    /// </summary>
    public DateTime? ActiveTo { get; set; }

    /// <summary>
    /// Products.
    /// </summary>
    public virtual ICollection<ProductPrice>? Prices { get; set; }

    /// <summary>
    /// ProductAttributes.
    /// </summary>
    public virtual ICollection<ProductAttribute>? ProductAttributes { get; set; }

    /// <summary>
    /// Vendor.
    /// </summary>
    public virtual Vendor? Vendor { get; set; }

    /// <summary>
    /// Category.
    /// </summary>
    public virtual Category? Category { get; set; }
}
