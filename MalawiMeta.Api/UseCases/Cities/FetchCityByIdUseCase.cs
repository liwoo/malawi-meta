using ErrorOr;
using MalawiMeta.Api.Domain.Services;
using MalawiMeta.Api.TransferObjects;

namespace MalawiMeta.Api.UseCases.Cities;

public record FetchCityByIdCaseArgs(string Id);

public interface IFetchCityByIdUseCase : IUseCase<FetchCityByIdCaseArgs, ErrorOr<CityResponseDto>>
{
}

public class FetchCityByIdUseCase : IFetchCityByIdUseCase
{
    private readonly ICityService _cityService;

    public FetchCityByIdUseCase(ICityService cityService)
    {
        _cityService = cityService;
    }

    public async Task<ErrorOr<CityResponseDto>> ExecuteAsync(FetchCityByIdCaseArgs? args)
    {
        var guidId = Guid.TryParse(args?.Id, out var guid) ? guid : Guid.Empty;
        if (guidId == Guid.Empty)
        {
            return Error.Validation(description: "ID is not a valid GUID", code: StatusCodes.Status400BadRequest.ToString());
        }

        var cityResult = await _cityService.GetCityByIdAsync(guidId);

        if(cityResult.IsError)
        {
            return cityResult.FirstError;
        }
        return new CityResponseDto(cityResult.Value.Name, cityResult.Value.DistrictId.ToString());
    }
}
