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

        private IHostingEnvironment _environment;
        public UploadController(IHostingEnvironment environment)
        {
            _environment = environment;
        }
        [HttpPost()]
        public async Task<string> Upload([FromForm] IFormFile file)
        {
            try
            {
                string fName = file.FileName;
                string path = Path.Combine(_environment.ContentRootPath, "Images");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string fullPath = Path.Combine(path, file.FileName);


                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return file.FileName;
            }
            catch (Exception ex)
            {

                return ex.Message.ToString();
            }
        }
    }
}