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
                LookupRegex = new Regex(Interpolate(c.Template)),
                Template = c.Template,
                TargetMapping = c.TargetMapping
            });
        }

        private string Interpolate(string template)
        {
            var replacables = GetReplacables(template);
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

        private Dictionary<string, string> GetReplacables(string text)
        {
            return Regex.Matches(text, "{.*?}")
                .Cast<Match>()
                .Select(m => m.Value)
                .Distinct()
                .ToDictionary(c => c, c => c.Replace("{", "").Replace("}", ""));
        }
    }
}
