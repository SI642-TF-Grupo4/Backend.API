using BackEnd.API.Security.Authorization.Handlers.Interfaces;
using BackEnd.API.Security.Authorization.Settings;
using BackEnd.API.Security.Domain.Services;

namespace BackEnd.API.Security.Authorization.Middleware;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly AppSettings _appSettings;

    public JwtMiddleware(RequestDelegate next, AppSettings appSettings)
    {
        _next = next;
        _appSettings = appSettings;
    }

    public async Task Invoke(HttpContext context, IUserService userService, IJwtHandler handler)
    {
        var token = context.Request.Headers["Authorization"]
            .FirstOrDefault()?
            .Split(" ")
            .Last();

        var userId = handler.ValidateToken(token);

        if (userId != null)
            context.Items["User"] = await userService.GetByIdAsync(userId.Value);

        await _next(context);

    }
}