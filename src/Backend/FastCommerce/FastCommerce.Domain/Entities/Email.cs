using FastCommerce.Domain.Entities.Base;

namespace FastCommerce.Domain.Entities;

public class Email : Entity
{
    public string? To { get; set; }

    public string? From { get; set; }

    public string? Subject { get; set; }

    public string? Body { get; set; }
}
