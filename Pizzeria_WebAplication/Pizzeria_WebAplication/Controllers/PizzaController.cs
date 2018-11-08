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
using System.Text;
using System.IO;

namespace Pizzeria_WebAplication.Controllers
{
    public class PizzaController : ApiController
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController (IPizzaService pizzaService)
        {
            _pizzaService = pizzaService ?? throw new ArgumentNullException("Null Service pizzaService");
        }

        // GET: api/pizza/id/image
        [HttpGet]
        [Route("{id:int}/image")]
        public HttpResponseMessage GetPizzaImage(int id)
        {
            var picture = _pizzaService.GetImageByPizzaId(id);
            var mediaType = _pizzaService.GetMediaTypeImage(id);

            var dataStream = new MemoryStream(picture);
            
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StreamContent(dataStream);

            response.Content.Headers.ContentDisposition =
                new System.Net.Http.Headers.ContentDispositionHeaderValue("inline");
            response.Content.Headers.ContentType = 
                new System.Net.Http.Headers.MediaTypeHeaderValue(mediaType);

            return response;
        }

        //POST : api/pizza/add
        [HttpPost]
        [ActionName("add")]
        public async Task<HttpResponseMessage> PostAdd()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                //TODO: Redirigir a la vista principal.
            }

            var provider = new MultipartMemoryStreamProvider();

            try
            {
                // Read the form data.
                await Request.Content.ReadAsMultipartAsync(provider);

                var formItems = new List<FormItem>();

                // Scan the Multiple Parts 
                foreach (HttpContent contentPart in provider.Contents)
                {
                    var formItem = new FormItem();
                    var contentDisposition = contentPart.Headers.ContentDisposition;
                    formItem.name = contentDisposition.Name.Trim('"');
                    formItem.data = await contentPart.ReadAsByteArrayAsync();
                    formItem.fileName = String.IsNullOrEmpty(contentDisposition.FileName) ? "" : contentDisposition.FileName.Trim('"');
                    formItem.mediaType = contentPart.Headers.ContentType == null ? "" : String.IsNullOrEmpty(contentPart.Headers.ContentType.MediaType) ? "" : contentPart.Headers.ContentType.MediaType;
                    formItems.Add(formItem);
                }

                var dto = new DtoPizza(); 
                  
                foreach (var formItem in formItems)
                {
                    switch (formItem.name)
                    {
                        case "Name":
                            dto.Name = Encoding.UTF8.GetString(formItem.data);
                            break;
                        case "Picture":
                            dto.Picture = formItem.data;
                            dto.FormItems = formItem;
                            break;
                        case "Ingredients":
                            var format = Encoding.UTF8.GetString(formItem.data);
                            var numbers = format.Split(',').Select(Int32.Parse).ToList();
                            dto.Ingredients = new List<int>() { 1, 2 };
                            break;
                    }
                }

                var pizza = _pizzaService.Add(dto);
                var obj = new { Id = pizza.Id, Name = pizza.Name,
                                Image = String.Format("/api/pizza/{0}/image",pizza.Id)};

                var response = Request.CreateResponse(HttpStatusCode.Created, obj);
                response.Headers.Location =
                    new Uri("file:///C:/Users/Jose%20Antonio/Desktop/ProyectosNET/Front_Pizzeria/index.html");

                return response;
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
