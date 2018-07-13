using Porta.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Porta.Models
{
    public class TargetRequestMappingModel : ITargetRequestMappingModel
    {
        public string Template { get; set; }
        public IEnumerable<IResourceModel> Resources { get; set; }
    }
}
