using FastCommerce.Domain.Entities;
using FastCommerce.Domain.Entities.Account;
using FastCommerce.Infrastructure.SqlServer.Master.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FastCommerce.Infrastructure.SqlServer;

public abstract class BaseIdentityDbContext<TContext>
    : IdentityDbContext<
        ApplicationAccount, ApplicationRole, Guid, ApplicationAccountClaim, ApplicationAccountRole, ApplicationAccountLogin, ApplicationRoleClaim, ApplicationAccountToken>
    where TContext : DbContext
{
    private readonly IAuditEntryService _auditEntryService;

    public BaseIdentityDbContext(DbContextOptions<TContext> options, IAuditEntryService auditEntryService)
        : base(options)
    {
        _auditEntryService = auditEntryService ?? throw new ArgumentNullException(nameof(auditEntryService));
    }

    public virtual DbSet<AuditEntry> AuditEntries { get; set; }

    public override int SaveChanges()
    {
        OnBeforeSaveChanges();
        UpdateAuditColumns();

        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        OnBeforeSaveChanges();
        UpdateAuditColumns();

        return base.SaveChangesAsync(cancellationToken);
    }

    private void UpdateAuditColumns()
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            switch (entry.State)
            {
                case EntityState.Added when entry.Entity is Entity entity:
                    entity.CreatedUtc = DateTime.UtcNow;
                    entity.UpdatedUtc = DateTime.UtcNow;
                    break;

                case EntityState.Modified when entry.Entity is Entity entity:
                    entity.UpdatedUtc = DateTime.UtcNow;
                    break;

                case EntityState.Deleted when entry.Entity is Entity entity:
                    entity.IsDeleted = true;
                    entity.DeletedUtc = DateTime.UtcNow;
                    entry.State = EntityState.Modified;
                    break;
            }
        }
    }

    private void OnBeforeSaveChanges()
    {
        ChangeTracker.DetectChanges();
        var auditEntries = _auditEntryService.Create(ChangeTracker.Entries().ToList());
        AuditEntries.AddRange(auditEntries);
    }
}
