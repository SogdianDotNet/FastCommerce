using FastCommerce.Application.Domain.Common.Dtos;

namespace FastCommerce.Application.Domain.Tax.Dtos;

public class VatRateDto : BaseDto
{
    /// <summary>
    /// Rate.
    /// </summary>
    public decimal Rate { get; set; }

    /// <summary>
    /// ActiveFrom.
    /// </summary>
    public DateTime ActiveFrom { get; set; }

    /// <summary>
    /// ActiveTo.
    /// </summary>
    public DateTime? ActiveTo { get; set; }

    /// <summary>
    /// Country.
    /// </summary>
    public virtual CountryDto? Country { get; set; }
}
