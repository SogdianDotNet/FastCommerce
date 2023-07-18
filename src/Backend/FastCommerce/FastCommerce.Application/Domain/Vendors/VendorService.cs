using AutoMapper;
using FastCommerce.Application.Common.Models;
using FastCommerce.Application.Domain.Vendors.Dtos;
using FastCommerce.Application.Domain.Vendors.Interfaces;

namespace FastCommerce.Application.Domain.Vendors;

public class VendorService : IVendorService
{
    private readonly IMapper _mapper;

    public VendorService(IMapper mapper)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public Task DeleteAccountAsync(Guid vendorId, Guid accountId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteVendorAsync(Guid vendorId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IPagedList<VendorAccountDto>> GetAccountsAsync(Guid? vendorId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IPagedList<VendorDto>> GetAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<VendorAccountDto> RegisterAccountAsync(CreateVendorAccountDto createVendorAccountDto, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<VendorDto> RegisterAsync(CreateVendorDto createVendorDto, CancellationToken cancellationToken = default)
    {
        var vendorDto = _mapper.Map<VendorDto>(createVendorDto);


    }

    public Task<VendorAccountDto> UpdateAccountAsync(VendorAccountDto accountDto, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<VendorDto> UpdateAsync(VendorDto vendorDto, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
