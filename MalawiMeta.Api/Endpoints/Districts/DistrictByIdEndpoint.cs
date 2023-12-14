using ErrorOr;
using MalawiMeta.Api.TransferObjects;
using MalawiMeta.Api.UseCases.Districts;

namespace MalawiMeta.Api.Endpoints.Districts;

public static partial class DistrictEndpoints
{
    private static void MapDistrictByIdEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/{id:guid}",
                async (Guid id, IFetchDistrictByIdUseCase fetchDistrictById) =>
                {
                    var useCaseResult = await fetchDistrictById.ExecuteAsync(new FetchDistrictByIdCaseArgs(id));

                    return useCaseResult switch
                    {
                        {IsError: true} => useCaseResult.Errors.First() switch
                        {
                            {Type: ErrorType.Validation} => Results.Problem(statusCode: StatusCodes.Status400BadRequest,
                                detail: useCaseResult.Errors.First().Description),
                            {Type: ErrorType.NotFound} => Results.Problem(statusCode: StatusCodes.Status404NotFound,
                                detail: useCaseResult.Errors.First().Description),
                            _ => Results.Problem(statusCode: StatusCodes.Status500InternalServerError,
                                detail: useCaseResult.Errors.First().Description)
                        },
                        {Value: not null} => Results.Json(useCaseResult.Value),
                        _ => Results.NotFound()
                    };
                })
            .WithName("GetDistrictById")
            .WithDescription("Get a district by its id")
            .Produces(StatusCodes.Status200OK, responseType: typeof(DistrictResponseDto))
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}
