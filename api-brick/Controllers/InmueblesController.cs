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
    public class InmueblesController : Controller
    {
        private readonly BrickDbContext _context;

        public InmueblesController(BrickDbContext context)
        {
            _context = context;
        }

        // GET: api/Inmuebles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inmueble>>> GetInmueble()
        {
            return await _context.Inmueble.ToListAsync();
        }

        // GET: api/Inmuebles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inmueble>> GetInmueble(int id)
        {
            var inmueble = await _context.Inmueble.FindAsync(id);

            if (inmueble == null)
            {
                return NotFound();
            }

            return inmueble;
        }

        // PUT: api/Inmuebles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInmueble(int id, Inmueble inmueble)
        {
            if (id != inmueble.InmuebleID)
            {
                return BadRequest();
            }

            _context.Entry(inmueble).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InmuebleExists(id))
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

        // POST: api/Inmuebles
        [HttpPost]
        public async Task<ActionResult<Inmueble>> PostInmueble(Inmueble inmueble)
        {
            var _inmueble = _context.Inmueble.FirstOrDefault( i => i.DescripcionInmueble == inmueble.DescripcionInmueble && i.ProyectoID == inmueble.ProyectoID);
            if (_inmueble == null)
            {
                _context.Inmueble.Add(inmueble);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetInmueble", new { id = inmueble.InmuebleID }, inmueble);
            }
            return Json(new { isSuccess = false, message = "Ya existe un inmueble con este nombre en el mismo proyecto. Intente con otro." });


        }

        // DELETE: api/Inmuebles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Inmueble>> DeleteInmueble(int id)
        {
            var inmueble = await _context.Inmueble.FindAsync(id);
            if (inmueble == null)
            {
                return NotFound();
            }

            _context.Inmueble.Remove(inmueble);
            await _context.SaveChangesAsync();

            return inmueble;
        }

        private bool InmuebleExists(int id)
        {
            return _context.Inmueble.Any(e => e.InmuebleID == id);
        }
    }
}
