using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_brick.Data;
using api_brick.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_brick.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeticionesController : ControllerBase
    {
        private readonly BrickDbContext _context;

        public PeticionesController(BrickDbContext context) {
            _context = context;
        }

        // GET: api/Peticiones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Peticion>>> GetPeticiones()
        {
            return await _context.Peticiones.Where(i => i.Estado == "Pendiente").ToListAsync();
        }

        // GET: api/Peticiones
        [Route("PeticionesA")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Peticion>>> GetPeticionesA()
        {
            return await _context.Peticiones.Where(i => i.Estado != "Pendiente").ToListAsync();
        }

        // GET: api/Peticiones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Peticion>> GetPeticion(int id)
        {
            var peticion = await _context.Peticiones.Include(x => x.Solicitud).ThenInclude(x => x.Usuario).FirstOrDefaultAsync(x => x.PeticionID == id);

            if (peticion == null)
            {
                return NotFound();
            }

            return peticion;
        }

        // POST: api/Peticion
        [HttpPost]
        public async Task<ActionResult<Peticion>> PostPeticion(Peticion peticion)
        {
            var _peticion = _context.Peticiones.FirstOrDefault(c => c.SolicitudID == peticion.SolicitudID &&  c.Estado == peticion.Estado);

            if (_peticion == null)
            {
              
                _context.Peticiones.Add(peticion);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetPeticion", new { id = peticion.PeticionID }, peticion);
            }
            return null;
        }

        // PUT: api/Peticiones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPeticion(int id, Peticion peticion)
        {
            if (id != peticion.PeticionID)
            {
                return BadRequest();
            }

            _context.Entry(peticion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeticionExists(id))
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

        private bool PeticionExists(int id)
        {
            return _context.Peticiones.Any(e => e.PeticionID == id);
        }
    }
}