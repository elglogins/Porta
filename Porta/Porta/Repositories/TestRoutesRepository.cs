using Porta.Interfaces.Models;
using Porta.Interfaces.Repositories;
using Porta.Models;
using System.Collections.Generic;

namespace Porta.Repositories
{
    public class TestRoutesRepository : IRoutesRepository
    {
        public IEnumerable<IRouteModel> GetAll()
        {
            return new List<IRouteModel>()
            {
                new RouteModel
                {
                    Template = "/customers/{id}/{type}/",
                    TargetMapping = "/api/customers?id={id}&ordersCount={ordersPagination}"
                }
            };
        }
    }
}
