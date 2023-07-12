using FastCommerce.Domain.Entities.Base;

namespace FastCommerce.Domain.Entities;

public class CartItem : Entity
{
    /// <summary>
    /// Quantity.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Product.
    /// </summary>
    public virtual Product Product { get; set; }

    /// <summary>
    /// Cart.
    /// </summary>
    public virtual Cart Cart { get; set; }
}
