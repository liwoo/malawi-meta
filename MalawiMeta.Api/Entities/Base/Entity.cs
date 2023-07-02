namespace MalawiMeta.Api.Entities.Base;

public abstract class Entity<TPrimaryKey>
{
    public TPrimaryKey Id { get; private set; }
    
    protected Entity(TPrimaryKey id)
    {
        Id = id;
    }
}