using System.ComponentModel.DataAnnotations.Schema;

namespace FastCommerce.Domain.Entities.Orders;

public class OrderPayment : Entity
{
    /// <summary>
    /// PaidAtUtc.
    /// </summary>
    public DateTime? PaidAtUtc { get; set; }

    /// <summary>
    /// CanceledAtUtc.
    /// </summary>
    public DateTime? CanceledAtUtc { get; set; }

    /// <summary>
    /// ExpiresAtUtc.
    /// </summary>
    public DateTime? ExpiresAtUtc { get; set; }

    /// <summary>
    /// ExpiredAtUtc.
    /// </summary>
    public DateTime? ExpiredAtUtc { get; set; }

    /// <summary>
    /// FailedAtUtc.
    /// </summary>
    public DateTime? FailedAtUtc { get; set; }

    /// <summary>
    /// AuthorizedAtUtc.
    /// </summary>
    public DateTime? AuthorizedAtUtc { get; set; }

    /// <summary>
    /// ApplicationFee.
    /// </summary>
    [Column(TypeName = "decimal(18,2)")]
    public decimal? ApplicationFee { get; set; }

    /// <summary>
    /// Amount.
    /// </summary>
    [Column(TypeName = "decimal(18,2)")]
    public decimal? Amount { get; set; }
    
    /// <summary>
    /// AmountCaptured.
    /// </summary>
    [Column(TypeName = "decimal(18,2)")]
    public decimal? AmountCaptured { get; set; }
    
    /// <summary>
    /// AmountRefunded.
    /// </summary>
    [Column(TypeName = "decimal(18,2)")]
    public decimal? AmountRefunded { get; set; }

    /// <summary>
    /// AmountRemaining.
    /// </summary>
    [Column(TypeName = "decimal(18,2)")]
    public decimal? AmountRemaining { get; set; }

    /// <summary>
    /// Order.
    /// </summary>
    public virtual Order? Order { get; set; }
    
    /// <summary>
    /// PaymentDetails.
    /// </summary>
    public virtual PaymentDetails? PaymentDetails { get; set; }
}
