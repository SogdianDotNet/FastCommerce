using FastCommerce.Domain.Entities.Enums;

namespace FastCommerce.Domain.Entities.Base;

public abstract class Entity
{
    /// <summary>
    /// Id.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// CreatedUtc.
    /// </summary>
    public DateTime CreatedUtc { get; set; }

    /// <summary>
    /// UpdatedUtc.
    /// </summary>
    public DateTime UpdatedUtc { get; set; }

    /// <summary>
    /// IsDeleted.
    /// </summary>
    public bool IsDeleted { get; set; } = false;

    /// <summary>
    /// DeletedUtc.
    /// </summary>
    public DateTime? DeletedUtc {  get; set; }

    /// <summary>
    /// EntityStatus.
    /// </summary>
    public EntityStatus EntityStatus { get; set; }
}
