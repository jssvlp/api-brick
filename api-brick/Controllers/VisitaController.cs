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
    public class VisitaController : Controller
    {
        private readonly BrickDbContext _context;
        public VisitaController(BrickDbContext context)
        {
            _context = context;
        }

        // GET: api/Visita
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VisitasAgendada>>> GetVisita()
        {
            return await _context.VisitasAgendadas.ToListAsync();
        }

        // GET: api/Visita/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VisitasAgendada>> GetVisita(int id)
        {

            var visita = await _context.VisitasAgendadas.FindAsync(id);

            if (visita == null)
            {
                return NotFound();
            }

            return visita;
        }

        // PUT: api/Visita/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVisita(int id, VisitasAgendada visita)
        {
            if (id != visita.VisitaID)
            {
                return BadRequest();
            }

            _context.Entry(visita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitaExists(id))
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

        // POST: api/Visita
        [HttpPost]
        public async Task<ActionResult<VisitasAgendada>> PostVisita(VisitasAgendada visita)
        {
            _context.VisitasAgendadas.Add(visita);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVisita", new { id = visita.VisitaID }, visita);
        }

        // DELETE: api/Visita/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VisitasAgendada>> DeleteVisita(int id)
        {
            var visita = await _context.VisitasAgendadas.FindAsync(id);
            if (visita == null)
            {
                return NotFound();
            }

            _context.VisitasAgendadas.Remove(visita);
            await _context.SaveChangesAsync();

            return visita;
        }

        private bool VisitaExists(int id)
        {
            return _context.VisitasAgendadas.Any(e => e.VisitaID == id);
        }

    }
}