using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Porta.Test.Customers.Models;

namespace Porta.Test.Customers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<CustomerModel> Get(int id)
        {
            return new CustomerModel()
            {
                Id = id.ToString(),
                FirstName = "Test"
            };
        }
    }
}
