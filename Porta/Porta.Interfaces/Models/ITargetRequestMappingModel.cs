using System.Collections.Generic;

namespace Porta.Interfaces.Models
{
    public interface ITargetRequestMappingModel
    {
        string Template { get; set; }

        IEnumerable<IResourceModel> Resources { get; set; }
    }
}
