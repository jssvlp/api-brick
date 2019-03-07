using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_brick.Data;
using api_brick.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_brick.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ComentariosForoController : Controller
    {
        private readonly BrickDbContext _context;
        
        public ComentariosForoController(BrickDbContext context)
        {
            _context = context;
        }

        // GET: api/ComentariosForo

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComentarioForo>>> GetComentario()
        {
            return await _context.CometarioForos.ToListAsync();
        }

        // GET: api/ComentariosForo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComentarioForo>> GetComentario(int id)
        {

            var comentario = await _context.CometarioForos.FindAsync(id);

            if (comentario == null)
            {
                return NotFound();
            }

            return comentario;
        }

        // PUT: api/ComentariosForo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComentario(int id, ComentarioForo comentario)
        {
            if (id != comentario.ComentarioID)
            {
                return BadRequest();
            }

            _context.Entry(comentario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComentarioExists(id))
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

        // POST: api/ComentariosForo
        [HttpPost]
        public async Task<ActionResult<ComentarioForo>> PostComentario(ComentarioForo comentario)
        {
            _context.CometarioForos.Add(comentario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComentario", new { id = comentario.ComentarioID }, comentario);
        }

        // DELETE: api/ComentariosForo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ComentarioForo>> DeleteComentario(int id)
        {
            var comentario = await _context.CometarioForos.FindAsync(id);
            if (comentario == null)
            {
                return NotFound();
            }

            _context.CometarioForos.Remove(comentario);
            await _context.SaveChangesAsync();

            return comentario;
        }


        private bool ComentarioExists(int id)
        {
            return _context.CometarioForos.Any(e => e.ComentarioID == id);
        }


    }

}