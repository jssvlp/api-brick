using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_brick.Data;
using api_brick.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace api_brick.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasacionesController : ControllerBase
    {
        private readonly BrickDbContext _context;

        public TasacionesController(BrickDbContext context)
        {
            _context = context;
        }

        // GET: api/Tasaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tasacion>>> GetTasacions()
        {
            return await _context.Tasacions.ToListAsync();
        }

        // GET: api/Tasaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tasacion>> GetTasacion(int id)
        {
            var tasacion = await _context.Tasacions.FindAsync(id);

            if (tasacion == null)
            {
                return NotFound();
            }

            return tasacion;
        }

        // PUT: api/Tasaciones/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutTasacion(int id, Tasacion tasacion)
        {
            if (id != tasacion.TasacionID)
            {
                return BadRequest();
            }

            _context.Entry(tasacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TasacionExists(id))
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

        // POST: api/Tasaciones
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Tasacion>> PostTasacion(Tasacion tasacion)
        {
            _context.Tasacions.Add(tasacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTasacion", new { id = tasacion.TasacionID }, tasacion);
        }

        // DELETE: api/Tasaciones/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Tasacion>> DeleteTasacion(int id)
        {
            var tasacion = await _context.Tasacions.FindAsync(id);
            if (tasacion == null)
            {
                return NotFound();
            }

            _context.Tasacions.Remove(tasacion);
            await _context.SaveChangesAsync();

            return tasacion;
        }

        private bool TasacionExists(int id)
        {
            return _context.Tasacions.Any(e => e.TasacionID == id);
        }
    }
}
