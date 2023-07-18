using FastCommerce.Domain.Entities.Orders.Enums;

namespace FastCommerce.Domain.Entities.Orders;

public class OrderTransaction : Entity
{
    public decimal Amount { get; set; }

    public string? Description { get; set; }

    public TransactionState State { get; set; }

    public virtual Order? Order { get; set; }
}
