using System.ComponentModel.DataAnnotations.Schema;
using FastCommerce.Domain.Entities.Base;
using FastCommerce.Domain.Entities.Enums;

namespace FastCommerce.Domain.Entities;

public class OrderPayment : Entity
{
    public DateTime? PaidAtUtc { get; set; }

    public DateTime? CanceledAtUtc { get; set; }

    public DateTime? ExpiresAtUtc { get; set; }

    public DateTime? ExpiredAtUtc { get; set; }

    public DateTime? FailedAtUtc { get; set; }

    public DateTime? AuthorizedAtUtc { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? ApplicationFee { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? Amount { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? AmountCaptured { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? AmountRefunded { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? AmountRemaining { get; set; }

    public virtual Order? Order { get; set; }
}
