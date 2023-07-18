using FastCommerce.Domain.Entities.Catalog;

namespace FastCommerce.Domain.Entities.Discounts;

public class Discount : Entity
{
    /// <summary>
    /// Percentage.
    /// </summary>
    public decimal? Percentage { get; set; }

    /// <summary>
    /// Amount.
    /// </summary>
    public decimal? Amount { get; set; }

    /// <summary>
    /// UsePercentage.
    /// </summary>
    public bool UsePercentage { get; set; } = false;

    /// <summary>
    /// UseAmount.
    /// </summary>
    public bool UseAmount { get; set; } = false;

    /// <summary>
    /// MaximumDiscountedQuantity.
    /// </summary>
    public int? MaximumDiscountedQuantity { get; set; }

    /// <summary>
    /// StartFrom.
    /// </summary>
    public DateTime StartFrom { get; set; }

    /// <summary>
    /// StartTo.
    /// </summary>
    public DateTime? StartTo { get; set; }

    /// <summary>
    /// Price.
    /// </summary>
    public virtual ProductPrice? Price { get; set; }
}
