using API_Partidos_Futbol.Context;
using API_Partidos_Futbol.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Partidos_Futbol.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<ActionResult<IEnumerable<PartidoDisputado>>> GetPartidosDisputados()
        {
            int pageNumber = 1;
            int PageSize = 10;
            var pagedData = await _context.PartidosDisputados
               .Skip((pageNumber - 1) * PageSize)
               .Take(PageSize)
               .ToListAsync();

            return pagedData;
        }

    }
}
