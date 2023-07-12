using FastCommerce.Domain.Entities.Base;
using FastCommerce.Domain.Entities.Enums;

namespace FastCommerce.Domain.Entities;

public class ShipmentEvents : Entity
{
    public ShippingStatus ShippingStatus { get; set; }

    public string? Note { get; set; }

    public virtual Shipment? Shipment { get; set; }
}
