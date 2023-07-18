using System.Globalization;
using FastCommerce.Application.Interfaces;

namespace FastCommerce.Infrastructure.Helpers;

public sealed class Clock : IClock
{
    private DateTime? _now;

    public Clock()
    {
    }

    public Clock(DateTime now) => _now = now;

    public Clock(string dateTime) => _now = DateTime.Parse(dateTime, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal);

    public DateTime Now => _now ?? DateTime.Now;

    public DateTime UtcNow => _now?.ToUniversalTime() ?? DateTime.UtcNow;

    public DateTime Today => _now?.Date ?? DateTime.Today;

    public DateTime UtcToday => _now?.ToUniversalTime().Date ?? DateTime.UtcNow.Date;

    public void Set(DateTime now) => _now = now;

    public void Set(string now) => _now = DateTime.Parse(now, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal);

    public void Reset() => _now = null;
}
