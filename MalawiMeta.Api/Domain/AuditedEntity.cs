namespace MalawiMeta.Api.Domain;

public abstract class AuditedEntity<TPrimaryKey> : Entity<TPrimaryKey>
{
    public DateTimeOffset CreatedAt { get; private set; }
    public DateTimeOffset? UpdatedAt { get; private set; }
    
    public void UpdateAudit()
    {
        UpdatedAt = DateTimeOffset.UtcNow;
    }

    protected AuditedEntity(TPrimaryKey id) : base(id)
    {
        CreatedAt = DateTimeOffset.UtcNow;
        UpdatedAt = DateTimeOffset.UtcNow;
    }
}
