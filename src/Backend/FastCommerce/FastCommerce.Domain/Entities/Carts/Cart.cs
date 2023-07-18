using FastCommerce.Domain.Entities.Carts.Enums;
using FastCommerce.Domain.Entities.Orders;

namespace FastCommerce.Domain.Entities.Carts;

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
