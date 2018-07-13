using Porta.Interfaces.Models;
using System.Text.RegularExpressions;

namespace Porta.Models
{
    public class LookupRouteModel : RouteModel, ILookupRouteModel
    {
        public Regex LookupRegex { get; set; } 
    }
}
