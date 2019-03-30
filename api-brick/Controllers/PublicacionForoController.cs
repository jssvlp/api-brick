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
    public class PublicacionForoController : Controller
    {
        private readonly BrickDbContext _context;
        public PublicacionForoController(BrickDbContext context)
        {
            _context = context;
        }

        // GET: api/PublicacionForo

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicacionForo>>> GetPublicacion()
        {
            return await _context.PublicacionesForos.ToListAsync();
        }

        // GET: api/PublicacionForo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicacionForo>> GetPublicacion(int id)
        {

            var publicacion = await _context.PublicacionesForos.FindAsync(id);

            if (publicacion == null)
            {
                return NotFound();
            }

            return publicacion;
        }

        // PUT: api/PublicacionForo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublicacion(int id, PublicacionForo publicacion)
        {
            if (id != publicacion.PublicacionID)
            {
                return BadRequest();
            }

            _context.Entry(publicacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublicacionExists(id))
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

        // POST: api/PublicacionForo
        [HttpPost]
        public async Task<ActionResult<PublicacionForo>> PostPublicacion(PublicacionForo publicacion)
        {
            _context.PublicacionesForos.Add(publicacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPublicacion", new { id = publicacion.PublicacionID }, publicacion);
        }

        // DELETE: api/PublicacionForo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicacionForo>> DeletePublicacion(int id)
        {
            var publicacion = await _context.PublicacionesForos.FindAsync(id);
            if (publicacion == null)
            {
                return NotFound();
            }

            _context.PublicacionesForos.Remove(publicacion);
            await _context.SaveChangesAsync();

            return publicacion;
        }

        private bool PublicacionExists(int id)
        {
            return _context.PublicacionesForos.Any(e => e.PublicacionID == id);
        }

    }
}