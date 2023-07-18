using FastCommerce.Domain.Entities.Common;
using FastCommerce.Domain.Entities.Shipping.Enums;

namespace FastCommerce.Domain.Entities.Shipping;

public class Shipment : Entity
{
    public DateTime EstimatedDeliveryUtc { get; set; }

    public DateTime ShippedAtUtc { get; set; }

    public ShippingStatus ShippingStatus { get; set; }

    public virtual ICollection<Address>? Addresses { get; set; }

    public virtual ICollection<ShipmentEvents>? ShipmentEvents { get; set; }
}
