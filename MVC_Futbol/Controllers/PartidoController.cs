using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Utilities.Models;
using Utilities.Peticiones;

namespace MVC_Futbol.Controllers
{
    // [Route("api/[controller]")]
    public class PartidoController : Controller
    {
        private Peticion peticion;
        private IConfiguration configuration;
        private string urlBase;
        private readonly HttpClient httpClient;
        private List<PartidoDisputado> partidosDisputados;

        // se puede obtener de otra forma la configuracion tambien, en vez de solo la propiedad, meter objeto y obtenerlo
        // https://medium.com/@dozieogbo/a-better-way-to-inject-appsettings-in-asp-net-core-96be36ffa22b

        public PartidoController(IConfiguration config) // IConfiguration configuration
        {
            this.configuration = config;
            urlBase = this.configuration.GetValue<string>("Configuracion:WebApiBaseUrl");
            this.peticion = new Peticion(new Uri(this.urlBase));
            this.httpClient = new HttpClient();
        }

        // GET: PartidoController
        [HttpGet("/index")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: PartidoController/Details/5
        public async Task<ActionResult> DetailsAsync(int id)
        {
            PartidoDisputado prtdsp = await this.getPartidoById(id);

            if (prtdsp != null)
            {
                // Get the URI of the created resource.
                // Uri returnUrl = response.Headers.Location;
                return View("details", prtdsp);
            }

            return RedirectToAction("Index");
            
        }

        // GET: PartidoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PartidoController/Create
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(PartidoDisputado ptds) // IFormCollection form
        {
            try
            {

                var requestUrl = peticion.CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "/api/PartidoDisputado"));
                var response = await peticion.PostAsync<PartidoDisputado>(requestUrl, ptds);

                return RedirectToAction("/HomeController/Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PartidoController/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            PartidoDisputado prtdsp = await this.getPartidoById(id);

            if (prtdsp != null)
            {
                // Get the URI of the created resource.
                //Uri returnUrl = response.Headers.Location;
                return View("Edit", prtdsp);
            } else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: PartidoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PartidoDisputado pd)
        {
            /*
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            */
            // HACIENDO este metodo, la request me dio errores 415 Unsuported media type, 405 not allowed y 400 bad request
            // 415 https://stackoverflow.com/questions/55473838/httpclient-statuscode-415-reasonphrase-unsupported-media-type
            // 405 https://stackoverflow.com/questions/15718741/405-method-not-allowed-web-api
            // 400 https://stackoverflow.com/questions/37380337/httpclient-keeps-receiving-bad-request

            /*
            string message = JsonConvert.SerializeObject(pd);
            byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(message);
            var content = new ByteArrayContent(messageBytes);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            */


            var jsonContent = new StringContent(JsonConvert.SerializeObject(pd), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PutAsync(this.urlBase + "api/PartidoDisputado/" + pd.Id, jsonContent);
            IEnumerable<string> cookies = response.Headers.SingleOrDefault(header => header.Key == "Set-Cookie").Value;
            var contents = await response.Content.ReadAsStringAsync();

            PartidoDisputado prtdsp = JsonConvert.DeserializeObject<PartidoDisputado>(contents);
            if (response.IsSuccessStatusCode)
            {
                // Get the URI of the created resource.
                //Uri returnUrl = response.Headers.Location;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Edit", prtdsp);
            }
        }


        // GET: PartidoController/Delete/5
        [HttpGet("/delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            HttpResponseMessage response = await this.httpClient.DeleteAsync(this.urlBase + "api/PartidoDisputado/" + id);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<ActionResult> RemoveItem(int id)
        {
            PartidoDisputado partidoDisputado = await this.getPartidoById(id);
            return View(partidoDisputado);
        }


        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemoveItem(int id, IFormCollection collection)
        {
            try
            {
                HttpResponseMessage response = await this.httpClient.DeleteAsync(this.urlBase + "api/PartidoDisputado/" + id);
                return RedirectToAction("Index", "Home");
                
                // return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private async Task<PartidoDisputado> getPartidoById(int id)
        {
            HttpResponseMessage response = await httpClient.GetAsync(this.urlBase + "api/PartidoDisputado/" + id);
            var contents = await response.Content.ReadAsStringAsync();
            PartidoDisputado prtdsp = JsonConvert.DeserializeObject<PartidoDisputado>(contents);

            if (response.IsSuccessStatusCode)
            {
                return prtdsp;
            }
            else
            {
                return null;
            }
        }
    }
}
