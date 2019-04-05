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
    public class SolicitudController : Controller
    {
        private readonly BrickDbContext _context;
        public SolicitudController(BrickDbContext context)
        {
            _context = context;
        }

        // GET: api/Solicitud

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Solicitud>>> GetSolicitud()
        {
            return await _context.Solicitud.Include(x => x.ServicioSolicituds).Include(y => y.Usuario).ToListAsync();
        }

        // GET: api/Solicitud/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Solicitud>> GetSolicitud(int id)
        {

            var Solicitud = await _context.Solicitud.FindAsync(id);

            if (Solicitud == null)
            {
                return NotFound();
            }

            return Solicitud;
        }

        [Route("ServicioSolicitud")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServicioSolicitud>>> GetServsPendientes()
        {
            return await _context.ServicioSolicituds.Where(i => i.EstadoID == 2).Include(x => x.Solicitud).Include(y => y.Servicio).Include(z => z.Estado).ToListAsync();
        }

        [Route("ServicioSolicitudA")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServicioSolicitud>>> GetServsOtras()
        {
            return await _context.ServicioSolicituds.Where(i => i.EstadoID != 2).Include(x => x.Solicitud).Include(y => y.Servicio).Include(z => z.Estado).ToListAsync();
        }

        // GET: api/ServicioSolicitud/5
        [Route("ServicioSolicitud/{id}")]
        [HttpGet]
        public async Task<ActionResult<ServicioSolicitud>> GetServ(int id)
        {

            var Serv = await _context.ServicioSolicituds.Include(x => x.Estado).Include(y => y.Servicio).Include(z => z.Solicitud).ThenInclude(z => z.Usuario).FirstOrDefaultAsync(x => x.SolicitudID == id);

            if (Serv == null)
            {
                return NotFound();
            }

            return Serv;
        }

        // PUT: api/ServicioSolicitud/5
        [Route("ServicioSolicitud/{id}")]
        [HttpPut]
        public async Task<IActionResult> PutServSol(int id, ServicioSolicitud serv)
        {
            if (id != serv.SolicitudID)
            {
                return BadRequest();
            }

            _context.Entry(serv).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SolicitudExists(id))
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


        // PUT: api/Solicitud/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSolicitud(int id, Solicitud solicitud)
        {
            if (id != solicitud.SolicitudID)
            {
                return BadRequest();
            }

            _context.Entry(solicitud).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SolicitudExists(id))
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

        //POST: for Entidad asociativa ServicioSolicitud
        [Route("ServicioSolicitud")]
        [HttpPost()]
        public async Task<ActionResult<Solicitud>> PostCaracteristicaInmuelbe(ServicioSolicitud serv)
        {
            
            var solicitud = _context.Solicitud.Find(serv.SolicitudID);
            var servicio = _context.Servicios.Find(serv.ServicioID);
            var estado = _context.Estados.Find(serv.EstadoID);

            if (solicitud != null && servicio != null && estado !=null)
            {
                var _serviciosolicitud = new ServicioSolicitud { ServicioID = serv.ServicioID, SolicitudID = serv.SolicitudID, EstadoID = serv.EstadoID};
                _context.ServicioSolicituds.Add(_serviciosolicitud);
                await _context.SaveChangesAsync();

                return Json(new { isSuccess = true, message = "Registro insertado correctamente" });

            }
            return Json(new { isSuccess = false, message = "La solicitud o el servicio enviado no existe, por favor proceda a insertarlos." });

        }

        // POST: api/Solicitud
        [HttpPost]
        public async Task<ActionResult<Solicitud>> PostSolicitud(Solicitud solicitud)
        {
            _context.Solicitud.Add(solicitud);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSolicitud", new { id = solicitud.SolicitudID }, solicitud);
        }

        // DELETE: api/Solicitud/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Solicitud>> DeleteSolicitud(int id)
        {
            var Solicitud = await _context.Solicitud.FindAsync(id);
            if (Solicitud == null)
            {
                return NotFound();
            }

            _context.Solicitud.Remove(Solicitud);
            await _context.SaveChangesAsync();

            return Solicitud;
        }

        private bool SolicitudExists(int id)
        {
            return _context.Solicitud.Any(e => e.SolicitudID == id);
        }


    }
}