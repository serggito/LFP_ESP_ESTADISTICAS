using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MVC_Futbol.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Utilities.Models;
using Utilities.Peticiones;

namespace MVC_Futbol.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Peticion peticion;
        private IConfiguration configuration;
        private string urlBase;

        // se puede obtener de otra forma la configuracion tambien, en vez de solo la propiedad, meter objeto y obtenerlo
        // https://medium.com/@dozieogbo/a-better-way-to-inject-appsettings-in-asp-net-core-96be36ffa22b

        public HomeController(ILogger<HomeController> logger, IConfiguration config) // IConfiguration configuration
        {
            _logger = logger;
            this.configuration = config;
            urlBase = this.configuration.GetValue<string>("Configuracion:WebApiBaseUrl");
            this.peticion = new Peticion(new Uri(this.urlBase));
        }

        public async Task<ActionResult> Index()
        {
            var requestUrl = peticion.CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "/api/Encuentros/index"));
            var data = await peticion.GetAsync<List<PartidoDisputado>>(requestUrl);
            return View(data);

        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
