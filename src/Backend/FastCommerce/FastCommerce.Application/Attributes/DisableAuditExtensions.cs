using System.Reflection;
using FastCommerce.Domain.Attributes;

namespace FastCommerce.Application.Attributes;

public static class DisableAuditExtensions
{
    public static bool IsAuditDisabled(this Type from)
    {
        return from.GetCustomAttribute<DisableAuditAttribute>() is not null;
    }
}
