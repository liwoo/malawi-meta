namespace MalawiMeta.Api.Domain;

public abstract class AuditedAggregateRoot<TPrimaryKey> : AuditedEntity<TPrimaryKey>
{
    protected AuditedAggregateRoot(TPrimaryKey id) : base(id)
    {
    }
}
