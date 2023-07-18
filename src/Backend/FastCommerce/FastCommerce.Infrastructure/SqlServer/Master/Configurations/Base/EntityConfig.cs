using FastCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastCommerce.Infrastructure.SqlServer.Master.Configurations.Base;

internal abstract class EntityConfig<TEntity> where TEntity : Entity
{
    internal virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey((TEntity entity) => entity.Id);
        builder.Property((TEntity entity) => entity.Id)
            .ValueGeneratedOnAdd();
        builder.Property((TEntity entity) => entity.UpdatedUtc)
            .HasColumnType("DATETIME").
            HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAddOrUpdate()
            .IsRequired();
        builder.Property((TEntity entity) => entity.CreatedUtc)
            .HasColumnType("DATETIME")
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAdd()
            .IsRequired();
        builder.Property((TEntity entity) => entity.DeletedUtc)
            .HasColumnType("DATETIME");
    }
}
