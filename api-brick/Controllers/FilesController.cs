using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using api_brick.Data;
using api_brick.Models;
using api_brick.Tools;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_brick.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly string[] ACCEPTED_FILE_TYPES = new[] { ".jpg", ".jpeg", ".png" };
        private readonly IHostingEnvironment _environment;
        private BrickDbContext _context;

        public FilesController(IHostingEnvironment environment, BrickDbContext context)
        {
            _environment = environment;
            _context = context;
        }


        //USE THIS ROUTE FOR ALL DOCUMENTS UPLOAD EXCEPT PROJECT IMAGES AND PDF PROJECT
        [HttpPost]
        [Route("/type/{uploadType}")]
        public async Task<IActionResult> Upload(IFormFile filesData,int projectId, string uploadType, int id)
        {
            try
            {
                if (filesData == null) return BadRequest("Null File");
                if (filesData.Length == 0)
                {
                    return BadRequest("Empty File");
                }

                if (filesData.Length > 10 * 1024 * 1024) return BadRequest("Max file size exceeded.");

                if (!ACCEPTED_FILE_TYPES.Any(s => s == Path.GetExtension(filesData.FileName).ToLower())) return BadRequest("Invalid file type.");

                var uploadFilesPath = Path.Combine(_environment.ContentRootPath, "uploads");

                uploadFilesPath = Path.Combine(uploadFilesPath, uploadType);
                
                if (!Directory.Exists(uploadFilesPath))
                    Directory.CreateDirectory(uploadFilesPath);

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(filesData.FileName);

                var  filePath = Path.Combine(uploadFilesPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await filesData.CopyToAsync(stream);
                }


               
                if (uploadType == "Recursos")
                {
                    var clasof = "Proyecto";
                    GenericRepository<Proyecto> repository = new GenericRepository<Proyecto>(_context);

                    Proyecto proyecto = repository.Find(p => p.ProyectoID == id).FirstOrDefault();
                    proyecto.ImgURL = fileName;

                    repository.Edit(proyecto);
                    repository.Save();
                }
              

                return Ok(new { status = "success" });
            }
            catch (Exception ex)
            {
                return Ok(new { status = "failure" ,message = ex.Message.ToString()});
            }
        }


    }
}