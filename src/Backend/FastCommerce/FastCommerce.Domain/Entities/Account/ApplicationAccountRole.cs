using FastCommerce.Domain.Attributes;
using Microsoft.AspNetCore.Identity;

namespace FastCommerce.Domain.Entities.Account;

[DisableAudit]
public class ApplicationAccountRole : IdentityUserRole<Guid>
{
    /// <summary>
    /// Account.
    /// </summary>
    public virtual ApplicationAccount? Account { get; set; }

    /// <summary>
    /// Role.
    /// </summary>
    public virtual ApplicationRole? Role { get; set; }
}