using FastCommerce.Domain.Entities.Account.Enums;

namespace FastCommerce.Application.Domain.Account.Dtos;

public class ApplicationAccountDto : BaseDto
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
    /// EmailConfirmed.
    /// </summary>
    public bool EmailConfirmed { get; set; }

    /// <summary>
    /// PhoneNumber.
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// PhoneNumberConfirmed.
    /// </summary>
    public bool PhoneNumberConfirmed { get; set; }

    /// <summary>
    /// TwoFactorEnabled.
    /// </summary>
    public bool TwoFactorEnabled { get; set; }

    /// <summary>
    /// LockoutEnd.
    /// </summary>
    public DateTimeOffset? LockoutEnd { get; set; }

    /// <summary>
    /// LockoutEnabled.
    /// </summary>
    public bool LockoutEnabled { get; set; }

    /// <summary>
    /// AccessFailedCount.
    /// </summary>
    public int AccessFailedCount { get; set; }

    /// <summary>
    /// Role.
    /// </summary>
    public AccountRole Role { get; set; }
}
