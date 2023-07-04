using ErrorOr;
using MalawiMeta.Api.Domain.Aggregates;
using MalawiMeta.Api.Domain.Entities;
using MalawiMeta.Api.TransferObjects;

namespace MalawiMeta.Api.Domain.Services;

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
            District.Create("Blantyre", "BT", Guid.NewGuid()),
            District.Create("Chikwawa", "CK", Guid.NewGuid()),
            District.Create("Chiradzulu", "CZ", Guid.NewGuid()),
            District.Create("Machinga", "MCH", Guid.NewGuid()),
            //few from the central region
            District.Create("Dedza", "DZ",Guid.NewGuid()),
            District.Create("Dowa", "DA", Guid.NewGuid()),
            District.Create("Kasungu", "KU",Guid.NewGuid()),
            District.Create("Lilongwe", "LL",Guid.NewGuid()),
            //few from the northern region
            District.Create("Chitipa", "CP", Guid.NewGuid()),
            District.Create("Karonga", "KA",Guid.NewGuid()),
            District.Create("Likoma", "LK",Guid.NewGuid())
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
