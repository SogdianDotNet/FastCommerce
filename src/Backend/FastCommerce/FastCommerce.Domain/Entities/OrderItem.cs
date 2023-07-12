﻿using FastCommerce.Domain.Entities.Base;

namespace FastCommerce.Domain.Entities;

public class OrderItem : Entity
{
    /// <summary>
    /// Quantity.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Order.
    /// </summary>
    public virtual Order? Order { get; set; }

    /// <summary>
    /// Product.
    /// </summary>
    public virtual Product? Product { get; set; }
}
