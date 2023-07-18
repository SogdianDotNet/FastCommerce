using FastCommerce.Domain.Attributes;

namespace FastCommerce.Domain.Entities.Account;

[DisableAudit]
public class Permission : Entity
{
    /// <summary>
    /// Key.
    /// </summary>
    public string? Key { get; set; }

    /// <summary>
    /// Value.
    /// </summary>
    public string? Value { get; set; }
}
