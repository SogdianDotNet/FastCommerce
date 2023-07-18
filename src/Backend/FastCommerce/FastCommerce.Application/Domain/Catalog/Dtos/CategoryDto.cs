namespace FastCommerce.Application.Domain.Catalog.Dtos;

public class CategoryDto : BaseDto
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
    /// IsActive.
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Products.
    /// </summary>
    public List<ProductDto>? Products { get; set; } = new();
}
