using FastCommerce.Domain.Entities.Base;

namespace FastCommerce.Domain.Entities;

public class Company : Entity
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
    /// Products.
    /// </summary>
    public virtual ICollection<Product>? Products { get; set; }

    /// <summary>
    /// Address.
    /// </summary>
    public virtual Address? Address { get; set; }
}
