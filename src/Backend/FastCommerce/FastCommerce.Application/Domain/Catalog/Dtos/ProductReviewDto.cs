using FastCommerce.Application.Domain.Customers.Dtos;

namespace FastCommerce.Application.Domain.Catalog.Dtos;

public class ProductReviewDto : BaseDto
{
    /// <summary>
    /// Rating.
    /// </summary>
    public int Rating { get; set; }

    /// <summary>
    /// IsApproved.
    /// </summary>
    public bool IsApproved { get; set; }

    /// <summary>
    /// Title.
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// ReviewText.
    /// </summary>
    public string? ReviewText { get; set; }

    /// <summary>
    /// ReplyText.
    /// </summary>
    public string? ReplyText { get; set; }

    /// <summary>
    /// CustomerNotifiedOfReply.
    /// </summary>
    public bool CustomerNotifiedOfReply { get; set; }

    /// <summary>
    /// Customer.
    /// </summary>
    public virtual CustomerDto? Customer { get; set; }

    /// <summary>
    /// Product.
    /// </summary>
    public virtual ProductDto? Product { get; set; }
}
