namespace MalawiMeta.Api.Domain.ValueObjects;

public sealed record Population(long Male, long Female, long Total) : ValueObject
{
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Male;
        yield return Female;
        yield return Total;
    }
}
