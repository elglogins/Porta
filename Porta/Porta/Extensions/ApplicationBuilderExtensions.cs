using Microsoft.AspNetCore.Builder;
using Porta.Middlewares;

namespace Porta.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UsePortaPathRouting(this IApplicationBuilder app)
        {
            return app.UseMiddleware<PathRoutingMiddleware>();
        }
    }
}
