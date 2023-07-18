using FastCommerce.Application.Domain.Account.Dtos;

namespace FastCommerce.Application.Domain.Vendors.Dtos;

public class VendorAccountDto : ApplicationAccountDto
{
    /// <summary>
    /// Vendor.
    /// </summary>
    public VendorDto? Vendor { get; set; }
}
