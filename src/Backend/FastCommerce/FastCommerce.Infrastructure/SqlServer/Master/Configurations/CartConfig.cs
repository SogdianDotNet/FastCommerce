using FastCommerce.Domain.Entities.Carts;
using FastCommerce.Infrastructure.SqlServer.Master.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastCommerce.Infrastructure.SqlServer.Master.Configurations;

internal class CartConfig : EntityConfig<Cart>, IEntityTypeConfiguration<Cart>
{
    public new void Configure(EntityTypeBuilder<Cart> builder)
    {

    }
}

internal class CartItemConfig : EntityConfig<CartItem>, IEntityTypeConfiguration<CartItem>
{
    public new void Configure(EntityTypeBuilder<CartItem> builder)
    {

    }
}