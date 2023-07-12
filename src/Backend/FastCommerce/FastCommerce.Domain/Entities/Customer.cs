using FastCommerce.Domain.Entities.Base;

namespace FastCommerce.Domain.Entities;

public class Customer : Entity
{
    /// <summary>
    /// FirstName.
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// LastName.
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// EmailAddress.
    /// </summary>
    public string? EmailAddress { get; set; }

    /// <summary>
    /// IsBlocked.
    /// </summary>
    public bool IsBlocked = false;

    /// <summary>
    /// BlockedAtUtc.
    /// </summary>
    public DateTime? BlockedAtUtc { get; set; }

    /// <summary>
    /// Addresses.
    /// </summary>
    public virtual ICollection<Address>? Addresses { get; set; }
}
