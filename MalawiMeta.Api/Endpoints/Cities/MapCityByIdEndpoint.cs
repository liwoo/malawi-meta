using MalawiMeta.Api.Extensions;
using MalawiMeta.Api.TransferObjects;
using MalawiMeta.Api.UseCases.Cities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace MalawiMeta.Api.Endpoints.Cities;

public static partial class CityEndpoints
{
    private static void MapCityById(this IEndpointRouteBuilder app)
    {
        app.MapGet(
            "/{id}",
            [ProducesResponseType(typeof(CityResponseDto), StatusCodes.Status200OK)]
            [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
            [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
            async (HttpRequest request, HttpResponse response) =>
                {

                    var context = request.HttpContext;
                    var id = request.RouteValues["id"];
                    var path = context.Request.Path;

                    var fetchCityById = await context.GetServiceOrThrowAsync<IFetchCityByIdUseCase>();

                    var result = await fetchCityById.ExecuteAsync(new FetchCityByIdCaseArgs(id?.ToString() ?? string.Empty));

                    result.SwitchFirst(
                        city => response.WriteAsJsonAsync(city),
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
            .WithName("GetCityById")
            .WithDescription("Get a city by its id")
            .WithOpenApi(generatedOperation =>
            {
                generatedOperation.Parameters.Add(new OpenApiParameter
                {
                    Name = "id",
                    In = ParameterLocation.Path,
                    Required = true,
                    Description = "The id of the city to be retrieved"
                });

                return generatedOperation;
            });
    }
}
