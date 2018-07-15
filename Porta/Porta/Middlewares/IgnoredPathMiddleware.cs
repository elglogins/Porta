using Microsoft.AspNetCore.Http;
using Porta.Interfaces.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace Porta.Middlewares
{
    public class IgnoredPathMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IIgnoredRoutesRepository _routesRepository;

        public IgnoredPathMiddleware(RequestDelegate next, IIgnoredRoutesRepository routesRepository)
        {
            _next = next;
            _routesRepository = routesRepository;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Path.HasValue)
                return;

            if (_routesRepository.GetAll().Contains(context.Request.Path.Value))
                return;

            await _next(context);
        }
    }
}
