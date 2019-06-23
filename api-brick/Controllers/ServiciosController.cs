using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_brick.Data;
using api_brick.Models;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace api_brick.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {
        private readonly BrickDbContext _context;
        string pathForPictures;

        public ServiciosController(BrickDbContext context, IConfiguration configuration)
        {
            _context = context;
            this.pathForPictures = configuration["ApplicationSettings:PathForPictures"];
        }

        // GET: api/Servicios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Servicio>>> GetServicios()
        {
            return await _context.Servicios.ToListAsync();
        }

        // GET: api/Servicios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Servicio>> GetServicio(int id)
        {
            var servicio = await _context.Servicios.FindAsync(id);

            if (servicio == null)
            {
                return NotFound();
            }

            return servicio;
        }

        // PUT: api/Servicios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServicio(int id, Servicio servicio)
        {
            if (id != servicio.ServicioID)
            {
                return BadRequest();
            }
            string URL = "";
            var url = servicio.ImgURL.Split("\\");
            if (url != null)
            {
                URL = url[url.Length - 1];
            }
            else
            {
                URL = servicio.ImgURL;
            }
           
            servicio.ImgURL = URL;
            _context.Entry(servicio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicioExists(id))
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

        [Route("SaveFile")]
        [HttpPost()]
        public async Task<IActionResult> SaveFile(string fileName)
        {
            try
            {

                foreach (var file2 in Request.Form.Files.ToList())
                {

                    if (!string.IsNullOrEmpty(file2?.FileName))
                    {
                        var dir = Path.Combine(this.pathForPictures, "Servicio/");

                        if (!Directory.Exists(dir))
                        {
                            Directory.CreateDirectory(dir);
                        }

                        var path = Path.Combine(dir, file2.FileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await file2.CopyToAsync(fileStream);
                        }

                    }

                }
            }
            catch (Exception e)
            {

            }

            return Ok();

        }

        // POST: api/Servicios
        [HttpPost]
        public async Task<ActionResult<Servicio>> PostServicio(Servicio servicio)
        {
            var _servicio = _context.Servicios.FirstOrDefault(c => c.NombreServicio == servicio.NombreServicio);
            if (_servicio == null)
            {
                var url = servicio.ImgURL.Split("\\");
                string URL = url[url.Length - 1];
                servicio.ImgURL = URL;
                _context.Servicios.Add(servicio);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetServicio", new { id = servicio.ServicioID }, servicio);
            }
            return null;
        }

        // DELETE: api/Servicios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Servicio>> DeleteServicio(int id)
        {
            var servicio = await _context.Servicios.FindAsync(id);
            if (servicio == null)
            {
                return NotFound();
            }
            var file = Path.Combine(this.pathForPictures, "Servicio/" + servicio.ImgURL);
            if (System.IO.File.Exists(file))
                System.IO.File.Delete(file);
            _context.Servicios.Remove(servicio);
            await _context.SaveChangesAsync();

            return servicio;
        }

        private bool ServicioExists(int id)
        {
            return _context.Servicios.Any(e => e.ServicioID == id);
        }
    }
}
