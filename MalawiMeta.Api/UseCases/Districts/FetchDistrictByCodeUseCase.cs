using ErrorOr;
using MalawiMeta.Api.Repositories;
using MalawiMeta.Api.TransferObjects;

namespace MalawiMeta.Api.UseCases.Districts;

public record FetchDistrictByCodeUseCaseArgs(string code);

public interface IFetchDistrictByCodeUseCase : IUseCase<FetchDistrictByCodeUseCaseArgs, ErrorOr<DistrictResponseDto>>;

public class FetchDistrictByCodeUseCase(IDistrictRepository districtRepository) : IFetchDistrictByCodeUseCase
{
    public async Task<ErrorOr<DistrictResponseDto>> ExecuteAsync(FetchDistrictByCodeUseCaseArgs? args)
    {
        if (args?.code == null)
        {
            return Error.Validation();
        }

        var districtResult = await districtRepository.GetDistrictByCodeAsync(args.code);

        return districtResult.IsError switch
        {
            true => districtResult.FirstError,
            _ => new DistrictResponseDto(districtResult.Value.Id, districtResult.Value.Name, districtResult.Value.Code,
                districtResult.Value.RegionId.Value.ToString())
        };
    }
}
