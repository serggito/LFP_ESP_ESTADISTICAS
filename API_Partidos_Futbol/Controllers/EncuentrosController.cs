using API_Partidos_Futbol.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Partidos_Futbol.Controllers
{

    [ApiController]
    public class EncuentrosController : ControllerBase
    {

        private readonly PartidosFutbolDbContext _context;

        public EncuentrosController(PartidosFutbolDbContext context)
        {
            _context = context;
        }

        // GET: api/Encuentros
        [HttpGet]
        [Route("api/[controller]/index")]
        public async Task<ActionResult<IEnumerable<PartidoDisputado>>> GetPartidosDisputados(int pageNumber = 1, int PageSize = 20)
        {
            // var lastFirst = await _context.PartidosDisputados

            var lastFirst = await _context.PartidosDisputados.OrderByDescending(x => x.Id)
                     .Skip((pageNumber - 1) * PageSize)
                     .Take(PageSize)
                     .ToListAsync();

            return lastFirst;
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<ActionResult<IEnumerable<PartidoDisputado>>> GetPartidosDisputadosPost(int pageNumber = 1, int PageSize = 10)
        {
            var pagedData =
            await _context.PartidosDisputados
                          .Skip((pageNumber - 1) * PageSize)
                          .Take(PageSize)
                          .ToListAsync();

            return pagedData;
        }

    }
}
