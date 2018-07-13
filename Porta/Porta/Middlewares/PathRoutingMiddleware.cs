using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Porta.Extensions;
using Porta.Interfaces.Models;
using Porta.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
            var parameters = matches.Groups
                .Cast<Group>()
                .Skip(1);

            var tasks = new List<Task<object>>();
            foreach(var targetRequestMapping in matchingRouteConfiguration.TargetMapping)
                tasks.Add(Request(targetRequestMapping, parameters));

            var results = await Task.WhenAll(tasks);
            context.Response.ContentType = "application/json";
            using (var writer = new StreamWriter(context.Response.Body))
            {
                new JsonSerializer().Serialize(writer, results);
                await writer.FlushAsync().ConfigureAwait(false);
            }
        }

        private async Task<object> Request(ITargetRequestMappingModel mappingModel, IEnumerable<Group> parameters)
        {
            var targetPathReplacables = mappingModel.Template.ReplacePlaceholderValues(parameters);
            var uri = mappingModel.Resources.First(); // TODO: if multiple
            var url = $"{uri.Protocol.ToString().ToLower()}://{uri.Host}{(uri.Port.HasValue ? $":{uri.Port.Value}" : "")}{targetPathReplacables}";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(new Uri(url)))
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<object>(data);
                    }
                }
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}
