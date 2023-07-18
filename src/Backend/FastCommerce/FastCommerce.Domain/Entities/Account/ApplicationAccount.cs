using FastCommerce.Domain.Attributes;

namespace FastCommerce.Domain.Entities.Account;

[DisableAudit]
public class ApplicationAccount : EntityIdentity, IEntity
{
    /// <summary>
    /// Firstname.
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// Lastname.
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// LastLoginDateUtc.
    /// </summary>
    public DateTime? LastLoginDateUtc { get; set; }

    /// <summary>
    /// AccountRoles.
    /// </summary>
    public virtual ICollection<ApplicationAccountRole>? AccountRoles { get; set; }

    /// <summary>
    /// Claims.
    /// </summary>
    public virtual ICollection<ApplicationAccountClaim>? Claims { get; set; }

    /// <summary>
    /// Logins.
    /// </summary>
    public virtual ICollection<ApplicationAccountLogin>? Logins { get; set; }

    /// <summary>
    /// Tokens.
    /// </summary>
    public virtual ICollection<ApplicationAccountToken>? Tokens { get; set; }

    /// <summary>
    /// ActivityLogs.
    /// </summary>
    public virtual ICollection<ActivityLog>? ActivityLogs { get; set; }

    /// <summary>
    /// Permissions.
    /// </summary>
    public virtual ICollection<Permission>? Permissions { get; set; }
}
