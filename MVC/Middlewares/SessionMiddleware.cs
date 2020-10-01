
using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace hospital.Middlewares
{
    public class SessionMiddleware
    {
        private readonly RequestDelegate _next;

        public SessionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            if ((httpContext.Session.GetString("role") == "user" || httpContext.Session.GetString("role") == "role") ||
                httpContext.Request.Path.Value.Contains("/account/"))
            {
                await _next.Invoke(httpContext);
            }
            else
            {
                httpContext.Response.StatusCode = 401;
                return;
            }
        }
    }

    public static class SessionMiddlewareExtensions
    {
        public static IApplicationBuilder UseSessionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SessionMiddleware>();
        }
    }
}