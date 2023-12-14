using ErrorOr;
using MalawiMeta.Api.Repositories;
using MalawiMeta.Api.TransferObjects;

namespace MalawiMeta.Api.UseCases.Districts;

public interface IFetchAllDistrictsUseCase : IUseCase<object, ErrorOr<IEnumerable<DistrictResponseDto>>>;

public class FetchAllDistrictsUseCase(IDistrictRepository districtRepository) : IFetchAllDistrictsUseCase
{
    public async Task<ErrorOr<IEnumerable<DistrictResponseDto>>> ExecuteAsync(object? args)
    {
        var districtResult = await districtRepository.GetDistrictsAsync();

        return districtResult.IsError switch
        {
            true => districtResult.FirstError,
            _ => districtResult.Value
                .Select(d => new DistrictResponseDto(d.Id, d.Name, d.Code, d.RegionId.Value.ToString()))
                .ToList()
        };
    }
}
