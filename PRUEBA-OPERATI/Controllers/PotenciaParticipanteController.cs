using GESTION_PAGOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRUEBA_OPERATI.Entities;

namespace PRUEBA_OPERATI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PotenciaParticipanteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PotenciaParticipanteController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("todos")]
        public async Task<IActionResult> GetAll()
        {
            var datos = await _context.PotenciasParticipantes.ToListAsync();
            return Ok(datos);
        }

        [HttpDelete("eliminar-todos")]
        public async Task<IActionResult> EliminarTodos()
        {
            var registros = await _context.PotenciasParticipantes.ToListAsync();

            if (registros.Count == 0)
            {
                return NotFound("No hay registros para eliminar.");
            }

            _context.PotenciasParticipantes.RemoveRange(registros);
            await _context.SaveChangesAsync();

            return Ok("Todos los registros han sido eliminados exitosamente.");
        }

    }
}
