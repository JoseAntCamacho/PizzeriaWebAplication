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

namespace Pizzeria_WebAplication.Controllers
{
    public class PizzaController : ApiController
    {
        private class FormItem
        {
            public FormItem() { }
            public string name { get; set; }
            public byte[] data { get; set; }
            public string fileName { get; set; }
            public string mediaType { get; set; }
            public string value { get { return Encoding.Default.GetString(data); } }
            public bool isAFileUpload { get { return !String.IsNullOrEmpty(fileName); } }
        }

        // llevarme esto al dominio, la clase FormItem. Hacer validaciones del mediaType.
        // Hacer una relación uno a uno con la pizza y así guardamos el mediaType.
        // Hacer una lista de los mediaType que se soportan y hacer una validación en el método post.

        // de los byte a un memorystream.
        // del memorystream web api download file. Return binary
        // en el header hay que poner el media type de la imagen.

        // probar y testear con el index.html y/o con el findler.

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
            var picture = _pizzaService.GetImage(id);
            return Request.CreateResponse(HttpStatusCode.Created, picture);
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
                    if (!formItem.isAFileUpload)
                    {
                        switch (formItem.name)
                        {
                            case "Name":
                                dto.Name = Encoding.UTF8.GetString(formItem.data);
                                break;
                            case "Picture":
                                dto.Picture = formItem.data;
                                break;
                            case "Ingredients":
                                var format = Encoding.UTF8.GetString(formItem.data);
                                dto.Ingredients = JsonConvert.DeserializeObject<List<int>>(format);
                                break;
                        }
                    }
                }

                var pizza = _pizzaService.Add(dto);
                var obj = new { Id = pizza.Id, Name = pizza.Name,
                                Image = String.Format("/api/pizza/{0}/image",pizza.Id)};

                return Request.CreateResponse(HttpStatusCode.Created,obj);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        //POST : api/pizza

        
    }
}
