using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Porta.Extensions
{
    public static class StringExtensions
    {
        public static Dictionary<string,string> GetReplacables(this string text)
        {
            return Regex.Matches(text, "{.*?}")
               .Cast<Match>()
               .Select(m => m.Value)
               .Distinct()
               .ToDictionary(c => c, c => c.Replace("{", "").Replace("}", ""));
        }

        public static string ReplacePlaceholderValues(this string template, IEnumerable<Group> parameters)
        {
            var replacables = template.GetReplacables();

            foreach(var replacable in replacables)
            {
                var parameterValue = parameters.FirstOrDefault(f => f.Name == replacable.Value );
                template = template.Replace(replacable.Key, parameterValue.Value);
            }

            return template;
        }
    }
}
