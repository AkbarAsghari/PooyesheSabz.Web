using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;

namespace PooyesheSabz.Web.Middlewares
{
    public class BlazorAuthorizationMiddlewareResultHandler : IAuthorizationMiddlewareResultHandler
    {
        public Task HandleAsync(RequestDelegate next, HttpContext context, AuthorizationPolicy policy, PolicyAuthorizationResult authorizeResult)
        {
            return next(context);
        }
    }
}
