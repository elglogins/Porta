using Microsoft.AspNetCore.Http;
using Porta.Interfaces.Repositories;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Porta.Middlewares
{
    public class PathRoutingMiddleware
    {
        private readonly RequestDelegate _next;

        // https://www.blinkingcaret.com/2017/09/13/create-your-own-asp-net-core-middleware/
        public PathRoutingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var lookupRoutesRepository = (ILookupRoutesRepository)context.RequestServices.GetService(typeof(ILookupRoutesRepository));
            var lookupRoutes = lookupRoutesRepository.GetAll();
            var matchingRouteConfiguration = lookupRoutes.FirstOrDefault(f => f.LookupRegex.IsMatch(context.Request.Path.Value));

            if (matchingRouteConfiguration == null)
                return;

            var matches = matchingRouteConfiguration.LookupRegex.Match(context.Request.Path.Value);
            for (int i=0; i<matches.Groups.Count; i++)
            {
                if (i == 0)
                    continue; // skip first, as it is overall match

                Group match = matches.Groups[i];
            }

            await _next(context);
        }

      
    }
}
