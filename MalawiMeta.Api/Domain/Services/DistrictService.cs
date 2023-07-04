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
            District.Create("Blantyre", Region.Southern),
            District.Create("Chikwawa", Region.Southern),
            District.Create("Chiradzulu", Region.Southern),
            District.Create("Machinga", Region.Southern),
            //few from the central region
            District.Create("Dedza", Region.Central),
            District.Create("Dowa", Region.Central),
            District.Create("Kasungu", Region.Central),
            District.Create("Lilongwe", Region.Central),
            //few from the northern region
            District.Create("Chitipa", Region.Northern),
            District.Create("Karonga", Region.Northern),
            District.Create("Likoma", Region.Northern),
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
