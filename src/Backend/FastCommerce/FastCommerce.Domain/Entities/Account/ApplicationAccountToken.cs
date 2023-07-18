using FastCommerce.Domain.Attributes;
using Microsoft.AspNetCore.Identity;

namespace FastCommerce.Domain.Entities.Account;

[DisableAudit]
public class ApplicationAccountToken : IdentityUserToken<Guid>
{
    /// <summary>
    /// Account.
    /// </summary>
    public virtual ApplicationAccount? Account { get; set; }
}