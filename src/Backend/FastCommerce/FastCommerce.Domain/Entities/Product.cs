using FastCommerce.Domain.Entities.Base;

namespace FastCommerce.Domain.Entities;

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
}
