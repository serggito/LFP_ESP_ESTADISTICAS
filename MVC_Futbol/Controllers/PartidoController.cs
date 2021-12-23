using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
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
        public ActionResult Index()
        {
            return View();
        }

        // GET: PartidoController/Details/5
        public async Task<ActionResult> DetailsAsync(int id)
        {
            /*
            var requestUrl = peticion.CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "/api/PartidoDisputado/" + id));
            var data = await peticion.GetAsync<PartidoDisputado>(requestUrl);

            */

            HttpResponseMessage response = await httpClient.GetAsync(this.urlBase + "api/PartidoDisputado/"+id);
            var contents = await response.Content.ReadAsStringAsync();
            PartidoDisputado prtdsp = JsonConvert.DeserializeObject<PartidoDisputado>(contents);
            if (response.IsSuccessStatusCode)
            {
                // Get the URI of the created resource.
                //Uri returnUrl = response.Headers.Location;
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
                // TODO
                /*
                int id = collection["name"];

                PartidoDisputado partdisp = new PartidoDisputado();
                partdisp.Id = form["Id"];
                partdisp.Date = form["Date"];
                partdisp.Division = form["Division"];
                
                partdisp.LocalGoals = form["LocalGoals"];
                partdisp.LocalTeam = form["LocalTeam"];
                partdisp.Round = form["Round"];
                partdisp.Season = form["Season"];
                partdisp.Timestamp = form["Timestamp"];
                partdisp.VisitorGoals = form["VisitorGoals"];
                partdisp.VisitorTeam = form["VisitorTeam"];
                */

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
        public async Task<ActionResult> Edit(int id)
        {
            HttpResponseMessage response = await httpClient.GetAsync(this.urlBase + "api/PartidoDisputado/" + id);
            var contents = await response.Content.ReadAsStringAsync();
            PartidoDisputado prtdsp = JsonConvert.DeserializeObject<PartidoDisputado>(contents);
            if (response.IsSuccessStatusCode)
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
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        // GET: PartidoController/Delete/5
        public ActionResult Delete()
        {
            return View();
        }


        // DELETE: PartidoController/Delete/5
        [HttpPost("{id:int}")]
        public async Task<ActionResult> Delete(int id) // IFormCollection collection
        {
            return RedirectToAction("Index");

            /*
            HttpResponseMessage response = await this.httpClient.DeleteAsync(this.urlBase + "/api/PartidoDisputado/" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            */

            /*
            try
            {
                
                var requestUrl = peticion.CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "/api/PartidoDisputado"));
                var response = await peticion.DeleteAsync(requestUrl, id);
                

                
                HttpResponseMessage response = await httpClient.DeleteAsync("/api/PartidoDisputado/" + id);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                } else
                {
                    return View();
                }

                // return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            */
        }
    }
}
