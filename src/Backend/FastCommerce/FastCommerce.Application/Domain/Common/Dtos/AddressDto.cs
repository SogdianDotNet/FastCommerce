using FastCommerce.Domain.Entities.Common.Enums;

namespace FastCommerce.Application.Domain.Common.Dtos;

public class AddressDto : BaseDto
{
    /// <summary>
    /// Street.
    /// </summary>
    public string? Street { get; set; }

    /// <summary>
    /// HouseNumber.
    /// </summary>
    public int HouseNumber { get; set; }

    /// <summary>
    /// HouseNumberAddition.
    /// </summary>
    public string? HouseNumberAddition { get; set; }

    /// <summary>
    /// City.
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// ZipCode.
    /// </summary>
    public string? ZipCode { get; set; }

    /// <summary>
    /// State.
    /// </summary>
    public string? State { get; set; }

    /// <summary>
    /// StartFrom.
    /// </summary>
    public DateTime StartFrom { get; set; }

    /// <summary>
    /// StartTo.
    /// </summary>
    public DateTime? StartTo { get; set; }

    /// <summary>
    /// AddressType.
    /// </summary>
    public AddressType AddressType { get; set; }

    /// <summary>
    /// Country.
    /// </summary>
    public virtual CountryDto? Country { get; set; }
}
