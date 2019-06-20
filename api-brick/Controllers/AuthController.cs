using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_brick.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_brick.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private BrickDbContext context;

        public AuthController(BrickDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return context.Users.Select(u => u.UserName).ToArray();
        }
    }
}