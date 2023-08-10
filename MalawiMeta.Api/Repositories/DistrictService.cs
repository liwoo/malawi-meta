using ErrorOr;
using MalawiMeta.Api.Domain.District;
using MalawiMeta.Api.Domain.Shared.ValueObjects;

namespace MalawiMeta.Api.Repositories;

public interface IDistrictService
{
    public Task<ErrorOr<IEnumerable<District>>> GetDistrictsAsync();
    public Task<ErrorOr<District>> GetDistrictByIdAsync(Guid id);
}

public class InMemoryDistrictService : IDistrictService
{
    private readonly IEnumerable<District> _districts;

    public InMemoryDistrictService()
    {
        IEnumerable<District> initialDistrict = new[]
        {
            District.Create("Blantyre", "BT", new RegionId(Guid.NewGuid())),
            District.Create("Chikwawa", "CK", new RegionId(Guid.NewGuid())),
            District.Create("Chiradzulu", "CZ", new RegionId(Guid.NewGuid())),
            District.Create("Machinga", "MCH", new RegionId(Guid.NewGuid())),
            //few from the central region
            District.Create("Dedza", "DZ",new RegionId(Guid.NewGuid())),
            District.Create("Dowa", "DA", new RegionId(Guid.NewGuid())),
            District.Create("Kasungu", "KU",new RegionId(Guid.NewGuid())),
            District.Create("Lilongwe", "LL",new RegionId(Guid.NewGuid())),
            //few from the northern region
            District.Create("Chitipa", "CP", new RegionId(Guid.NewGuid())),
            District.Create("Karonga", "KA",new RegionId(Guid.NewGuid())),
            District.Create("Likoma", "LK",new RegionId(Guid.NewGuid()))
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
            null => Task.FromResult<ErrorOr<District>>(Error.NotFound(StatusCodes.Status404NotFound.ToString(), 
                "District not found")),
            _ => Task.FromResult<ErrorOr<District>>(district)
        };
    }
}
