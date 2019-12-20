using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_brick.Data;
using api_brick.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using api_brick.Tools;
using Microsoft.AspNetCore.Hosting;

namespace api_brick.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProyectosController : Controller
    {
        private readonly BrickDbContext _context;
        string pathForPictures;
        IConfiguration _configuration;
        IHostingEnvironment _env;

        public ProyectosController(BrickDbContext context, IConfiguration configuration, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
            _configuration = configuration;
            this.pathForPictures = configuration["ApplicationSettings:PathForPictures"];

        }

        // GET: api/Proyectos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proyecto>>> GetProyecto()
        {
            return await _context.Proyecto.Include(i =>i.Imagenes).ToListAsync();
        }

        // GET: api/Proyectos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Proyecto>> GetProyecto(int id)
        {
            var proyecto = await _context.Proyecto.Include(i =>i.Imagenes).Include(x => x.Inmuebles).FirstOrDefaultAsync(x => x.ProyectoID == id);

            if (proyecto == null)
            {
                return NotFound();
            }

            return proyecto;
        }

        // PUT: api/Proyectos/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutProyecto(int id, Proyecto proyecto, string img)
        {
            if (id != proyecto.ProyectoID)
            {
                return BadRequest();
            }

            //IMG

            string URL = "";
            var url = proyecto.ImgURL.Split("\\");
            if (url != null)
            {
                URL = url[url.Length - 1];
            }
            else
            {
                URL = proyecto.ImgURL;
            }
            proyecto.ImgURL = URL;

            //PDF
            string PDF = "";

            if (proyecto.DocumentoResumenPdf != null)
            {
                var pdf = proyecto.DocumentoResumenPdf.Split("\\");
                if (pdf != null)
                {
                    PDF = pdf[pdf.Length - 1];
                }
                else
                {
                    PDF = proyecto.DocumentoResumenPdf;
                }
                proyecto.DocumentoResumenPdf = PDF;
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

            return Ok();
        }

        [Route("SaveFile")]
        [HttpPost()]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> SaveFile(string fileName)
        {
            try
            {

                foreach (var file2 in Request.Form.Files.ToList())
                {

                    if (!string.IsNullOrEmpty(file2?.FileName))
                    {

                        var dir = this.pathForPictures +"Recursos";

                        if (!Directory.Exists(dir))
                        {
                            Directory.CreateDirectory(dir);
                        }

                        var filePath = Path.Combine(dir, file2.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            await file2.CopyToAsync(stream);
                        }

                    }

                }
            }
            catch (Exception e)
            {
                return Ok(new { statusCode = 500,status = "failure", message = e.Message});
            }

            return Ok(new { statusCode = 200, status = "success", message ="archivo subido correctamente"});

        }

        [Route("SaveFilePDF")]
        [HttpPost()]
        public async Task<IActionResult> SaveFile2(string fileName)
        {
            try
            {

                foreach (var file2 in Request.Form.Files.ToList())
                {

                    if (!string.IsNullOrEmpty(file2?.FileName))
                    {
                        var dir = this.pathForPictures+"/PDF";


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
                return Ok(new { statusCode = 500, status = "failure", message = e.Message });
            }

            return Ok(new { statusCode = 200, status = "success", message = "archivo subido correctamente" });

        }

        //POST: api/Proyectos/imagenes
        [HttpPost]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> ImagenesProyecto(Proyecto proyecto)
        {
            Proyecto _proyecto = await  _context.Proyecto.FindAsync(proyecto.ProyectoID);

            if (_proyecto != null)
            {
                _proyecto.Imagenes = proyecto.Imagenes;
                _context.Entry(_proyecto).State = EntityState.Modified;
      
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return Ok(_proyecto.Imagenes);
            }
            return BadRequest();
        }
        // POST: api/Proyectos
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Proyecto>> PostProyecto(Proyecto proyecto)
        {
            var _proyecto = _context.Proyecto.FirstOrDefault(c => c.NombreProyecto == proyecto.NombreProyecto);
            var _images = proyecto.Imagenes;
            if (_proyecto == null)
            {
                var url = proyecto.ImgURL.Split("\\");
                string URL = url[url.Length - 1];
                proyecto.ImgURL = URL;

                if (proyecto.DocumentoResumenPdf != null)
                {
                    var urlPdf = proyecto.DocumentoResumenPdf.Split("\\");
                    string URLpdf = urlPdf[urlPdf.Length - 1];
                    proyecto.DocumentoResumenPdf = URLpdf;
                }
               

                _context.Proyecto.Add(proyecto);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetProyecto", new { id = proyecto.ProyectoID }, proyecto);
            }
            return null;
        }

        // DELETE: api/Proyectos/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Proyecto>> DeleteProyecto(int id)
        {
            var proyecto = await _context.Proyecto.FindAsync(id);
            if (proyecto == null)
            {
                return NotFound();
            }
            var file = Path.Combine(this.pathForPictures, "Recursos/" + proyecto.ImgURL);
            if (System.IO.File.Exists(file))
                System.IO.File.Delete(file);

            var file2 = Path.Combine(this.pathForPictures, "PDF/" + proyecto.DocumentoResumenPdf);
            if(System.IO.File.Exists(file2))
                System.IO.File.Delete(file2);

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
