using FastCommerce.Domain.Entities.Base;
using FastCommerce.Domain.Entities.Enums;

namespace FastCommerce.Domain.Entities;

public class OrderTransaction : Entity
{
    public decimal Amount { get; set; }

    public string? Description { get; set; }

    public TransactionState State { get; set; }

    public virtual Order? Order { get; set; }
}
