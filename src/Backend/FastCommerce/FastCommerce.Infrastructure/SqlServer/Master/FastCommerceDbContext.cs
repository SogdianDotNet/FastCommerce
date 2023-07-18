using FastCommerce.Application.Interfaces;
using FastCommerce.Domain.Entities.Account;
using FastCommerce.Domain.Entities.Carts;
using FastCommerce.Domain.Entities.Vendors;
using FastCommerce.Infrastructure.SqlServer.Master.Services;
using Microsoft.EntityFrameworkCore;

namespace FastCommerce.Infrastructure.SqlServer.Master;

public class FastCommerceDbContext : BaseIdentityDbContext<FastCommerceDbContext>, IFastCommerceDbContext
{
    public FastCommerceDbContext(DbContextOptions<FastCommerceDbContext> options, IAuditEntryService auditEntryService)
        : base(options, auditEntryService)
    { }

    #region DbSets

    #region Account

    public virtual DbSet<ActivityLog>? ActivityLogs { get; set; }
    public virtual DbSet<Permission>? Permissions { get; set; }

    #endregion

    #region Carts

    public virtual DbSet<Cart>? Carts { get; set; }
    public virtual DbSet<CartItem>? CartItems { get; set; }

    #endregion

    #region Vendors

    public virtual DbSet<Vendor>? Vendors { get; set; }
    public virtual DbSet<VendorAccount>? VendorAccounts { get; set; }

    #endregion

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //TODO: modelBuilder.Configure();
    }
}
