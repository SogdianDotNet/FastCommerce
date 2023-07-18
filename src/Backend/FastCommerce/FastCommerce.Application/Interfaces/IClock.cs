namespace FastCommerce.Application.Interfaces;

public interface IClock
{
    DateTime Now { get; }
    DateTime Today { get; }
    DateTime UtcNow { get; }
    DateTime UtcToday { get; }

    void Reset();
    void Set(DateTime now);
    void Set(string now);
}
