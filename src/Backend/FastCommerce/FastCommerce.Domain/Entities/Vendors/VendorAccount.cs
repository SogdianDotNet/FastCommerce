using FastCommerce.Domain.Attributes;
using FastCommerce.Domain.Entities.Account;

namespace FastCommerce.Domain.Entities.Vendors;

[DisableAudit]
public class VendorAccount : ApplicationAccount
{
    /// <summary>
    /// Vendor.
    /// </summary>
    public virtual Vendor? Vendor { get; set; }
}
