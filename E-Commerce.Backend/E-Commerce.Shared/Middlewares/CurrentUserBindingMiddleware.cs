using E_Commerce.Shared.Services.Interfaces;
using E_Commerce.Shared.Services.Interfaces.JwtService;
using Microsoft.AspNetCore.Http;

namespace E_Commerce.Shared.Middlewares
{
    public sealed class CurrentUserBindingMiddleware
    {
        private readonly RequestDelegate _next;
        public CurrentUserBindingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ICurrentUserService currentUserService, IJwtValidator jwtValidator)
        {
            var tokenSplit = context?.Request?.Headers["Authorization"].ToString().Split(" ");
            if (tokenSplit.Length > 1)
            {
                var token = tokenSplit[1];
                if (jwtValidator.IsValid(token))
                {
                    currentUserService.SetCurrentUser(token);
                }
            }
            await _next(context);
        }
    }
}
