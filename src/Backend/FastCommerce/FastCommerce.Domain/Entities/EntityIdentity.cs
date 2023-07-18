using FastCommerce.Domain.Entities.Common.Enums;
using Microsoft.AspNetCore.Identity;

namespace FastCommerce.Domain.Entities;

public abstract class EntityIdentity : IdentityUser<Guid>, IEntity
{
    public DateTime CreatedUtc { get; set; }

    public DateTime UpdatedUtc { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedUtc { get; set; }

    public EntityStatus EntityStatus { get; set; }
}
