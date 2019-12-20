using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using api_brick.Tools;
using Microsoft.AspNetCore.Hosting;
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
        IConfiguration _configuration;
        IHostingEnvironment _env;

        public UploadController(IConfiguration configuration, IHostingEnvironment env) {

            this.pathForPictures = configuration["ApplicationSettings:PathForPictures"];
            _configuration = configuration;
            _env = env;

        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> UploadAsync(string fileName)
        {
            try
            {

                foreach (var file2 in Request.Form.Files.ToList())
                {

                    if (!string.IsNullOrEmpty(file2?.FileName))
                    {

                        var dir = Path.Combine(this.pathForPictures, "Recursos");

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
                return StatusCode(500, "Internal server error."+e.Message);
            }

            return Ok(new { statusCode = 200, status = "success", message = "archivo subido correctamente" });

        }
    }
}