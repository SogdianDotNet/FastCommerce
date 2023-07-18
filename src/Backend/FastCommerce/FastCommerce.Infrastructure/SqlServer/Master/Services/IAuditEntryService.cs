using FastCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FastCommerce.Infrastructure.SqlServer.Master.Services;

public interface IAuditEntryService
{
    ICollection<AuditEntry> Create(ICollection<EntityEntry> entityEntry);
}
