namespace FastCommerce.Application.Domain.Account;

public static partial class AccountServicesDefaults
{
    /// <summary>
    /// Gets a password salt key size
    /// </summary>
    public static int PasswordSaltKeySize => 5;

    /// <summary>
    /// Gets a default hash format for customer password
    /// </summary>
    public static string DefaultHashedPasswordFormat => "SHA512";
}
