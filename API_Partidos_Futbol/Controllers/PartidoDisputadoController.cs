using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Partidos_Futbol.Context;
using API_Partidos_Futbol.Models;

namespace API_Partidos_Futbol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartidoDisputadoController : ControllerBase
    {
        private readonly PartidosFutbolDbContext _context;

        public PartidoDisputadoController(PartidosFutbolDbContext context)
        {
            _context = context;
        }

        

        // GET: api/PartidoDisputado/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PartidoDisputado>> GetPartidoDisputado(int id)
        {
            var partidoDisputado = await _context.PartidosDisputados.FindAsync(id);

            if (partidoDisputado == null)
            {
                return NotFound();
            }

            return partidoDisputado;
        }

        // PUT: api/PartidoDisputado/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartidoDisputado(int id, PartidoDisputado partidoDisputado)
        {
            if (id != partidoDisputado.Id)
            {
                return BadRequest();
            }

            _context.Entry(partidoDisputado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartidoDisputadoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PartidoDisputado
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PartidoDisputado>> PostPartidoDisputado(PartidoDisputado partidoDisputado)
        {
            _context.PartidosDisputados.Add(partidoDisputado);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PartidoDisputadoExists(partidoDisputado.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPartidoDisputado", new { id = partidoDisputado.Id }, partidoDisputado);
        }

        // DELETE: api/PartidoDisputado/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartidoDisputado(int id)
        {
            var partidoDisputado = await _context.PartidosDisputados.FindAsync(id);
            if (partidoDisputado == null)
            {
                return NotFound();
            }

            _context.PartidosDisputados.Remove(partidoDisputado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PartidoDisputadoExists(int id)
        {
            return _context.PartidosDisputados.Any(e => e.Id == id);
        }
    }
}
