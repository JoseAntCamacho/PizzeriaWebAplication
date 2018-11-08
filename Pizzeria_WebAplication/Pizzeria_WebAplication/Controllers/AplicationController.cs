using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pizzeria_WebAplication.Controllers
{
    public class AplicationController : ApiController
    {
        private readonly IPizzaService _pizzaService;

        public AplicationController (IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        // GET: api/Aplication
        /*public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        // GET: api/Aplication/5
        /*public string Get(int id)
        {
            return "value";
        }*/

        // POST: api/Aplication
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Aplication/5
        /*public void Put(int id, [FromBody]string value)
        {
        }*/
    }
}
