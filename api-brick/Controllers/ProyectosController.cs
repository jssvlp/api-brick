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
    public class ProyectosController : Controller
    {
        private readonly BrickDbContext _context;

        public ProyectosController(BrickDbContext context)
        {
            _context = context;
        }

        // GET: api/Proyectos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proyecto>>> GetProyecto()
        {
            return await _context.Proyecto.Include(x => x.Ubicacion).ToListAsync();
        }

        // GET: api/Proyectos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Proyecto>> GetProyecto(int id)
        {
            var proyecto = await _context.Proyecto.Include(x => x.Inmuebles).FirstOrDefaultAsync(x => x.ProyectoID ==id);

            if (proyecto == null)
            {
                return NotFound();
            }

            return proyecto;
        }

        // PUT: api/Proyectos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProyecto(int id, Proyecto proyecto)
        {
            if (id != proyecto.ProyectoID)
            {
                return BadRequest();
            }

            _context.Entry(proyecto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProyectoExists(id))
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

        // POST: api/Proyectos
        [HttpPost]
        public async Task<ActionResult<Proyecto>> PostProyecto(Proyecto proyecto)
        {

            var _proyect = _context.Proyecto.Where( p => p.NombreProyecto == proyecto.NombreProyecto);

            if (_proyect == null)
            {
                _context.Proyecto.Add(proyecto);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetProyecto", new { id = proyecto.ProyectoID }, proyecto);
            }
            return Json(new { isSuccess = false, message = "Ya existe una proyecto con este nombre. Intente con otro." });



        }

        // DELETE: api/Proyectos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Proyecto>> DeleteProyecto(int id)
        {
            var proyecto = await _context.Proyecto.FindAsync(id);
            if (proyecto == null)
            {
                return NotFound();
            }

            _context.Proyecto.Remove(proyecto);
            await _context.SaveChangesAsync();

            return proyecto;
        }

        private bool ProyectoExists(int id)
        {
            return _context.Proyecto.Any(e => e.ProyectoID == id);
        }
    }
}
