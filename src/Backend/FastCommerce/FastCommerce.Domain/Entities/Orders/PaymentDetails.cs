using FastCommerce.Domain.Attributes;
using FastCommerce.Domain.Entities.Orders.Enums;

namespace FastCommerce.Domain.Entities.Orders;

[DisableAudit]
public class PaymentDetails : Entity
{
    /// <summary>
    /// PaymentType.
    /// </summary>
    public PaymentType PaymentType { get; set; }

    /// <summary>
    /// IBAN.
    /// </summary>
    public string? IBAN { get; set; }
    
    /// <summary>
    /// CreditCardType.
    /// </summary>
    public string? CreditCardType { get; set; }

    /// <summary>
    /// CreditCardName.
    /// </summary>
    public string? CreditCardName { get; set; }

    /// <summary>
    /// CreditCardNumber.
    /// </summary>
    public string? CreditCardNumber { get; set; }

    /// <summary>
    /// CreditCardExpireYear.
    /// </summary>
    public int CreditCardExpireYear { get; set; }

    /// <summary>
    /// CreditCardExpireMonth.
    /// </summary>
    public int CreditCardExpireMonth { get; set; }

    /// <summary>
    /// CreditCardCvv2.
    /// </summary>
    public string? CreditCardCvv2 { get; set; }
    
    /// <summary>
    /// OrderPayment.
    /// </summary>
    public virtual OrderPayment? OrderPayment { get; set; }
}