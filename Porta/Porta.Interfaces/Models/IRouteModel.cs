using Porta.Interfaces.Enums;
using System.Collections.Generic;

namespace Porta.Interfaces.Models
{
    public interface IRouteModel
    {
        string RequestTemplate { get; set; }

        IEnumerable<ITargetRequestMappingModel> TargetMapping { get; set; }

        RequestType RequestType { get; set; }
    }
}
