using Porta.Interfaces.Enums;
using Porta.Interfaces.Models;
using System;

namespace Porta.Models
{
    public class ResourceModel : IResourceModel
    {
        public string Host { get; set; }
        public int? Port { get; set; }
        public ResourceProtocol Protocol { get; set; }
    }
}
