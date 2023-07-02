using MalawiMeta.Api.Services;
using MalawiMeta.Api.TransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace MalawiMeta.Api.Endpoints.Districts;

public static partial class DistrictEndpoints
{
    public static void MapAllDistricts(this WebApplication app)
    {
        app.MapGet(
            "/districts",
            [ProducesResponseType(typeof(IEnumerable<DistrictResponseDto>), StatusCodes.Status200OK)] 
            [ProducesResponseType( typeof(ProblemDetails), StatusCodes.Status500InternalServerError)] 
            async (HttpRequest request, HttpResponse response) =>
        {
            var context = request.HttpContext;

            if (context.RequestServices.GetService(typeof(IDistrictService)) is not IDistrictService districtService)
            {
                 response.StatusCode = StatusCodes.Status500InternalServerError;
                 var problemDetails = Responses.DefaultErrorResponse(context.Request.Path);
                 await response.WriteAsJsonAsync(problemDetails);
                return;
            }
            
            var result = await districtService.GetDistrictsAsync();
    
            result.SwitchFirst(
                districts => response.WriteAsJsonAsync(districts),
                error => response.WriteAsJsonAsync(new {Message = error.Description})
            );
        }).WithName("GetDistricts");
    }
}
