using FastCommerce.Domain.Entities.Account;
using FastCommerce.Infrastructure.SqlServer.Master.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastCommerce.Infrastructure.SqlServer.Master.Configurations;

internal class ActivityLogConfig : EntityConfig<ActivityLog>, IEntityTypeConfiguration<ActivityLog>
{
    public new void Configure(EntityTypeBuilder<ActivityLog> builder)
    {

    }
}

internal class ApplicationAccountConfig : IEntityTypeConfiguration<ApplicationAccount>
{
    public void Configure(EntityTypeBuilder<ApplicationAccount> builder)
    {

    }
}

internal class ApplicationAccountClaimConfig : IEntityTypeConfiguration<ApplicationAccountClaim>
{
    public void Configure(EntityTypeBuilder<ApplicationAccountClaim> builder)
    {

    }
}

internal class ApplicationAccountLoginConfig : IEntityTypeConfiguration<ApplicationAccountLogin>
{
    public void Configure(EntityTypeBuilder<ApplicationAccountLogin> builder)
    {

    }
}

internal class ApplicationAccountRoleConfig : IEntityTypeConfiguration<ApplicationAccountRole>
{
    public void Configure(EntityTypeBuilder<ApplicationAccountRole> builder)
    {

    }
}

internal class ApplicationAccountTokenConfig : IEntityTypeConfiguration<ApplicationAccountToken>
{
    public void Configure(EntityTypeBuilder<ApplicationAccountToken> builder)
    {

    }
}


internal class ApplicationRoleConfig : IEntityTypeConfiguration<ApplicationRole>
{
    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {

    }
}


internal class ApplicationRoleClaimConfig : IEntityTypeConfiguration<ApplicationRoleClaim>
{
    public void Configure(EntityTypeBuilder<ApplicationRoleClaim> builder)
    {

    }
}

internal class PermissionConfig : EntityConfig<Permission>, IEntityTypeConfiguration<Permission>
{
    public new void Configure(EntityTypeBuilder<Permission> builder)
    {

    }
}