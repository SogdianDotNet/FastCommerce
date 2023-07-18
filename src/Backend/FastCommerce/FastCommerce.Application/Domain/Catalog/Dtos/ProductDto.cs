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
    public List<ProductPriceDto>? Prices { get; set; } = new();

    /// <summary>
    /// ProductAttributes.
    /// </summary>
    public List<ProductAttributeDto>? ProductAttributes { get; set; } = new();

    /// <summary>
    /// Vendor.
    /// </summary>
    public Vendor? Vendor { get; set; }

    /// <summary>
    /// Category.
    /// </summary>
    public CategoryDto? Category { get; set; }
}
