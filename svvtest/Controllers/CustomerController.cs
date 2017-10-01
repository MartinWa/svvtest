using System.Collections.Generic;
using System.Web.Http;
using svvtest.Model;

namespace svvtest.Controllers
{
    public class CustomersController : ApiController
    {
        public IHttpActionResult Get()
        {
            var customers = new List<Customer>
            {
                new Customer() {Name = "Nice customer", Address = "USA", Telephone = "123345456"},
                new Customer() {Name = "Good customer", Address = "UK", Telephone = "9878757654"},
                new Customer() {Name = "Awesome customer", Address = "France", Telephone = "34546456"}
            };
            return Ok(customers);
        }
    }
}
