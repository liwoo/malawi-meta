using System.Collections;
using ErrorOr;
using MalawiMeta.Api.Domain.Services;
using MalawiMeta.Api.TransferObjects;

namespace MalawiMeta.Api.UseCases.Districts;


public interface IFetchAllDistrictsUseCase : IUseCase<object, ErrorOr<IEnumerable<DistrictResponseDto>>>
{
}

public class FetchAllDistrictsUseCase : IFetchAllDistrictsUseCase
{
    private readonly IDistrictService _districtService;

    public FetchAllDistrictsUseCase(IDistrictService districtService)
    {
        _districtService = districtService;
    }

    public async Task<ErrorOr<IEnumerable<DistrictResponseDto>>> ExecuteAsync(object? args)
    {
        var districtResult = await _districtService.GetDistrictsAsync();

        return districtResult.IsError switch
        {
            true => districtResult.FirstError,
            _ => districtResult.Value.Select(d => new DistrictResponseDto(d.Name, d.RegionId.ToString())).ToList()
        };
        
    }
}
