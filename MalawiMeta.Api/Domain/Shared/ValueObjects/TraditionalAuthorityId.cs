namespace MalawiMeta.Api.Domain.Shared.ValueObjects;

public record TraditionalAuthorityId(Guid Value) : ValueObject
{
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
