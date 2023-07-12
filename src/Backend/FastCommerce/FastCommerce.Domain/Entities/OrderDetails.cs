namespace FastCommerce.Domain.Entities;

public class OrderDetails : Order
{
    /// <summary>
    /// Customer.
    /// </summary>
    public virtual Customer? Customer { get; set; }
}
