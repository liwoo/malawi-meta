using MalawiMeta.Api.Domain.ValueObjects;

namespace MalawiMeta.Api.Domain.Aggregates;

public sealed class District : AuditedAggregateRoot<Guid>
{
    public string Name { get; private set; }
    public string Code { get; private set; }
    public Guid RegionId { get; private set; }
    public List<Guid> TraditionalAuthorityIds { get; private set; }
    public List<Guid> CityIds { get; private set; }
    public List<Guid> ConstituencyIds { get; private set; } 
    public Population Population { get; private set; }
    public Geolocation Geolocation { get; private set; }
    
    private District(Guid id, string name, string code, Guid regionId) : base(id)
    {
        Name = name;
        RegionId = regionId;
        Code = code;
        Population = new Population(0, 0, 0);
        Geolocation = new Geolocation(0.0, 0.0);
        TraditionalAuthorityIds = new List<Guid>();
        CityIds = new List<Guid>();
        ConstituencyIds = new List<Guid>();
    }
    
    public static District Create(string name, string code, Guid regionId)
    {
        return new District(Guid.NewGuid(), name, code, regionId);
    }
}

