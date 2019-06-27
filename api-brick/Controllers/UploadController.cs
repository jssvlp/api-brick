using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace api_brick.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        string pathForPictures;

        public UploadController(IConfiguration configuration) {

            this.pathForPictures = configuration["ApplicationSettings:PathForPictures"];
        }
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> UploadAsync(string fileName)
        {
            /* try
             {
                 var file = Request.Form.Files[0];
                 var folderName = Path.Combine("Resources", "Images");
                 var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                 if (file.Length > 0)
                 {
                     var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                     var fullPath = Path.Combine(pathToSave, fileName);
                     var dbPath = Path.Combine(folderName, fileName);

                     using (var stream = new FileStream(fullPath, FileMode.Create))
                     {
                         file.CopyTo(stream);
                     }

                     return Ok(new { dbPath });
                 }
                 else
                 {
                     return BadRequest();
                 }
             }
             catch (Exception ex)
             {
                 return StatusCode(500, "Internal server error");
             }*/

            try
            {

                foreach (var file2 in Request.Form.Files.ToList())
                {

                    if (!string.IsNullOrEmpty(file2?.FileName))
                    {

                        var dir = Path.Combine(this.pathForPictures, "Recursos/Imagenes");

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
    }
}