using FastCommerce.Domain.Entities.Account;
using FastCommerce.Domain.Entities.Carts;
using FastCommerce.Domain.Entities.Vendors;
using Microsoft.EntityFrameworkCore;

namespace FastCommerce.Application.Interfaces;

public interface IFastCommerceDbContext
{
    #region DbSets

    #region Account

    DbSet<ActivityLog>? ActivityLogs { get; set; }
    DbSet<Permission>? Permissions { get; set; }
    DbSet<ApplicationAccount>? Users { get; set; }

    #endregion

    #region Carts

    DbSet<Cart>? Carts { get; set; }
    DbSet<CartItem>? CartItems { get; set; }

    #endregion

    #region Vendors

    DbSet<Vendor>? Vendors { get; set; }
    DbSet<VendorAccount>? VendorAccounts { get; set; }

    #endregion

    #endregion

    #region Methods

    int SaveChanges();

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    #endregion
}
