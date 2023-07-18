using FastCommerce.Domain.Attributes;

namespace FastCommerce.Domain.Entities.Security;

[DisableAudit]
public class SecuritySettings : Entity
{
    /// <summary>
    /// EncryptionKey.
    /// </summary>
    public string? EncryptionKey { get; set; }

    /// <summary>
    /// UseAesEncryptionAlgorithm.
    /// </summary>
    public bool UseAesEncryptionAlgorithm { get; set; }
}
