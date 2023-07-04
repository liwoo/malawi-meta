namespace MalawiMeta.Api.Domain;

public abstract class Entity<TPrimaryKey>
{
    public TPrimaryKey Id { get; private set; }
    
    protected Entity(TPrimaryKey id)
    {
        Id = id;
    }
}
