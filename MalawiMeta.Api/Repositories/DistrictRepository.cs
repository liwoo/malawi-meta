using ErrorOr;
using MalawiMeta.Api.Domain.District;
using MalawiMeta.Api.Domain.Shared.ValueObjects;

namespace MalawiMeta.Api.Repositories;

public interface IDistrictRepository
{
    public Task<ErrorOr<IEnumerable<District>>> GetDistrictsAsync();
    public Task<ErrorOr<District>> GetDistrictByIdAsync(Guid id);
}

public class InMemoryDistrictRepository : IDistrictRepository
{
    private readonly IEnumerable<District> _districts;

    public InMemoryDistrictRepository()
    {
        IEnumerable<District> initialDistrict = new[]
        {
            District.Create(Guid.Parse("6bac69be-b292-415c-af81-4549fa99cfcb"),  "Blantyre", "BT", new RegionId(Guid.NewGuid())),
            District.Create(Guid.Parse("c3fdfa83-8c18-413e-bc4e-9fc4d0b1f58e"),"Chikwawa", "CK", new RegionId(Guid.NewGuid())),
            District.Create(Guid.Parse("39677429-fef1-49e3-bf6c-a642071ed6da"), "Chiradzulu", "CZ", new RegionId(Guid.NewGuid())),
            District.Create(Guid.Parse("5dc1fc15-014c-4be9-ba04-4a5f83a9039c"), "Machinga", "MCH", new RegionId(Guid.NewGuid())),
            //few from the central region
            District.Create(Guid.Parse("7a103a06-74c1-4c1a-b50a-5cf71dd3d510"), "Dedza", "DZ",new RegionId(Guid.NewGuid())),
            District.Create(Guid.Parse("ca3bb6db-8f31-439a-a9fd-380a9f5c3287"),"Dowa", "DA", new RegionId(Guid.NewGuid())),
            District.Create(Guid.Parse("2a50c886-cea2-4c73-8ea6-264b5ee157a7"),"Kasungu", "KU",new RegionId(Guid.NewGuid())),
            District.Create(Guid.Parse("603f16c3-0eed-4de1-bf3f-074e04e05033"), "Lilongwe", "LL",new RegionId(Guid.NewGuid())),
            //few from the northern region
            District.Create(Guid.Parse("2b0f1e85-abba-4715-a935-88c3beac32f2"), "Chitipa", "CP", new RegionId(Guid.NewGuid())),
            District.Create(Guid.Parse("ca35c476-7c88-4c7f-a397-1e2ede30c1a4"), "Karonga", "KA",new RegionId(Guid.NewGuid())),
            District.Create(Guid.Parse("0a8d99ac-e161-459e-a719-76992b72e8c2"),"Likoma", "LK",new RegionId(Guid.NewGuid()))
        };
        _districts = initialDistrict;
    }

    public Task<ErrorOr<IEnumerable<District>>> GetDistrictsAsync()
    {
        return Task.FromResult(ErrorOrFactory.From(_districts));
    }

    public Task<ErrorOr<District>> GetDistrictByIdAsync(Guid id)
    {
        var district = _districts.FirstOrDefault(d => d.Id == id);

        return district switch
        {
            null => Task.FromResult<ErrorOr<District>>(Error.NotFound()),
            _ => Task.FromResult<ErrorOr<District>>(district)
        };
    }
}
