using ErrorOr;
using MalawiMeta.Api.Domain.Services;
using MalawiMeta.Api.TransferObjects;

namespace MalawiMeta.Api.UseCases.Cities;

public interface IFetchAllCitiesUseCase : IUseCase<object, ErrorOr<IEnumerable<CityResponseDto>>>
{
}

public class FetchAllCitiesUseCase : IFetchAllCitiesUseCase
{
    private readonly ICityService _cityService;

    public FetchAllCitiesUseCase(ICityService cityService)
    {
        _cityService = cityService;
    }

    public async Task<ErrorOr<IEnumerable<CityResponseDto>>> ExecuteAsync(object? args)
    {
        var cityResult = await _cityService.GetCitiesAsync();

        if(cityResult.IsError)
        {
            return cityResult.FirstError;
        }
        return cityResult.Value.Select(d => new CityResponseDto(d.Name, d.DistrictId.ToString())).ToList();
    }
}
