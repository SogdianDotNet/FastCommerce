using FastCommerce.Application.Domain.Account.Dtos;
using FastCommerce.Application.Domain.Common.Dtos;

namespace FastCommerce.Application.Domain.Customers.Dtos;

public class CustomerDto : ApplicationAccountDto
{
    /// <summary>
    /// IsBlocked.
    /// </summary>
    public bool IsBlocked { get; set; }

    /// <summary>
    /// BlockedAtUtc.
    /// </summary>
    public DateTime? BlockedAtUtc { get; set; }

    /// <summary>
    /// Addresses.
    /// </summary>
    public virtual ICollection<AddressDto>? Addresses { get; set; }
}