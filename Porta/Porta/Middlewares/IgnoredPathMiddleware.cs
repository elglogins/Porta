using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Porta.Middlewares
{
    public class IgnoredPathMiddleware
    {
        private readonly RequestDelegate _next;
        public IgnoredPathMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);
        }
    }
}
