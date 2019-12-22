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
        private IHostingEnvironment _hostingEnvironment;
        private IConfiguration _configuration;

        public UploadController(IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }

        [HttpPost, DisableRequestSizeLimit]
        public ActionResult UploadFile(string fileName)
        {
            try
            {
                var file = Request.Form.Files[0];
                string folderName = "Recursos";
                string rootPath = _configuration["ApplicationSettings:PathForPictures"];
                string newPath = Path.Combine(rootPath, folderName);
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }
                if (file.Length > 0)
                {
                    string file_name = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    string fullPath = Path.Combine(newPath, file_name);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                return Ok(new {success = true, message ="Upload success" });
            }
            catch (System.Exception ex)
            {
                return Ok(new { success = false, message = "Upload Failed: " + ex.Message });
            }
        }
    }
}