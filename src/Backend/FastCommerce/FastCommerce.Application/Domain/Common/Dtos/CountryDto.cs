using FastCommerce.Application.Domain.Tax.Dtos;
using FastCommerce.Application.Helpers;

namespace FastCommerce.Application.Domain.Common.Dtos;

public class CountryDto : BaseDto
{
    /// <summary>
    /// Name.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Code.
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    /// IsoA2.
    /// </summary>
    public string? IsoA2 { get; set; }

    /// <summary>
    /// IsEU.
    /// </summary>
    public bool IsEU { get => CountryTools.IsValidEUCountry(Code); }

    /// <summary>
    /// VatRates.
    /// </summary>
    public ICollection<VatRateDto>? VatRates { get; set; }
}
