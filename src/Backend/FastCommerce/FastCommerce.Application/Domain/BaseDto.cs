using FastCommerce.Domain.Entities.Common.Enums;

namespace FastCommerce.Application.Domain;

public class BaseDto
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
    /// EntityStatus.
    /// </summary>
    public EntityStatus EntityStatus { get; set; }
}
