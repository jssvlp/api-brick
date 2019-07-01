using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_brick.Data;
using api_brick.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_brick.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TemasForoController : Controller
    {
        private readonly BrickDbContext _context;
        public TemasForoController(BrickDbContext context) {
            _context = context;
        }

        // GET: api/TemasForo

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TemasForo>>> GetTemasForo()
        {
            return await _context.TemasForos.ToListAsync();
        }

        // GET: api/TemasForo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TemasForo>> GetTemasForo(int id)
        {
            var tema = await _context.TemasForos.FindAsync(id);

            if(tema == null)
            {
                return NotFound();
            }

            return tema;

        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutTemasForo(int id, TemasForo temasForo)
        {
            if (id != temasForo.TemaID)
            {
                return BadRequest();
            }
            _context.Entry(temasForo).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TemasForoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();


        }

        // POST: api/TemasForo
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<TemasForo>> PostTemasForo(TemasForo temasForo)
        {
            var _categoria = _context.TemasForos.FirstOrDefault(c => c.NombreTema == temasForo.NombreTema);
            if (_categoria == null)
            {
                _context.TemasForos.Add(temasForo);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetTemasForo", new { id = temasForo.TemaID }, temasForo);
            }
            return null;
        }

        // DELETE: api/TemasForo/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] 
        public async Task<ActionResult<TemasForo>> DeleteTemasForo(int id)
        {
            var tema = await _context.TemasForos.FindAsync(id);
            if (tema == null)
            {
                return NotFound();
            }

            _context.TemasForos.Remove(tema);
            await _context.SaveChangesAsync();

            return tema;
        }

        private bool TemasForoExists(int id)
        {
            return _context.TemasForos.Any(e => e.TemaID == id);
        }
    }




}
