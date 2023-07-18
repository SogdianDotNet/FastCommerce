using FastCommerce.Domain.Entities.Common.Enums;

namespace FastCommerce.Domain.Entities;

public interface IEntity
{
    /// <summary>
    /// Id.
    /// </summary>
    Guid Id { get; set; }

    /// <summary>
    /// CreatedUtc.
    /// </summary>
    DateTime CreatedUtc { get; set; }

    /// <summary>
    /// UpdatedUtc.
    /// </summary>
    DateTime UpdatedUtc { get; set; }

    /// <summary>
    /// IsDeleted.
    /// </summary>
    bool IsDeleted { get; set; }

    /// <summary>
    /// DeletedUtc.
    /// </summary>
    DateTime? DeletedUtc { get; set; }

    /// <summary>
    /// EntityStatus.
    /// </summary>
    EntityStatus EntityStatus { get; set; }
}
