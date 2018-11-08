using Application;
using Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using System.Web.Http;

namespace Pizzeria_WebAplication.Controllers
{
    public class PizzaController : ApiController
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController (IPizzaService pizzaService)
        {
            if (pizzaService == null)
            {
                throw new ArgumentNullException("pizzaService");
            }
            _pizzaService = pizzaService;
        }

        // GET: api/Aplication
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //POST : api/pizza/FormData
        [HttpPost]
        [ActionName("FormData")]
        public async Task<HttpResponseMessage> PostFormData()
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);

            try
            {
                // Read the form data.
                await Request.Content.ReadAsMultipartAsync(provider);

                // Show all the key-value pairs.

                var dto = new DtoPizza();
                foreach (var key in provider.FormData.AllKeys)
                {
                    foreach (var val in provider.FormData.GetValues(key))
                    {
                        if (key == "Name"){
                            dto.Name = val;
                        }
                        if (key == "Ingredientes")
                        {                            
                            dto.Ingredients= JsonConvert.DeserializeObject<List<int>>(val);
                        }
                    }
                }

                // This illustrates how to get the file names.
                foreach (MultipartFileData file in provider.FileData)
                {
                    Trace.WriteLine(file.Headers.ContentDisposition.FileName);
                    Trace.WriteLine("Server file path: " + file.LocalFileName);
                }

                
                var pizza = _pizzaService.Add(dto);

                //pizza la conviertes a objeto anonimo y lo devuelves
                return Request.CreateResponse(HttpStatusCode.Created,pizza);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        //POST : api/pizza

        
    }
}
