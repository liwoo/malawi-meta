using ErrorOr;
using MalawiMeta.Api.Repositories;
using MalawiMeta.Api.TransferObjects;

namespace MalawiMeta.Api.UseCases.Districts;

public record FetchDistrictByIdCaseArgs(string Id);

public interface IFetchDistrictByIdUseCase : IUseCase<FetchDistrictByIdCaseArgs, ErrorOr<DistrictResponseDto>>
{
}


public class FetchDistrictByIdUseCase : IFetchDistrictByIdUseCase
{
    private readonly IDistrictRepository _districtRepository;

    public FetchDistrictByIdUseCase(IDistrictRepository districtRepository)
    {
        _districtRepository = districtRepository;
    }

    public async Task<ErrorOr<DistrictResponseDto>> ExecuteAsync(FetchDistrictByIdCaseArgs? args)
    {
        var guuidId = Guid.TryParse(args?.Id, out var guuid) ? guuid : Guid.Empty;
        if (guuidId == Guid.Empty)
        {
            return Error.Validation(description: "ID is not a valid GUID", code: StatusCodes.Status400BadRequest.ToString());
        }
        
        var districtResult = await _districtRepository.GetDistrictByIdAsync(guuidId);
        
        return districtResult.IsError switch
        {
            true => districtResult.FirstError,
            _ => new DistrictResponseDto(districtResult.Value.Name, districtResult.Value.Code, districtResult.Value.RegionId.ToString())
        };
    }
}
