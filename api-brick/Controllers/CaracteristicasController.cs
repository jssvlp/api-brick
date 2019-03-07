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
    public class CaracteristicasController : Controller
    {
        private readonly BrickDbContext _context;
        public CaracteristicasController(BrickDbContext context)
        {

            _context = context;
        }
        // GET: api/Caracteristicas

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Caracteristica>>> GetCaracteristica()
        {
            return await _context.Caracteristica.ToListAsync();
        }

        // GET: api/Caracteristicas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Caracteristica>> GetCaracteristica(int id)
        {

            var caracteristica = await _context.Caracteristica.FindAsync(id);

            if (caracteristica == null)
            {
                return NotFound();
            }

            return caracteristica;
        }

        // PUT: api/Caracteristicas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaracteristica(int id, Caracteristica caracteristica)
        {
            if (id != caracteristica.CaracteristicaID)
            {
                return BadRequest();
            }

            _context.Entry(caracteristica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaracteristicaExists(id))
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


        // POST: api/Caracteristicas
        [HttpPost]
        public async Task<ActionResult<Caracteristica>> PostCaracteristica(Caracteristica caracteristica)
        {
            _context.Caracteristica.Add(caracteristica);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCaracteristica", new { id = caracteristica.CaracteristicaID }, caracteristica);
        }

        // DELETE: api/Caracteristica/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Caracteristica>> DeleteCaracteristica(int id)
        {
            var caracteristica = await _context.Caracteristica.FindAsync(id);
            if (caracteristica == null)
            {
                return NotFound();
            }

            _context.Caracteristica.Remove(caracteristica);
            await _context.SaveChangesAsync();

            return caracteristica;
        }


        private bool CaracteristicaExists(int id)
        {
            return _context.CaracteristicaInmuebles.Any(e => e.CaracteristicaID == id);
        }
    }
}