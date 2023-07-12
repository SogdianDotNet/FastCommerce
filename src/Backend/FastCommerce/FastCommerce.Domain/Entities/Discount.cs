using FastCommerce.Domain.Entities.Base;

namespace FastCommerce.Domain.Entities;

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
    /// StartFrom.
    /// </summary>
    public DateTime StartFrom { get; set; }

    /// <summary>
    /// StartTo.
    /// </summary>
    public DateTime? StartTo { get; set; }

    /// <summary>
    /// Prices.
    /// </summary>
    public virtual ICollection<ProductPrice>? Prices { get; set; }
}
