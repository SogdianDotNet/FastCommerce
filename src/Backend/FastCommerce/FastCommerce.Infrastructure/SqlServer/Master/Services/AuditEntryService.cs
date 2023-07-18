using System.Security.Claims;
using FastCommerce.Application.Attributes;
using FastCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace FastCommerce.Infrastructure.SqlServer.Master.Services;

internal class AuditEntryService : IAuditEntryService
{
    private readonly ClaimsPrincipal _currentUser;

    public AuditEntryService(ClaimsPrincipal currentUser)
    {
        _currentUser = currentUser;
    }

    public ICollection<AuditEntry> Create(ICollection<EntityEntry> entityEntry)
    {
        List<AuditEntry> list = new List<AuditEntry>();
        foreach (EntityEntry item in entityEntry)
        {
            if (!item.Entity.GetType().IsAuditDisabled() && item.State != 0 && item.State != EntityState.Unchanged)
            {
                AuditEntry auditEntry = new AuditEntry
                {
                    TableName = item.Entity.GetType().Name,
                    AccountId = GetUserId()
                };
                SetAuditValues(item, auditEntry);
                list.Add(auditEntry);
            }
        }

        return list;
    }

    private static void SetAuditValues(EntityEntry entry, AuditEntry auditEntry)
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
        Dictionary<string, string> dictionary3 = new Dictionary<string, string>();
        List<string> list = new List<string>();
        foreach (PropertyEntry property in entry.Properties)
        {
            string name = property.Metadata.Name;
            if (property.Metadata.IsPrimaryKey())
            {
                dictionary[name] = property.CurrentValue?.ToString();
                continue;
            }

            switch (entry.State)
            {
                case EntityState.Added:
                    auditEntry.Action = AuditAction.Create;
                    dictionary3[name] = property.CurrentValue?.ToString();
                    break;
                case EntityState.Deleted:
                    auditEntry.Action = AuditAction.Delete;
                    dictionary2[name] = property.OriginalValue?.ToString();
                    break;
                case EntityState.Modified:
                    if (property.IsModified)
                    {
                        list.Add(name);
                        auditEntry.Action = AuditAction.Update;
                        dictionary2[name] = property.OriginalValue?.ToString();
                        dictionary3[name] = property.CurrentValue?.ToString();
                    }

                    break;
            }
        }

        auditEntry.PrimaryKey = JsonConvert.SerializeObject(dictionary);
        auditEntry.OldValues = ((dictionary2.Count == 0) ? null : JsonConvert.SerializeObject(dictionary2));
        auditEntry.NewValues = ((dictionary3.Count == 0) ? null : JsonConvert.SerializeObject(dictionary3));
        auditEntry.AffectedColumns = ((list.Count == 0) ? null : JsonConvert.SerializeObject(list));
    }

    private Guid? GetUserId()
    {
        Guid guid;

        if (!Guid.TryParse(_currentUser.FindFirst("id")?.Value, out guid))
        {
            return Guid.Empty;
        }

        return guid == Guid.Empty ? null : guid;
    }
}
