using MalawiMeta.Api.Domain.Services;
using MalawiMeta.Api.Extensions;
using MalawiMeta.Api.TransferObjects;
using MalawiMeta.Api.UseCases.Districts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace MalawiMeta.Api.Endpoints.Districts;

public static partial class DistrictEndpoints
{
    private static void MapDistrictById(this IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/{id}",
                [ProducesResponseType(typeof(DistrictResponseDto), StatusCodes.Status200OK)]
                [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
                [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
                async (HttpRequest request, HttpResponse response) =>
                {
                    
                    var context = request.HttpContext;
                    var id = request.RouteValues["id"];
                    var path = context.Request.Path;

                    var fetchDistrictById = await context.GetServiceOrThrowAsync<IFetchDistrictByIdUseCase>();
                    
                    var result = await fetchDistrictById.ExecuteAsync(new FetchDistrictByIdCaseArgs(id?.ToString() ?? string.Empty));

                    result.SwitchFirst(
                        district => response.WriteAsJsonAsync(district),
                        error =>
                        {
                            var code = int.TryParse(error.Code, out var parsedCode)
                                ? parsedCode
                                : StatusCodes.Status500InternalServerError;
                            response.StatusCode = code;
                            response.WriteAsJsonAsync(Responses.DefaultErrorResponse(path, error.Type.ToString(),
                                error.Description, code));
                        }
                    );

                })
            .WithName("GetDistrictById")
            .WithDescription("Get a district by its id")
            .WithOpenApi(generatedOperation =>
            {
                generatedOperation.Parameters.Add(new OpenApiParameter
                {
                     Name = "id",
                     In = ParameterLocation.Path,
                     Required = true,
                     Description = "The id of the district to retrieve"
                });
                
                return generatedOperation;
            });
    }
}
