using System.Text.RegularExpressions;

namespace Porta.Interfaces.Models
{
    public interface ILookupRouteModel : IRouteModel
    {
        Regex LookupRegex { get; set; }
    }
}
