using MalawiMeta.Api.Domain.Services;
using MalawiMeta.Api.TransferObjects;
using MalawiMeta.Api.UseCases.Districts;
using Microsoft.AspNetCore.Mvc;

namespace MalawiMeta.Api.Endpoints.Districts;

public static partial class DistrictEndpoints
{
    private static void MapAllDistricts(this IEndpointRouteBuilder app)
    {
        app.MapGet(
            "/",
            [ProducesResponseType(typeof(IEnumerable<DistrictResponseDto>), StatusCodes.Status200OK)] 
            [ProducesResponseType( typeof(ProblemDetails), StatusCodes.Status500InternalServerError)] 
            async (HttpRequest request, HttpResponse response) =>
        {
            var context = request.HttpContext;

            if (context.RequestServices.GetService(typeof(IFetchAllDistrictsUseCase)) is not IFetchAllDistrictsUseCase fetchAllDistricts)
            {
                 response.StatusCode = StatusCodes.Status500InternalServerError;
                 var problemDetails = Responses.DefaultErrorResponse(context.Request.Path);
                 await response.WriteAsJsonAsync(problemDetails);
                return;
            }
            
            var result = await fetchAllDistricts.ExecuteAsync(null);
    
            result.SwitchFirst(
                districts => response.WriteAsJsonAsync(districts),
                error => response.WriteAsJsonAsync(new {Message = error.Description})
            );
        }).WithName("GetDistricts");
    }
}
