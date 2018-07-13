using Porta.Extensions;
using Porta.Interfaces.Models;
using Porta.Interfaces.Repositories;
using Porta.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Porta.Repositories
{
    public class LookupRoutesRepository : ILookupRoutesRepository
    {
        private readonly IRoutesRepository _routesRepository;

        public LookupRoutesRepository(IRoutesRepository routesRepository)
        {
            _routesRepository = routesRepository;
        }

        public IEnumerable<ILookupRouteModel> GetAll()
        {
            var routes = _routesRepository.GetAll();
            return routes.Select(c=> new LookupRouteModel()
            {
                LookupRegex = new Regex(Interpolate(c.RequestTemplate)),
                RequestTemplate = c.RequestTemplate,
                TargetMapping = c.TargetMapping,
                RequestType = c.RequestType
            });
        }

        private string Interpolate(string template)
        {
            var replacables = template.GetReplacables();
            var newText = $"^{template}$";
            var first = true;

            foreach (var r in replacables)
            {
                var value = $"{(!first ? "?" : "")}(?<{r.Value}>[^/]+){{1}}";
                first = false;
                newText = newText.Replace(r.Key, value);
            }

            newText = newText.Replace("/", "\\/");
            return newText;
        }
    }
}
