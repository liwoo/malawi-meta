namespace MalawiMeta.Api.Domain.ValueObjects;

public record Geolocation(double Latitude, double Longitude) : ValueObject
{
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Latitude;
        yield return Longitude;
    }
}
