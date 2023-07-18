using FastCommerce.Domain.Attributes;
using FastCommerce.Domain.Entities.Account;
using FastCommerce.Domain.Entities.Common;

namespace FastCommerce.Domain.Entities.Customers;

[DisableAudit]
public class Customer : ApplicationAccount
{
    /// <summary>
    /// IsBlocked.
    /// </summary>
    public bool IsBlocked { get; set; }

    /// <summary>
    /// BlockedAtUtc.
    /// </summary>
    public DateTime? BlockedAtUtc { get; set; }

    /// <summary>
    /// Addresses.
    /// </summary>
    public virtual ICollection<Address>? Addresses { get; set; }
}
