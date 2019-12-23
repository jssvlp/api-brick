using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_brick.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private IHostingEnvironment _environment;

        public TestController(IHostingEnvironment environment)
        {
            _environment = environment;
        }
        [HttpGet]
        public async Task<string> Get()
        {
            try
            {
                string path = Path.Combine(_environment.ContentRootPath, "wwwroot"); //logfile.txt
                path = Path.Combine(path, "uploads");
                path = Path.Combine(path, "logfile.txt");
                using (StreamWriter writer = System.IO.File.AppendText(path))
                {
                    writer.WriteLine("log message");
                }

                return path;
            }
            catch (Exception ex)
            {

                return ex.Message.ToString();
            }
        }
    }
}