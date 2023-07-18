using FastCommerce.Application.Common.Models;
using FastCommerce.Application.Domain.Account.Dtos;
using FastCommerce.Domain.Entities.Account.Enums;
using FastCommerce.Domain.Entities.Common.Enums;

namespace FastCommerce.Application.Domain.Account.Interfaces;

public interface IAccountService
{
    Task<IPagedList<ApplicationAccountDto>> GetAsync(Guid? vendorId, EntityStatus entityStatus = EntityStatus.Active,
        int pageIndex = 0, int pageSize = int.MaxValue, CancellationToken cancellationToken = default);

    Task<ApplicationAccountDto> GetByIdAsync(Guid userId, CancellationToken cancellationToken = default);

    Task<ApplicationAccountDto> CreateAsync(CreateApplicationAccountDto createApplicationAccountDto, CancellationToken cancellationToken = default);

    Task<ApplicationAccountDto> UpdateAsync(ApplicationAccountDto applicationAccountDto, CancellationToken cancellationToken = default);

    Task DeleteByIdAsync(Guid userId, CancellationToken cancellationToken = default);

    Task AssignRoleAsync(Guid userId, AccountRole role, Guid? vendorId, CancellationToken cancellationToken = default);

    Task BlockAsync(Guid userId, DateTime? blockUntil, CancellationToken cancellationToken = default);

    Task<LoginResults> Login(string userNameOrEmail, string password, string? ipAddress, CancellationToken cancellationToken = default);
}
