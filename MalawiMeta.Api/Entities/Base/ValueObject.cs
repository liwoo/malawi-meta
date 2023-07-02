namespace MalawiMeta.Api.Entities.Base;

public abstract record ValueObject
{
    protected abstract IEnumerable<object> GetEqualityComponents();
    
    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Aggregate(1, (current, obj) =>
            {
                unchecked
                {
                    return current * 23 + (obj?.GetHashCode() ?? 0);
                }
            });
    }
}