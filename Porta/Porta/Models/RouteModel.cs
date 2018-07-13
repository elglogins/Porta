using System.Collections.Generic;
using Porta.Interfaces.Enums;
using Porta.Interfaces.Models;

namespace Porta.Models
{
    public class RouteModel : IRouteModel
    {
        public string RequestTemplate { get; set; }
        public RequestType RequestType { get; set; }
        public IEnumerable<ITargetRequestMappingModel> TargetMapping { get; set; }
    }
}
