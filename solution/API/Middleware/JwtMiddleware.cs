using LearningCenter.Domain;
using LearningCenter.Domain.Interfaces;

namespace LearningCenter.API.Middleware;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;

    public JwtMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    /// <summary>
    /// Autenticación
    /// </summary>
    /// <paramname="context"></param>
    /// <paramname="tokenDomain"></param>
    /// <paramname="userDomain"></param>
    public async Task Invoke(HttpContext context, ITokenDomain tokenDomain, IUserDomain userDomain)
    {
        //Autenticación

        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var username = tokenDomain.ValidateJwt(token);

        if (username != null)
        {
            context.Items["User"] = await userDomain.GetByUsername(username);
        }

        await _next(context);
    }
}