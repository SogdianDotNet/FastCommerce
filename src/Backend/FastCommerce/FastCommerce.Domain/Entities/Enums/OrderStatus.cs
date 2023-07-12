namespace FastCommerce.Domain.Entities.Enums;

public enum OrderStatus
{
    Unknown = 0,
    Authorized = 1,
    Canceled = 2,
    Shipping = 3,
    Completed = 4,
    Expired = 5,
    Paid = 6
}