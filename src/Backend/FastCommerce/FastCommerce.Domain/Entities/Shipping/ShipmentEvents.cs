using FastCommerce.Domain.Entities.Shipping.Enums;

namespace FastCommerce.Domain.Entities.Shipping;

public class ShipmentEvents : Entity
{
    public ShippingStatus ShippingStatus { get; set; }

    public string? Note { get; set; }

    public virtual Shipment? Shipment { get; set; }
}
