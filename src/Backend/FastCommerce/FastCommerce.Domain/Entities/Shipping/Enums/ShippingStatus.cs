namespace FastCommerce.Domain.Entities.Shipping.Enums;

public enum ShippingStatus
{
    Pending = 0,
    PreTransit = 1,
    InTransit = 2,
    OutForDelivery = 3,
    Delivered = 4,
    FailedAttempt = 5,
    WaitingForDelivery = 6,
    Returned = 7,
    Failure = 8,
    Expired = 9
}
