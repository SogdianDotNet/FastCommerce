namespace FastCommerce.Domain.Entities.Orders;

public class GiftCard : Entity
{
    /// <summary>
    /// Gets or sets the amount
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// IsGiftCardActivated.
    /// </summary>
    public bool IsGiftCardActivated { get; set; }

    /// <summary>
    /// GiftCardCouponCode.
    /// </summary>
    public string? GiftCardCouponCode { get; set; }

    /// <summary>
    /// RecipientName.
    /// </summary>
    public string? RecipientName { get; set; }

    /// <summary>
    /// RecipientEmail.
    /// </summary>
    public string? RecipientEmail { get; set; }

    /// <summary>
    /// SenderName.
    /// </summary>
    public string? SenderName { get; set; }

    /// <summary>
    /// SenderEmail.
    /// </summary>
    public string? SenderEmail { get; set; }

    /// <summary>
    /// Message.
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// IsRecipientNotified.
    /// </summary>
    public bool IsRecipientNotified { get; set; }

    /// <summary>
    /// AppliedGiftCards.
    /// </summary>
    public virtual ICollection<AppliedGiftCard>? AppliedGiftCards { get; set; }
}
