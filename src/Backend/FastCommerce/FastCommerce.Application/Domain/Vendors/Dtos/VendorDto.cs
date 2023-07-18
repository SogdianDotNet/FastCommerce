using FastCommerce.Application.Domain.Catalog.Dtos;
using FastCommerce.Application.Domain.Common.Dtos;

namespace FastCommerce.Application.Domain.Vendors.Dtos;

public class VendorDto : BaseDto
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
    /// Products.
    /// </summary>
    public List<ProductDto>? Products { get; set; } = new();

    /// <summary>
    /// Address.
    /// </summary>
    public AddressDto? Address { get; set; }

    /// <summary>
    /// VendorAccounts.
    /// </summary>
    public List<VendorAccountDto>? VendorAccounts { get; set; } = new();
}
