using Microsoft.AspNetCore.Mvc;

namespace MalawiMeta.Api.Endpoints;

public static class Responses
{
    public static ProblemDetails DefaultErrorResponse(string instance, string title = Title, string detail = Detail, int status = Status)
    {
        var problemDetails = new ProblemDetails
        {
            Title = title,
            Detail = detail,
            Status = status,
            Type = Type,
            Instance = instance
        };
        
        return problemDetails;
    }

    private const string Title = "Internal Server Error";
    private const string Detail = "The server encountered an internal error and was unable to complete your request.";
    private const string Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1";
    private const int Status = StatusCodes.Status500InternalServerError;
}