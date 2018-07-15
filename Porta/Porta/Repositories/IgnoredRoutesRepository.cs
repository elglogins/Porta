using Porta.Interfaces.Repositories;
using System.Collections.Generic;

namespace Porta.Repositories
{
    public class IgnoredRoutesRepository : IIgnoredRoutesRepository
    {
        public IEnumerable<string> GetAll()
        {
            return new List<string>()
            {
                "/favicon.ico"
            };
        }
    }
}
