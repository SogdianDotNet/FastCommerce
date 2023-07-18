namespace FastCommerce.Application.Domain.Common.Dtos;

public class EmailDto : BaseDto
{
    public string? To { get; set; }

    public string? From { get; set; }

    public string? Subject { get; set; }

    public string? Body { get; set; }
}
