using MalawiMeta.Api.Domain.Shared.ValueObjects;

namespace MalawiMeta.Api.Domain.Region;

public sealed class Region : AuditedAggregateRoot<Guid>
{
    public string Name { get; private set; }
    public List<DistrictId> DistrictIds { get; private set; }
    public Population Population { get; private set; }
    
    private Region(Guid id, string name) : base(id)
    {
        Name = name;
        DistrictIds = new List<DistrictId>();
        Population = new Population(0, 0, 0);
    }
    
    public static Region Create(string name)
    {
        return new Region(Guid.NewGuid(), name);
    }
}
