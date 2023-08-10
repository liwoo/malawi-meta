namespace MalawiMeta.Api.Domain.Shared.ValueObjects;

public record DistrictId(Guid Value) : ValueObject
{
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
