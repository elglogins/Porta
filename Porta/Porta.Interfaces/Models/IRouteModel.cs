namespace Porta.Interfaces.Models
{
    public interface IRouteModel
    {
        string Template { get; set; }

        string TargetMapping { get; set; }
    }
}
