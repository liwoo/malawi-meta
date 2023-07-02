using MalawiMeta.Api.Entities.Base;

namespace MalawiMeta.Api.Entities;


public sealed record TaContact(string PhoneNumber, string EmailAddress) : ValueObject
{
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return PhoneNumber;
        yield return EmailAddress;
    }
}


public sealed class TraditionalAuthority : AuditedEntity<Guid>
{
    public string Name { get; private set; }
    public TaContact Contact { get; private set; }
    public string DistrictId { get; private set; }
    
    private TraditionalAuthority(Guid id, string name, TaContact contact, string districtId) : base(id)
    {
        Name = name;
        Contact = contact;
        DistrictId = districtId;
    }
    
    public static TraditionalAuthority Create(string name, TaContact contact, string districtId)
    {
        return new TraditionalAuthority(Guid.NewGuid(), name, contact, districtId);
    }
}