using Porta.Interfaces.Models;
using System.Collections.Generic;

namespace Porta.Interfaces.Repositories
{
    public interface ILookupRoutesRepository
    {
        IEnumerable<ILookupRouteModel> GetAll();
    }
}
