using ErrorOr;
using MalawiMeta.Api.Repositories;
using MalawiMeta.Api.TransferObjects;

namespace MalawiMeta.Api.Domain.Services;

public interface IDistrictService
{
    public Task<ErrorOr<IEnumerable<DistrictResponseDto>>> GetDistrictsAsync();
    public Task<ErrorOr<DistrictResponseDto>> GetDistrictByIdAsync(string? id);
}

public class DistrictService : IDistrictService
{
    private readonly IDistrictRepository _districtRepository;

    public DistrictService(IDistrictRepository districtRepository)
    {
        _districtRepository = districtRepository;
    }

    public async Task<ErrorOr<IEnumerable<DistrictResponseDto>>> GetDistrictsAsync()
    {
        var districtResult = await _districtRepository.GetDistrictsAsync();

        return districtResult.IsError switch
        {
            true => districtResult.FirstError,
            _ => districtResult.Value.Select(d => new DistrictResponseDto(d.Name, d.Region.ToString())).ToList()
        };
    }

    public async Task<ErrorOr<DistrictResponseDto>> GetDistrictByIdAsync(string? id)
    {
        var guuidId = Guid.TryParse(id, out var guuid) ? guuid : Guid.Empty;
        if (guuidId == Guid.Empty)
        {
            return Error.Validation(description: "ID is not a valid GUID", code: StatusCodes.Status400BadRequest.ToString());
        }
        
        var districtResult = await _districtRepository.GetDistrictByIdAsync(guuidId);
        
        return districtResult.IsError switch
        {
            true => districtResult.FirstError,
            _ => new DistrictResponseDto(districtResult.Value.Name, districtResult.Value.Region.ToString())
        };
    }
}
