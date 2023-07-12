using FastCommerce.Domain.Entities.Base;
using FastCommerce.Domain.Entities.Enums;

namespace FastCommerce.Domain.Entities;

public class Shipment : Entity
{
    public DateTime EstimatedDeliveryUtc { get; set; }

    public DateTime ShippedAtUtc { get; set; }

    public ShippingStatus ShippingStatus { get; set; }

    public virtual ICollection<Address>? Addresses { get; set; }

    public virtual ICollection<ShipmentEvents>? ShipmentEvents { get; set; }
}
