using Porta.Interfaces.Models;

namespace Porta.Models
{
    public class RouteModel : IRouteModel
    {
        public string Template { get; set; }
        public string TargetMapping { get; set; }
    }
}
