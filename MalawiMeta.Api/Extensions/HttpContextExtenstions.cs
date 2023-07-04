using MalawiMeta.Api.Endpoints;
using MalawiMeta.Api.Exceptions;

namespace MalawiMeta.Api.Extensions;

public static class HttpContextExtenstions
{
    public static async Task<T> GetServiceOrThrowAsync<T>(this HttpContext context)
        where T : class
    {
        var service = context.RequestServices.GetService(typeof(T)) as T;
        if (service == null)
        {
            var response = context.Response;
            response.StatusCode = StatusCodes.Status500InternalServerError;
            var problemDetails = Responses.DefaultErrorResponse(context.Request.Path);
            await response.WriteAsJsonAsync(problemDetails);
            throw new DependencyNotFoundException();
        }

        return service;
    } 
}
