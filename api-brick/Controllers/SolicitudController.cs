using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_brick.Data;
using api_brick.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_brick.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudController : Controller
    {
        private readonly BrickDbContext _context;
        public SolicitudController(BrickDbContext context)
        {
            _context = context;
        }

        // GET: api/Solicitud

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Solicitud>>> GetSolicitud()
        {
            return await _context.SolicitudServicios.ToListAsync();
        }

        // GET: api/Solicitud/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Solicitud>> GetSolicitud(int id)
        {

            var Solicitud = await _context.SolicitudServicios.FindAsync(id);

            if (Solicitud == null)
            {
                return NotFound();
            }

            return Solicitud;
        }

        // PUT: api/Solicitud/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSolicitud(int id, Solicitud solicitud)
        {
            if (id != solicitud.SolicitudID)
            {
                return BadRequest();
            }

            _context.Entry(solicitud).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SolicitudExists(id))
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

        // POST: api/Solicitud
        [HttpPost]
        public async Task<ActionResult<Solicitud>> PostSolicitud(Solicitud solicitud)
        {
            _context.SolicitudServicios.Add(solicitud);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSolicitud", new { id = solicitud.SolicitudID }, solicitud);
        }

        // DELETE: api/Solicitud/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Solicitud>> DeleteSolicitud(int id)
        {
            var Solicitud = await _context.SolicitudServicios.FindAsync(id);
            if (Solicitud == null)
            {
                return NotFound();
            }

            _context.SolicitudServicios.Remove(Solicitud);
            await _context.SaveChangesAsync();

            return Solicitud;
        }

        private bool SolicitudExists(int id)
        {
            return _context.SolicitudServicios.Any(e => e.SolicitudID == id);
        }


    }
}