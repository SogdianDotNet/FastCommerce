using FastCommerce.Domain.Attributes;
using Microsoft.AspNetCore.Identity;

namespace FastCommerce.Domain.Entities.Account;

[DisableAudit]
public class ApplicationRoleClaim : IdentityRoleClaim<Guid>
{
    /// <summary>
    /// Role.
    /// </summary>
    public virtual ApplicationRole? Role { get; set; }
}
