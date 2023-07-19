using MalawiMeta.Api.Domain.ValueObjects;

namespace MalawiMeta.Api.Domain.Aggregates;

public sealed class City : AuditedAggregateRoot<Guid>
{
    public string Name { get; private set; }
    public Guid DistrictId { get; private set; }
    public List<Guid> LocationIds { get; private set; }
    public Geolocation Geolocation { get; private set; }
    public Population Population { get; private set; }

    private City(Guid id, string name, Guid districtId) : base(id)
    {
        Name = name;
        DistrictId = districtId;
        Population = new Population(0, 0, 0);
        Geolocation = new Geolocation(0.0, 0.0);
        LocationIds = new List<Guid>();
    }
    
    public static City Create(string name, Guid districtId)
    {
        City city = new City(Guid.NewGuid(), name, districtId);
        return city;
    }
}


