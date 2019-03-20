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


        //GET: api/Caracteristica/byInmueble/2
        [HttpGet("GetByInmueble/{InmuebleID}", Name = "GetByInmueble")]
        public ActionResult<IEnumerable<Caracteristica>> GetCaracterisitcasByInmueble(int InmuebleID)
        {
            var inmuebles = _context.CaracteristicaInmuebles.Where(i => i.InmuebleID == InmuebleID).Select(c => c.Caracteristica);
            //var inmuebles = (from c in _context.Caracteristica
            //                 from i in _context.CaracteristicaInmuebles
            //                 where i.InmuebleID == InmuebleID
            //                 select c);

            return Ok(inmuebles);
           
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
        [HttpPost("CaracteristicaInmueble/{InmuebleID}/{CaracteristicaID}")]
        public async Task<ActionResult<Caracteristica>> PostCaracteristicaInmuelbe(int InmuebleID, int CaracteristicaID)
        {
            var caracteristica = _context.Caracteristica.Find(CaracteristicaID);
            var immueble = _context.Inmueble.Find(InmuebleID);

            if(caracteristica != null && immueble != null)
            {
                var _caracInmueble = new CaracteristicaInmueble { InmuebleID = InmuebleID, CaracteristicaID = CaracteristicaID };
                _context.CaracteristicaInmuebles.Add(_caracInmueble);
                await _context.SaveChangesAsync();

                return Json(new { isSuccess = true, message = "Registro insertado correctamente" });

            }
            return Json(new { isSuccess = false, message = "La caracteristica o el inmueble enviado no existe, por favor proceda a insertarlos." });

        }

        // POST: api/Caracteristicas
        [HttpPost]
        public async Task<ActionResult<Caracteristica>> PostCaracteristica(Caracteristica caracteristica)
        {
            //Valida si existe una caracteristica con ese nombre
            var _caracterisitica = _context.Caracteristica.Where( c => c.CarNombre == caracteristica.CarNombre);

            if (_caracterisitica == null)
            {
                _context.Caracteristica.Add(caracteristica);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCaracteristica", new { id = caracteristica.CaracteristicaID }, caracteristica);
            }
            return Json(new { isSuccess = false, message = "Ya existe una caracterisita con este nombre. Intente con otro."});


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

        [HttpDelete("CaracteristicaInmueble/{InmuebleID}/{CaracteristicaID}")]
        public async Task<ActionResult<Caracteristica>> DeleteCaracteristicaInmueble(int InmuebleID, int CaracteristicaID)
        {
            var _caracInm = _context.CaracteristicaInmuebles.FirstOrDefault( ci => ci.InmuebleID == InmuebleID && ci.CaracteristicaID == CaracteristicaID);

            if (_caracInm == null)
            {
                return NotFound();

            }
            _context.CaracteristicaInmuebles.Remove(_caracInm);
            await _context.SaveChangesAsync();
            return Json(new { isSuccess = true, message = "Registro borrado satisfactoriamente." });

        }


        private bool CaracteristicaExists(int id)
        {
            return _context.CaracteristicaInmuebles.Any(e => e.CaracteristicaID == id);
        }
    }
}