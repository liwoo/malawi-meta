namespace MalawiMeta.Api.Domain.Shared.ValueObjects;

public record Geolocation(double Latitude, double Longitude) : ValueObject
{
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Latitude;
        yield return Longitude;
    }
}
