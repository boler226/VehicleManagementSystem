using System.Security.Claims;

namespace VehicleManagementSystem.API.Middlewares;

public class RoleHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (!context.User.Identity?.IsAuthenticated ?? true)
        {
            var identity = new ClaimsIdentity();
            identity.AddClaim(new Claim(ClaimTypes.Role, "Guest"));
            context.User = new ClaimsPrincipal(identity);
        }

        await next(context);
    }
}