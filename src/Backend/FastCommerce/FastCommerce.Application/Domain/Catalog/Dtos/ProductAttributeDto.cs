namespace FastCommerce.Application.Domain.Catalog.Dtos;

public class ProductAttributeDto : BaseDto
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
    /// Product.
    /// </summary>
    public virtual ProductDto? Product { get; set; }
}
