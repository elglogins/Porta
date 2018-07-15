using System.Collections.Generic;

namespace Porta.Interfaces.Repositories
{
    public interface IIgnoredRoutesRepository
    {
        IEnumerable<string> GetAll();
    }
}
