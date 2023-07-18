namespace FastCommerce.Domain.Entities.Catalog;

public class Category : Entity
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
    /// IsActive.
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Products.
    /// </summary>
    public virtual ICollection<Product>? Products { get; set; }
}
