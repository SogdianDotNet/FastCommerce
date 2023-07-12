using FastCommerce.Domain.Entities.Base;
using FastCommerce.Domain.Entities.Enums;

namespace FastCommerce.Domain.Entities;

public class Cart : Entity
{
    /// <summary>
    /// CartStatus.
    /// </summary>
    public CartStatus CartStatus { get; set; }

    /// <summary>
    /// Order.
    /// </summary>
    public virtual Order? Order { get; set; }

    /// <summary>
    /// CartItems.
    /// </summary>
    public virtual ICollection<CartItem>? CartItems { get; set; }
}
