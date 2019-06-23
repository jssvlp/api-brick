using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using api_brick.Data;
using api_brick.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace api_brick.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly BrickDbContext _context;

        public AuthController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager,IConfiguration configuration,BrickDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this._configuration = configuration;
            _context = context;

        }

        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserInfo model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (model.Type == "Admin")
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                }
                
                if (result.Succeeded)
                {
                    return  await BuildTokenAsync(model);
                }
                else
                {
                    return BadRequest("Username or password invalid");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(userInfo.Email, userInfo.Password, isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return await BuildTokenAsync(userInfo);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return BadRequest(ModelState);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        private async Task<IActionResult> BuildTokenAsync(UserInfo userInfo)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SECRET_API_KEY"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var expiration = DateTime.UtcNow.AddDays(10);
            
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "https://constructoramejiapolanco.com",
                audience: "https://constructoramejiapolanco.com",
                claims: claims,
                expires: expiration,
                signingCredentials: creds 
                );


            var user = await _userManager.FindByEmailAsync(userInfo.Email);
            var roles = await _userManager.GetRolesAsync(user);
            if (userInfo.Type == "Client")
            {
                Cliente _cliente = (Cliente)_context.Clientes.Where(c => c.Email == userInfo.Email);
               

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = expiration,
                    user_info = new
                    {
                        NombreUsuario = _cliente.Nombre,
                        ApellidosUsuario = _cliente.Apellidos,
                        Email = _cliente.Email,
                        FechaNacimiento = _cliente.FechaNacimiento,
                        Roles = roles
                    }
                });
            }
            else
            {
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = expiration,
                    user_info = new
                    {
                        NombreUsuario = "admin",
                        ApellidosUsuario = "admin",
                        Email = userInfo.Email,
                        FechaNacimiento = "",
                        Roles = roles
                    }

                });
            }
           

           
        }


    }
}