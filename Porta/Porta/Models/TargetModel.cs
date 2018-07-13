using Porta.Interfaces.Enums;
using Porta.Interfaces.Models;

namespace Porta.Models
{
    public class TargetModel : IResourceModel
    {
        public string Host { get; set; }
        public int? Port { get; set; }
        public ResourceProtocol Protocol { get; set; }
    }
}
