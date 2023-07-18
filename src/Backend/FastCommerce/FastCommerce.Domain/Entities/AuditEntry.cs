namespace FastCommerce.Domain.Entities;

public class AuditEntry : IAudit
{
    public Guid Id { get; set; }
    public Guid? AccountId { get; set; }
    public DateTime CreatedUtc { get; set; }
    public DateTime UpdatedUtc { get; set; }
    public AuditAction Action { get; set; }
    public string? TableName { get; set; }
    public string? OldValues { get; set; }
    public string? NewValues { get; set; }
    public string? AffectedColumns { get; set; }
    public string? PrimaryKey { get; set; }
}
