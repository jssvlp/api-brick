using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using api_brick.Data;
using api_brick.Models;
using api_brick.Requests;
using api_brick.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
        private static Random random = new Random();

        public AuthController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager,IConfiguration configuration,BrickDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this._configuration = configuration;
            _context = context;

        }


        [Route("password/reset")]
        [HttpPost]
        public async Task<ActionResult> ResetPasswod(PasswordChangeRequest passwordResetRequest)
        {
            PasswordReset passwordReset = isTokenValid(passwordResetRequest.RecoveryToken);
            if (passwordReset == null)
            {
                return Ok(new { status = "failure", message = "Token invalido" });
            }

            var _user = await _userManager.FindByIdAsync(passwordResetRequest.UserId);
  
            var _result = await _userManager.ResetPasswordAsync(_user, passwordReset.UserRecoveryToken, passwordResetRequest.Password);

            if (!_result.Succeeded)
            {
                return Ok(new { status = "failure", message = "Hubo un error al intentar cambiar su contraseña" });
            }


            _context.PasswordRests.Remove(passwordReset);
            await _context.SaveChangesAsync();

            return Ok(new { status = "success", message = "Contraseña cambiada, proceda a iniciar sesión con su nueva contraseña." });

        }

        [Route("password/validate")]
        [HttpPost]
        public async Task<ActionResult> validateToken(PasswordReset passwordReset)
        {
            PasswordReset valid = isTokenValid(passwordReset.RecoveryToken);
            if(valid is null)
            {
                return Ok(new { status = "failure", message = "Datos inválidos, no es posible recuperar tu contraseña." });
            }
            return Ok(new { status = "success", message = "Proceda a cambiar su nueva contraseña", user = valid.UserId });
        }

        [Route("password/request")]
        [HttpPost]
        public async Task<ActionResult> RequestPasswordReset(UserInfo userinfo)
        {
            var _user =  await _userManager.FindByEmailAsync(userinfo.Email);
            if (_user is null) {
                return Ok(new { status = "failure", message = "No existe un usuario registrado con el correo provisto."});
            }
            var userRecoveryToken = await _userManager.GeneratePasswordResetTokenAsync(_user);
            string shortToken = RandomString(16);

            PasswordReset password_reset = new PasswordReset();
            DateTime now = DateTime.Now;
            password_reset.RecoveryToken = shortToken;
            password_reset.UserRecoveryToken = userRecoveryToken;
            password_reset.UserId = _user.Id;
            password_reset.RequestDateTime = now;

            _context.Add(password_reset);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return Ok(new { status = "failure", message = ex.InnerException.Message });
            }

            Email mail = new Email();
            mail.Correo = _user.Email;
            mail.Subject = "Solicitud de nueva contraseña";
           
            EmailService emailService = new EmailService(_configuration);

            await emailService.SendResetToken(mail,shortToken);
            
            return Ok(new { status = "success", message = "Te hemos enviado un correo electrónico con la información necesaria para cambiar tu contraseña." });

        }

        private PasswordReset isTokenValid(string token)
        {
            PasswordReset reset = _context.PasswordRests.Where(r => r.RecoveryToken == token).FirstOrDefault();
            if (reset is null)
            {
                return null;
            }
            if ((DateTime.Now - reset.RequestDateTime).TotalDays > 1)
            {
                return null;
            }

            return reset;
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
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
                else
                {
                    await _userManager.AddToRoleAsync(user, "Client");
                }
                
                if (result.Succeeded)
                {
                    return  await BuildTokenAsync(model);
                }
                else
                {
                    return Ok(new {
                        status = "error",
                        message = "Usuario o contraseña inválidos",
                        errors = result.Errors,
                        model = model
                    });
                }
            }
            else
            {
                return Ok(new
                {
                    status = "error",
                    message = "Datos inválidos",
                    errors = ""
                });
            }

        }


        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout([FromBody] string token)
        {
            
            return Ok();
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
                    return Ok(new
                    {
                        status = "error",
                        message = "Usuario o contraseña incorrectos"
                    });
                }
            }
            else
            {
                return Ok(new
                {
                    status = "error",
                    message = "Usuario o contraseña incorrectos"
                });
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


            var expiration = DateTime.UtcNow.AddHours(2);
            
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "https://constructoramejiapolanco.com",
                audience: "https://constructoramejiapolanco.com",
                claims: claims,
                expires: expiration,
                signingCredentials: creds 
                );


            var user = await _userManager.FindByEmailAsync(userInfo.Email);
            IList<string> roles = await _userManager.GetRolesAsync(user);


            var role = roles.First();
            Cliente _cliente = (Cliente)_context.Clientes.Where(c => c.Email == userInfo.Email).FirstOrDefault();
            if (_cliente == null)
            {
                _cliente = new Cliente();
                _cliente.Nombre = userInfo.Username;
                _cliente.Email = userInfo.Email;
                _cliente.FechaNacimiento = DateTime.UtcNow;
                _cliente.Nombre = userInfo.Username;

                _context.Clientes.Add(_cliente);

                _context.SaveChanges();
            }
            if (role != "Admin")
            {
                return Ok(new
                {
                    status = "success",
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = expiration,
                    user_info = new
                    {
                        usuarioID = _cliente.ClienteID,
                        NombreUsuario = _cliente.Nombre,
                        ApellidosUsuario = _cliente.Apellidos,
                        Email = _cliente.Email,
                        FechaNacimiento = _cliente.FechaNacimiento,
                        roleId = 2,
                        Roles = roles
                    }
                });
            }
            else
            {
                return Ok(new
                {
                    status = "success",
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = expiration,
                    user_info = new
                    {
                        usuarioID = _cliente.ClienteID,
                        NombreUsuario = _cliente.Nombre,
                        ApellidosUsuario = _cliente.Apellidos,
                        Email =_cliente.Email,
                        FechaNacimiento = _cliente.FechaNacimiento,
                        roleId = 1,
                        Roles = roles
                    }

                });
            }
           

           
        }


    }
}