namespace FastCommerce.Domain.Entities.Account;

public class ActivityLog : Entity
{
    /// <summary>
    /// IpAddress.
    /// </summary>
    public string? IpAddress { get; set; }

    /// <summary>
    /// Account.
    /// </summary>
    public virtual ApplicationAccount? Account { get; set; }
}
