using MalawiMeta.Api.TransferObjects;
using MalawiMeta.Api.UseCases.Districts;

namespace MalawiMeta.Api.Endpoints.Districts;

public static partial class DistrictEndpoints
{
    private static void MapAllDistrictsEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/",
                async (IFetchAllDistrictsUseCase fetchAllDistricts) =>
                {
                    var result = await fetchAllDistricts.ExecuteAsync(null);

                    return result switch {
                        {IsError: true} => Results.Problem(statusCode: StatusCodes.Status500InternalServerError,
                            detail: result.Errors.First().Description),
                        {Value: not null} => Results.Json(result.Value),
                        _ => Results.NotFound()
                    };
                })
            .Produces(StatusCodes.Status200OK, responseType: typeof(IEnumerable<DistrictResponseDto>))
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithName("GetDistricts");
    }
}
