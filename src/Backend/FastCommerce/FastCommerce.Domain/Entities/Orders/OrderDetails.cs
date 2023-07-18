using FastCommerce.Domain.Entities.Customers;

namespace FastCommerce.Domain.Entities.Orders;

public class OrderDetails : Order
{
    /// <summary>
    /// Customer.
    /// </summary>
    public virtual Customer? Customer { get; set; }
}
