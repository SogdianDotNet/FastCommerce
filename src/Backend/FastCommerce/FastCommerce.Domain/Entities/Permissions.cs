using FastCommerce.Domain.Entities.Base;

namespace FastCommerce.Domain.Entities;

public class Permissions : Entity
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
