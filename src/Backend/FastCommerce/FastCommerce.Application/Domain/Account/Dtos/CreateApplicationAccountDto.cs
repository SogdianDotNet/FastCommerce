using FastCommerce.Domain.Entities.Account.Enums;

namespace FastCommerce.Application.Domain.Account.Dtos;

public class CreateApplicationAccountDto
{
    /// <summary>
    /// Firstname.
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// Lastname.
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// UserName.
    /// </summary>
    public string? UserName { get; set; }

    /// <summary>
    /// Email.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// PhoneNumber.
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Role.
    /// </summary>
    public AccountRole Role { get; set; }
}
