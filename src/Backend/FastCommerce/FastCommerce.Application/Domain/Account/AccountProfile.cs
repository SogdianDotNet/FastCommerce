using AutoMapper;
using FastCommerce.Application.Domain.Account.Dtos;
using FastCommerce.Domain.Entities.Account;
using FastCommerce.Domain.Entities.Account.Enums;

namespace FastCommerce.Application.Domain.Account;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<ApplicationAccount, ApplicationAccountDto>()
            .ForMember(d => d.Role, o => o.MapFrom(s => s.AccountRoles));

        CreateMap<Permission, PermissionDto>(MemberList.Destination);

        CreateMap<ICollection<ApplicationAccountRole>, AccountRole>()
            .ForMember(d => d, o => o.MapFrom(s => MapToAccountRole(s)));

        CreateMap<CreateApplicationAccountDto, ApplicationAccount>(MemberList.None);
    }

    private static AccountRole MapToAccountRole(IEnumerable<ApplicationAccountRole> accountRoles)
    {
        var accountRole = accountRoles?.FirstOrDefault() ?? throw new InvalidOperationException();

        return accountRole?.Role?.Name switch
        {
            "customer" => AccountRole.Customer,
            "vendor" => AccountRole.Vendor,
            "admin" => AccountRole.Admin,
            "superadmin" => AccountRole.SuperAdmin,
            _ => throw new InvalidOperationException(),
        };
    }
}
