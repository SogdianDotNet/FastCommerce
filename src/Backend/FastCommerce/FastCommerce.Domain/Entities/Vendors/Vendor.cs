using FastCommerce.Domain.Entities.Catalog;
using FastCommerce.Domain.Entities.Common;

namespace FastCommerce.Domain.Entities.Vendors;

public class Vendor : Entity
{
    /// <summary>
    /// Name.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Email.
    /// </summary>
    public string? Email { get; set; }

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

    /// <summary>
    /// VendorAccounts.
    /// </summary>
    public virtual ICollection<VendorAccount>? VendorAccounts { get; set; }
}
