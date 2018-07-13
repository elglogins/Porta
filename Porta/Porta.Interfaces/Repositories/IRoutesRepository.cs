using Porta.Interfaces.Models;
using System.Collections.Generic;

namespace Porta.Interfaces.Repositories
{
    public interface IRoutesRepository
    {
        IEnumerable<IRouteModel> GetAll();
    }
}
