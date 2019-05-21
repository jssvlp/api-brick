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
    [Route("api/[controller]")]
    [ApiController]
    public class DatosGenericosController : ControllerBase
    {
        private readonly BrickDbContext _context;

        public DatosGenericosController(BrickDbContext context)
        {
            _context = context;
        }

        // GET: api/DatosGenericos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DatoGenerico>>> GetDatosGenericos()
        {
            return await _context.DatosGenericos.ToListAsync();
        }

        // GET: api/DatosGenericos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DatoGenerico>> GetDatoGenerico(int id)
        {
            var datoGenerico = await _context.DatosGenericos.FindAsync(id);

            if (datoGenerico == null)
            {
                return NotFound();
            }

            return datoGenerico;
        }

        // PUT: api/DatosGenericos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDatoGenerico(int id, DatoGenerico datoGenerico)
        {
            if (id != datoGenerico.Id)
            {
                return BadRequest();
            }

            _context.Entry(datoGenerico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DatoGenericoExists(id))
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

        // POST: api/DatosGenericos
        [HttpPost]
        public async Task<ActionResult<DatoGenerico>> PostDatoGenerico(DatoGenerico datoGenerico)
        {
            _context.DatosGenericos.Add(datoGenerico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDatoGenerico", new { id = datoGenerico.Id }, datoGenerico);
        }

        // DELETE: api/DatosGenericos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DatoGenerico>> DeleteDatoGenerico(int id)
        {
            var datoGenerico = await _context.DatosGenericos.FindAsync(id);
            if (datoGenerico == null)
            {
                return NotFound();
            }

            _context.DatosGenericos.Remove(datoGenerico);
            await _context.SaveChangesAsync();

            return datoGenerico;
        }

        private bool DatoGenericoExists(int id)
        {
            return _context.DatosGenericos.Any(e => e.Id == id);
        }
    }
}
