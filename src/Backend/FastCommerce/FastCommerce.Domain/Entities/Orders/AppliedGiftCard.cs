namespace FastCommerce.Domain.Entities.Orders;

public class AppliedGiftCard : Entity
{
    /// <summary>
    /// AmountUsed.
    /// </summary>
    public decimal AmountUsed { get; set; }

    /// <summary>
    /// GiftCard.
    /// </summary>
    public virtual GiftCard? GiftCard { get; set; }
}
