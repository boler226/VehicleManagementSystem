using Microsoft.AspNetCore.Mvc;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.API.Middlewares;
public sealed class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unhandled exception occured");

            context.Response.StatusCode = ex switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            await context.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Type = ex.GetType().Name,
                Title = "An error occured",
                Detail = ex.Message
            });
        }
    }
}
