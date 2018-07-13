using Microsoft.AspNetCore.Mvc;
using Porta.Test.Orders.Models;
using System;
using System.Collections.Generic;

namespace Porta.Test.Orders.Controllers
{
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpGet]
        [Route("/api/customer-orders")]
        public ActionResult<IEnumerable<OrderModel>> GetCustomerOrders(string customerId, int count)
        {
            var orders = new List<OrderModel>();
            if (count <= 0)
                return orders;

            for (int i=0; i < count; i++)
            {
                orders.Add(new OrderModel()
                {
                    Id = Guid.NewGuid().ToString(),
                    Quantity = i
                });
            }
            return orders;
        }
    }
}
