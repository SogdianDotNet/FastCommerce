using FastCommerce.Domain.Attributes;
using Microsoft.AspNetCore.Identity;

namespace FastCommerce.Domain.Entities.Account;

[DisableAudit]
public class ApplicationRole : IdentityRole<Guid>
{
    /// <summary>
    /// AccountRoles.
    /// </summary>
    public virtual ICollection<ApplicationAccountRole>? AccountRoles { get; set; }

    /// <summary>
    /// RoleClaims.
    /// </summary>
    public virtual ICollection<ApplicationRoleClaim>? RoleClaims { get; set; }
}
