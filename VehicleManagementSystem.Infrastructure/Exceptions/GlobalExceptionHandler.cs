using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace VehicleManagementSystem.Infrastructure.Exceptions {
    public sealed class GlobalExceptionHandler(
        RequestDelegate next,
        ILogger<GlobalExceptionHandler> logger
        ) {
        public async Task InvokeAsync(HttpContext context) {
            try {
                await next(context);
            } catch ( Exception ex ) {
                logger.LogError(ex, "Unhandled exception occured");

                context.Response.StatusCode = ex switch {
                    NotFoundException => StatusCodes.Status404NotFound,
                    _ => StatusCodes.Status500InternalServerError
                };

                await context.Response.WriteAsJsonAsync(new ProblemDetails {
                    Type = ex.GetType().Name,
                    Title = "An error occured",
                    Detail = ex.Message
                });
            }
        }
    }
}
