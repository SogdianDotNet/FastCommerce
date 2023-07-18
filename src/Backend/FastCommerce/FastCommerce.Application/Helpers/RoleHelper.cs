using FastCommerce.Application.Constants;
using FastCommerce.Domain.Entities.Account.Enums;

namespace FastCommerce.Application.Helpers;

internal static class RoleHelper
{
    internal static string GetRole(this AccountRole role)
    {
        return role switch
        {
            AccountRole.Customer => RoleData.Customer,
            AccountRole.Vendor => RoleData.Vendor,
            AccountRole.Admin => RoleData.Admin,
            AccountRole.SuperAdmin => RoleData.SuperAdmin,
            _ => throw new InvalidOperationException()
        };
    }
}
