using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Models;
using Utilities.Peticiones;

namespace MVC_Futbol.Controllers
{
    public class PartidoController : Controller
    {
        private Peticion peticion;
        private IConfiguration configuration;
        private string urlBase;

        // se puede obtener de otra forma la configuracion tambien, en vez de solo la propiedad, meter objeto y obtenerlo
        // https://medium.com/@dozieogbo/a-better-way-to-inject-appsettings-in-asp-net-core-96be36ffa22b

        public PartidoController(IConfiguration config) // IConfiguration configuration
        {
            this.configuration = config;
            urlBase = this.configuration.GetValue<string>("Configuracion:WebApiBaseUrl");
            this.peticion = new Peticion(new Uri(this.urlBase));
        }

        // GET: PartidoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PartidoController/Details/5
        public async Task<ActionResult> DetailsAsync(int id)
        {
            var requestUrl = peticion.CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "/api/PartidoDisputado/"+id));
            var data = await peticion.GetAsync<PartidoDisputado>(requestUrl);
            return View(data);
        }

        // GET: PartidoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PartidoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: PartidoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
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

        // GET: PartidoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PartidoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
