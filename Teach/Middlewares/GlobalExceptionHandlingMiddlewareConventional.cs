using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Teach.Middlewares;

public class GlobalExceptionHandlingMiddlewareConventional
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandlingMiddlewareConventional> _logger;

    public GlobalExceptionHandlingMiddlewareConventional(RequestDelegate next, ILogger<GlobalExceptionHandlingMiddlewareConventional> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            ProblemDetails problem = new ProblemDetails
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Type = "Server Error",
                Title = "Server Error",
                Detail = "An internal server error has occurred"
            };

            await context.Response.WriteAsJsonAsync(problem);
        }

        if (context.Response.StatusCode == (int)HttpStatusCode.NotFound)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            ProblemDetails problem = new ProblemDetails
            {
                Status = (int)HttpStatusCode.NotFound,
                Type = "Not Found",
                Title = "Resource Not Found",
                Detail = "The requested resource was not found."
            };
            await context.Response.WriteAsJsonAsync(problem);
        }

        if (context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            ProblemDetails problem = new ProblemDetails
            {
                Status = (int)HttpStatusCode.Unauthorized,
                Type = "Unauthorized",
                Title = "Unauthorized Access",
                Detail = "You are not authorized to access this resource."
            };
            await context.Response.WriteAsJsonAsync(problem);
        }

        if (context.Response.StatusCode == (int)HttpStatusCode.Forbidden)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            ProblemDetails problem = new ProblemDetails
            {
                Status = (int)HttpStatusCode.Forbidden,
                Type = "Forbidden",
                Title = "Access Forbidden",
                Detail = "Access to this resource is forbidden."
            };
            await context.Response.WriteAsJsonAsync(problem);
        }

        if (context.Response.StatusCode == (int)HttpStatusCode.BadRequest)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            ProblemDetails problem = new ProblemDetails
            {
                Status = (int)HttpStatusCode.BadRequest,
                Type = "Bad Request",
                Title = "Bad Request",
                Detail = "The request was malformed or invalid."
            };
            await context.Response.WriteAsJsonAsync(problem);
        }
    }
}