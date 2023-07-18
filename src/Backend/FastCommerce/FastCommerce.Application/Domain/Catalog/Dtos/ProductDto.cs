using FastCommerce.Domain.Entities.Vendors;

namespace FastCommerce.Application.Domain.Catalog.Dtos;

public class ProductDto : BaseDto
{
    /// <summary>
    /// Name.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Description.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// ActiveFrom.
    /// </summary>
    public DateTime ActiveFrom { get; set; }

    /// <summary>
    /// ActiveTo.
    /// </summary>
    public DateTime? ActiveTo { get; set; }

    /// <summary>
    /// Products.
    /// </summary>
    public virtual ICollection<ProductPriceDto>? Prices { get; set; }

    /// <summary>
    /// ProductAttributes.
    /// </summary>
    public virtual ICollection<ProductAttributeDto>? ProductAttributes { get; set; }

    /// <summary>
    /// Vendor.
    /// </summary>
    public virtual Vendor? Vendor { get; set; }
}
