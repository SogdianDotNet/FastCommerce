using AutoMapper;
using FastCommerce.Application.Domain.Common.Dtos;
using FastCommerce.Application.Domain.Tax.Dtos;
using FastCommerce.Domain.Entities.Common;
using FastCommerce.Domain.Entities.Tax;

namespace FastCommerce.Application.Domain.Common;
public class CommonProfile : Profile
{
    public CommonProfile()
    {
        CreateMap<Country, CountryDto>()
            .ForMember(s => s.IsEU, o => o.Ignore())
            .ReverseMap();

        CreateMap<VatRate, VatRateDto>().ReverseMap();
    }
}
