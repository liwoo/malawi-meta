using ErrorOr;
using MalawiMeta.Api.Repositories;
using MalawiMeta.Api.TransferObjects;

namespace MalawiMeta.Api.UseCases.Districts;

public record FetchDistrictByIdCaseArgs(Guid Id);

public interface IFetchDistrictByIdUseCase : IUseCase<FetchDistrictByIdCaseArgs, ErrorOr<DistrictResponseDto>>;

public class FetchDistrictByIdUseCase(IDistrictRepository districtRepository) : IFetchDistrictByIdUseCase
{
    public async Task<ErrorOr<DistrictResponseDto>> ExecuteAsync(FetchDistrictByIdCaseArgs? args)
    {
        var id = args?.Id;
        if (id == null)
        {
            return Error.Validation();
        }

        var districtResult = await districtRepository.GetDistrictByIdAsync(id.Value);

        return districtResult.IsError switch
        {
            true => districtResult.FirstError,
            _ => new DistrictResponseDto(districtResult.Value.Id, districtResult.Value.Name, districtResult.Value.Code,
                districtResult.Value.RegionId.Value.ToString())
        };
    }
}
