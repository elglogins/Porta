using Porta.Interfaces.Enums;

namespace Porta.Interfaces.Models
{
    public interface IResourceModel
    {
        string Host { get; set; }

        int? Port { get; set; }

        ResourceProtocol Protocol { get; set; }
    }
}
