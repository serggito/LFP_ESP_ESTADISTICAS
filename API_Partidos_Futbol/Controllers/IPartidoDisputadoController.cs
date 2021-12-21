using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Utilities.Models;

namespace API_Partidos_Futbol.Controllers
{
    public interface IPartidoDisputadoController
    {
        Task<IActionResult> DeletePartidoDisputado(int id);
        Task<ActionResult<PartidoDisputado>> GetPartidoDisputado(int id);
        Task<ActionResult<PartidoDisputado>> PostPartidoDisputado(PartidoDisputado partidoDisputado);
        Task<IActionResult> PutPartidoDisputado(int id, PartidoDisputado partidoDisputado);
    }
}