using MalawiMeta.Api.Entities.Base;

namespace MalawiMeta.Api.Entities;

public enum Region
{
    Central,
    Northern,
    Southern
}

public sealed class District : AuditedEntity<Guid>
{
    public string Name { get; private set; }
    public Region Region { get; private set; }
    
    private District(Guid id, string name, Region region) : base(id)
    {
        Name = name;
        Region = region;
    }
    
    public static District Create(string name, Region region)
    {
        return new District(Guid.NewGuid(), name, region);
    }
}

