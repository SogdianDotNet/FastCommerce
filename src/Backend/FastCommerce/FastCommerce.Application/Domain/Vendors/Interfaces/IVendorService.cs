using FastCommerce.Application.Common.Models;
using FastCommerce.Application.Domain.Vendors.Dtos;

namespace FastCommerce.Application.Domain.Vendors.Interfaces;

public interface IVendorService
{
    Task<VendorDto> RegisterAsync(CreateVendorDto createVendorDto, CancellationToken cancellationToken = default);

    Task<VendorAccountDto> RegisterAccountAsync(CreateVendorAccountDto createVendorAccountDto, CancellationToken cancellationToken = default);

    Task DeleteAccountAsync(Guid vendorId, Guid accountId, CancellationToken cancellationToken = default);

    Task<IPagedList<VendorAccountDto>> GetAccountsAsync(Guid? vendorId, CancellationToken cancellationToken = default);

    Task<IPagedList<VendorDto>> GetAsync(CancellationToken cancellationToken = default);

    Task<VendorDto> UpdateAsync(VendorDto vendorDto, CancellationToken cancellationToken = default);

    Task<VendorAccountDto> UpdateAccountAsync(VendorAccountDto accountDto, CancellationToken cancellationToken = default);

    Task DeleteVendorAsync(Guid vendorId, CancellationToken cancellationToken = default);


}
