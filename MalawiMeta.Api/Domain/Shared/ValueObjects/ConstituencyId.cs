namespace MalawiMeta.Api.Domain.Shared.ValueObjects;

public record ConstituencyId(Guid Value) : ValueObject
{
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
