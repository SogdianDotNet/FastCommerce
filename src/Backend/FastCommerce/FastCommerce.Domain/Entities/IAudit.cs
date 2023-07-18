namespace FastCommerce.Domain.Entities;

public interface IAudit
{
    /// <summary>
    /// Id.
    /// </summary>
    Guid Id { get; set; }

    /// <summary>
    /// AccountId.
    /// </summary>
    Guid? AccountId { get; set; }

    /// <summary>
    /// CreatedUtc.
    /// </summary>
    DateTime CreatedUtc { get; set; }

    /// <summary>
    /// UpdatedUtc.
    /// </summary>
    DateTime UpdatedUtc { get; set; }

    /// <summary>
    /// Action.
    /// </summary>
    public AuditAction Action { get; set; }

    /// <summary>
    /// TableName.
    /// </summary>
    public string TableName { get; set; }

    /// <summary>
    /// OldValues.
    /// </summary>
    public string OldValues { get; set; }

    /// <summary>
    /// NewValues.
    /// </summary>
    public string NewValues { get; set; }

    /// <summary>
    /// AffectedColumns.
    /// </summary>
    public string AffectedColumns { get; set; }

    /// <summary>
    /// PrimaryKey.
    /// </summary>
    public string PrimaryKey { get; set; }
}
