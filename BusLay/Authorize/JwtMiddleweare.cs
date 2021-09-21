using BusLay.Interfaces;
using BusLay.Settings;
using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;

namespace BusLay.Authorize
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Setting _appSettings;
        private readonly ILogger<JwtMiddleware> logger;
        public JwtMiddleware(RequestDelegate next, IOptions<Setting> appSettings, ILogger<JwtMiddleware> logger)
        {
            this.logger = logger;
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, IUserService userService, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = jwtUtils.ValidateJwtToken(token);
            if (userId != null)
            {
                // attach user to context on successful jwt validation
                context.Items["User"] = userService.GetById(userId.Value);
            }

            await _next(context);
        }
    }
}