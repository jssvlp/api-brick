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

        [HttpGet("GetCaracteristicaProyecto")]
        public async Task<ActionResult<IEnumerable<Caracteristica>>> GetCaracteristicaProyecto()
        {
            var distribucion = await _context.Caracteristica.Where(i => i.TipoCarProyecto == "Distribucion").ToListAsync();
            var amenidades = await _context.Caracteristica.Where(i => i.TipoCarProyecto == "Amenidades").ToListAsync();
            var seguridad = await _context.Caracteristica.Where(i => i.TipoCarProyecto == "Seguridad").ToListAsync();
            var descripcionG = await _context.Caracteristica.Where(i => i.TipoCarProyecto == "DescripcionG").ToListAsync();
            var descripcionA = await _context.Caracteristica.Where(i => i.TipoCarProyecto == "DescripcionA").ToListAsync();
            var otros = await _context.Caracteristica.Where(i => i.TipoCarProyecto == "Otros").ToListAsync();

            return Json(new { distribucion, amenidades, seguridad, descripcionG, descripcionA, otros });
        }


        //GET: api/Caracteristica/byProyecto/2
        [HttpGet("GetByProyecto/{id}", Name = "GetByProyecto")]
        public async Task<ActionResult<IEnumerable<Caracteristica>>> GetCaracterisitcasByProyecto(int id)
        {
            var distribucion = await _context.CaracteristicaProyectos.Where(i => i.ProyectoID == id && i.Caracteristica.TipoCarProyecto == "Distribucion").Include(i => i.Caracteristica).ToListAsync();
            var amenidades = await _context.CaracteristicaProyectos.Where(i => i.ProyectoID == id && i.Caracteristica.TipoCarProyecto == "Amenidades").Include(i => i.Caracteristica).ToListAsync();
            var seguridad = await _context.CaracteristicaProyectos.Where(i => i.ProyectoID == id && i.Caracteristica.TipoCarProyecto == "Seguridad").Include(i => i.Caracteristica).ToListAsync();
            var descripcionG = await _context.CaracteristicaProyectos.Where(i => i.ProyectoID == id && i.Caracteristica.TipoCarProyecto == "DescripcionG").Include(i => i.Caracteristica).ToListAsync();
            var descripcionA = await _context.CaracteristicaProyectos.Where(i => i.ProyectoID == id && i.Caracteristica.TipoCarProyecto == "DescripcionA").Include(i => i.Caracteristica).ToListAsync();
            var otros = await _context.CaracteristicaProyectos.Where(i => i.ProyectoID == id && i.Caracteristica.TipoCarProyecto == "Otros").Include(i => i.Caracteristica).ToListAsync();
            //var proyecto = _context.CaracteristicaProyectos.Where(i => i.ProyectoID == ProyectoID && i.Caracteristica.TipoCar == "Proyectos").Select(c => c.Caracteristica);

            return Json(new { distribucion, amenidades, seguridad, descripcionG, descripcionA, otros });

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


        //POST: for Entidad asociativa caracteristicasinmuebles
        [HttpPost("CaracteristicaProyecto")]
        public async Task<ActionResult<Caracteristica>> PostCaracteristicaProyecto(CaracteristicaProyecto caracteristicaproyecto)
        {
            var caracteristica = _context.Caracteristica.Find(caracteristicaproyecto.CaracteristicaID);
            var proyecto = _context.Proyecto.Find(caracteristicaproyecto.ProyectoID);

            if (caracteristica != null && proyecto != null)
            {
                var _caracproyecto = new CaracteristicaProyecto { ProyectoID = caracteristicaproyecto.ProyectoID, CaracteristicaID = caracteristicaproyecto.CaracteristicaID };
                _context.CaracteristicaProyectos.Add(_caracproyecto);
                await _context.SaveChangesAsync();

                return Json(new { isSuccess = true, message = "Registro insertado correctamente" });

            }
            return Json(new { isSuccess = false, message = "La caracteristica o el proyecto enviado no existe, por favor proceda a insertarlos." });
        }


        // POST: api/Caracteristicas
        [HttpPost]
        public async Task<ActionResult<Caracteristica>> PostCaracteristica(Caracteristica caracteristica)
        {
            //Valida si existe una caracteristica con ese nombre
            var _caracterisitica = _context.Caracteristica.FirstOrDefault( c => c.CarNombre == caracteristica.CarNombre);

            if (_caracterisitica == null)
            {
                _context.Caracteristica.Add(caracteristica);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCaracteristica", new { id = caracteristica.CaracteristicaID }, caracteristica);
            }
            return null;


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


        [HttpDelete("DeleteCaracterisiticaByProyecto/{ProyectoId}")]
        public async Task<ActionResult<Caracteristica>> DeletaCaracteristicaByProyecto(int ProyectoId)
        {

            _context.CaracteristicaProyectos.Where(p => p.ProyectoID == ProyectoId)
                .ToList().ForEach(p => _context.CaracteristicaProyectos.Remove(p));
            _context.SaveChanges();
            return Json(new { isSuccess = true, message = "Registros borrado satisfactoriamente." });
        }


        private bool CaracteristicaExists(int id)
        {
            return _context.Caracteristica.Any(e => e.CaracteristicaID == id);
        }
    }
}