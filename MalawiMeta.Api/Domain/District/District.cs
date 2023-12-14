using MalawiMeta.Api.Domain.Shared.ValueObjects;

namespace MalawiMeta.Api.Domain.District;

public sealed class District : AuditedAggregateRoot<Guid>
{
    public string Name { get; private set; }
    public string Code { get; private set; }
    public RegionId RegionId { get; private set; }
    public List<TraditionalAuthorityId> TraditionalAuthorityIds { get; private set; }
    public List<CityId> CityIds { get; private set; }
    public List<ConstituencyId> ConstituencyIds { get; private set; } 
    public Population Population { get; private set; }
    public Geolocation Geolocation { get; private set; }
    
    private District(Guid id, string name, string code, RegionId regionId) : base(id)
    {
        Name = name;
        RegionId = regionId;
        Code = code;
        Population = new Population(0, 0, 0);
        Geolocation = new Geolocation(0.0, 0.0);
        TraditionalAuthorityIds = new List<TraditionalAuthorityId>();
        CityIds = new List<CityId>();
        ConstituencyIds = new List<ConstituencyId>();
    }
    
    public static District Create(Guid id, string name, string code, RegionId regionId)
    {
        return new District(id, name, code, regionId);
    }
}

