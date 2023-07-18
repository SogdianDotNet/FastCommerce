using FastCommerce.Domain.Entities.Carts;
using FastCommerce.Domain.Entities.Common;
using FastCommerce.Domain.Entities.Orders.Enums;

namespace FastCommerce.Domain.Entities.Orders;

public class Order : Entity
{
    public OrderStatus OrderStatus { get; set; }

    public string? OrderNumber { get; set; }

    public bool IsCanceled { get; set; }

    public bool IsRefunded { get; set; }

    public bool OrderPaidConfirmationEmailSent { get; set; }

    public virtual OrderPayment? OrderPayment { get; set; }

    public virtual Cart? Cart { get; set; }

    public virtual ICollection<Address>? Addresses { get; set; }

    public virtual ICollection<OrderItem>? OrderItems { get; set; }
}
