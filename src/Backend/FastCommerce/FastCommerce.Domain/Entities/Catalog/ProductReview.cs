using FastCommerce.Domain.Entities.Customers;

namespace FastCommerce.Domain.Entities.Catalog;

public class ProductReview : Entity
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
    public virtual Customer? Customer { get; set; }

    /// <summary>
    /// Product.
    /// </summary>
    public virtual Product? Product { get; set; }
}
