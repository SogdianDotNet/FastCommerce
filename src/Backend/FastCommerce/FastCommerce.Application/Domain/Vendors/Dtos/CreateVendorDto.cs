using FastCommerce.Application.Domain.Common.Dtos;

namespace FastCommerce.Application.Domain.Vendors.Dtos;

public class CreateVendorDto
{
    /// <summary>
    /// Name.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Email.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Description.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Address.
    /// </summary>
    public AddressDto? Address { get; set; }
}
