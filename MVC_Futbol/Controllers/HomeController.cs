using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MVC_Futbol.Models;
using MVC_Futbol.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Futbol.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // private string baseUrlApi;
        private readonly Configuracion _configuracion;

        // se puede obtener de otra forma la configuracion tambien, en vez de solo la propiedad, meter objeto y obtenerlo
        // https://medium.com/@dozieogbo/a-better-way-to-inject-appsettings-in-asp-net-core-96be36ffa22b

        public HomeController(ILogger<HomeController> logger, Configuracion configuracion) // IConfiguration configuration
        {
            _logger = logger;
            // this.baseUrlApi = configuration["WebApiBaseUrl"];
            this._configuracion = configuracion;
        }

        public IActionResult Index()
        {
            return View();
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
