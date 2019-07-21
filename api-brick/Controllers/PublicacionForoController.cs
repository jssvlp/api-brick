using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using api_brick.Data;
using api_brick.Models;
using api_brick.Tools;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace api_brick.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PublicacionForoController : Controller
    {
        private readonly BrickDbContext _context;
        IConfiguration _configuration;
        IHostingEnvironment _env;
        public PublicacionForoController(BrickDbContext context, IConfiguration configuration, IHostingEnvironment env)
        {
            _context = context;
            _configuration = configuration;
            _env = env;
        }

        // GET: api/PublicacionForo

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicacionForo>>> GetPublicacion()
        {
            return await _context.PublicacionesForos.ToListAsync();
        }

        // GET: api/PublicacionForo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicacionForo>> GetPublicacion(int id)
        {

            var publicacion = await _context.PublicacionesForos.Include(x => x.Usuario).Include(x => x.CometariosForos).SingleOrDefaultAsync(x => x.PublicacionID == id);

            if (publicacion == null)
            {
                return NotFound();
            }

            return publicacion;
        }

        [Route("GetTemas/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicacionForo>>> GetPublicacionC(int id)
        {

            var publicacion = await _context.PublicacionesForos.Where(x => x.TemaID == id).Include(x => x.Usuario).ToListAsync();

            if (publicacion == null)
            {
                return NotFound();
            }

            return publicacion;
        }


        // PUT: api/PublicacionForo/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutPublicacion(int id, PublicacionForo publicacion)
        {
            if (id != publicacion.PublicacionID)
            {
                return BadRequest();
            }

            string URL = "";
            var url = publicacion.URLImagen.Split("\\");
            if (url != null)
            {
                URL = url[url.Length - 1];
            }
            else
            {
                URL = publicacion.URLImagen;
            }
            publicacion.URLImagen = URL;

            _context.Entry(publicacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublicacionExists(id))
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> SaveFile(string fileName)
        {
            try
            {

                foreach (var file2 in Request.Form.Files.ToList())
                {

                    if (!string.IsNullOrEmpty(file2?.FileName))
                    {
                        var dirLocal = _env.ContentRootPath;

                        var dir = Path.Combine(dirLocal, @"Resources\Ftpfiles");

                        if (!Directory.Exists(dir))
                        {
                            Directory.CreateDirectory(dir);
                        }

                        var path = Path.Combine(dir, file2.FileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await file2.CopyToAsync(fileStream);
                        }


                        var dirFtp = "Foro/";
                        FtpUploader ftp = new FtpUploader(_configuration);
                        ftp.UploadFile(dirFtp, path, file2.FileName);

                    }

                }
            }
            catch (Exception e)
            {

            }

            return Ok();

        }

        // POST: api/PublicacionForo
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<PublicacionForo>> PostPublicacion(PublicacionForo publicacion)
        {
            if (publicacion.URLImagen != null)
            {
                var url = publicacion.URLImagen.Split("\\");
                string URL = url[url.Length - 1];
                publicacion.URLImagen = URL;
            }
            _context.PublicacionesForos.Add(publicacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPublicacion", new { id = publicacion.PublicacionID }, publicacion);
        }

        // DELETE: api/PublicacionForo/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<PublicacionForo>> DeletePublicacion(int id)
        {
            var publicacion = await _context.PublicacionesForos.FindAsync(id);
            if (publicacion == null)
            {
                return NotFound();
            }
            //var dir = _env.co
            //var file = Path.Combine("C:/Users/pjms_/OneDrive/Desktop/UserBRICKFrontend/src/assets", "Post/" + publicacion.URLImagen);
            //if (System.IO.File.Exists(file))
            //    System.IO.File.Delete(file);
            _context.PublicacionesForos.Remove(publicacion);
            await _context.SaveChangesAsync();

            return publicacion;
        }

        private bool PublicacionExists(int id)
        {
            return _context.PublicacionesForos.Any(e => e.PublicacionID == id);
        }

    }
}