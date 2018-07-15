using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Porta.Middlewares
{
    public class CachedRoutingResultMiddleware
    {
        private readonly RequestDelegate _next;
        public CachedRoutingResultMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);
        }
    }
}
