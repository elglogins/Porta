using Porta.Interfaces.Enums;
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
                    RequestTemplate = "/customers/{id}/{ordersCount}/",
                    TargetMapping = new List<ITargetRequestMappingModel>()
                    {
                        new TargetRequestMappingModel()
                        {
                            Template = "/api/customers/{id}",
                            Resources = new List<IResourceModel>()
                            {
                                new ResourceModel()
                                {
                                    Host = "localhost",
                                    Port = 5001,
                                    Protocol = ResourceProtocol.Http
                                }
                            }
                        },
                        new TargetRequestMappingModel()
                        {
                            Template = "/api/customer-orders?customerId={id}&count={ordersCount}",
                            Resources = new List<IResourceModel>()
                            {
                                new ResourceModel()
                                {
                                    Host = "localhost",
                                    Port = 5002,
                                    Protocol = ResourceProtocol.Http
                                }
                            }
                        }
                    },
                    RequestType = RequestType.Get
                }
            };
        }
    }
}
