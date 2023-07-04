using MalawiMeta.Api.Domain.ValueObjects;

namespace MalawiMeta.Api.Domain.Entities;

public sealed class Region : AuditedEntity<Guid>
{
    public string Name { get; private set; }
    public List<Guid> DistrictIds { get; private set; }
    public Population Population { get; private set; }
    
    private Region(Guid id, string name) : base(id)
    {
        Name = name;
        DistrictIds = new List<Guid>();
        Population = new Population(0, 0, 0);
    }
    
    public static Region Create(string name)
    {
        return new Region(Guid.NewGuid(), name);
    }
}
