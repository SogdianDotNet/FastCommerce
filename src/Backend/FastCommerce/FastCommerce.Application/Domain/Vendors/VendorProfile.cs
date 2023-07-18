using AutoMapper;
using FastCommerce.Application.Domain.Vendors.Dtos;
using FastCommerce.Domain.Entities.Vendors;

namespace FastCommerce.Application.Domain.Vendors;

public class VendorProfile : Profile
{
    public VendorProfile()
    {
        CreateMap<Vendor, VendorDto>();
        CreateMap<VendorAccount, VendorAccountDto>();
    }
}
