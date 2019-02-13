using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_brick.Data;
using api_brick.Models;

namespace api_brick.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UbicacionesController : ControllerBase
    {
        private readonly BrickDbContext _context;

        public UbicacionesController(BrickDbContext context)
        {
            _context = context;
        }

        // GET: api/Ubicaciones
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ubicacion>>> GetUbicacion()
        {
            return await _context.Ubicacion.ToListAsync();
        }

        // GET: api/Ubicaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ubicacion>> GetUbicacion(int id)
        {
            var ubicacion = await _context.Ubicacion.FindAsync(id);

            if (ubicacion == null)
            {
                return NotFound();
            }

            return ubicacion;
        }

        // PUT: api/Ubicaciones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUbicacion(int id, Ubicacion ubicacion)
        {
            if (id != ubicacion.UbicacionID)
            {
                return BadRequest();
            }

            _context.Entry(ubicacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UbicacionExists(id))
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

        // POST: api/Ubicaciones
        [HttpPost]
        public async Task<ActionResult<Ubicacion>> PostUbicacion(Ubicacion ubicacion)
        {
            _context.Ubicacion.Add(ubicacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUbicacion", new { id = ubicacion.UbicacionID }, ubicacion);
        }

        // DELETE: api/Ubicaciones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ubicacion>> DeleteUbicacion(int id)
        {
            var ubicacion = await _context.Ubicacion.FindAsync(id);
            if (ubicacion == null)
            {
                return NotFound();
            }

            _context.Ubicacion.Remove(ubicacion);
            await _context.SaveChangesAsync();

            return ubicacion;
        }

        private bool UbicacionExists(int id)
        {
            return _context.Ubicacion.Any(e => e.UbicacionID == id);
        }
    }
}
