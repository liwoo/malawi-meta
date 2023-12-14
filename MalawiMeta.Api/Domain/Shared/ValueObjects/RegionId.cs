namespace MalawiMeta.Api.Domain.Shared.ValueObjects;

public record RegionId(Guid Value) : ValueObject
{
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
