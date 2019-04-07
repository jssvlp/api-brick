using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_brick.Data;
using api_brick.Models;
using CryptoHelper;

namespace api_brick.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private readonly BrickDbContext _context;

        public UsuariosController(BrickDbContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.UsuarioID)
            {
                return BadRequest();
            }

            usuario.Contraseña = HashPassword(usuario.Contraseña);
            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        [HttpPost("logout/{accesToken}")]
        public async Task<ActionResult> Logout(string accesToken)
        {
            var _userLogged = await _context.Usuarios.FirstOrDefaultAsync(u => u.AuthToken == accesToken);
            if (_userLogged != null)
            {
                _userLogged.DestroyAccesToken();
                _context.Entry(_userLogged).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                    return Json(new { isSuccess = true, message = "User logout sussesfully." });

                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;

                }

            }
            else {
                return Json(new { isSuccess = false, message = "This User is not logged" });
            }
           

        }


        [HttpPost("login")]
        public async Task<ActionResult<Usuario>> Login(Usuario usuario)
        {
            var _user = ValidateCredentials(usuario.CorreoUsuario, usuario.Contraseña);
            if(_user!= null)
            {
                _user.SetAccessToken();
                _context.Entry(_user).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                    

                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;

                }
                return _user;
            }        
            else
                return Json(new { isSuccess = false, message = "Revise sus credenciales e intente nuevamente." });



        }
        // POST: api/Usuarios
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            var userRole = _context.Roles.FirstOrDefault(r => r.RoleNombre == "Usuarios");


            usuario.Contraseña = HashPassword(usuario.Contraseña);
            usuario.RoleId = userRole.RoleId;
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.UsuarioID }, usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public Usuario ValidateCredentials(string correo, string password)
        {
            Usuario _usuario = (Usuario) _context.Usuarios.FirstOrDefault(x => x.CorreoUsuario == correo);

            if (VerifyPassword(_usuario.Contraseña, password))
            {
                return _usuario;
            }

            return null;
        }

        // Method for hashing the password
        [ApiExplorerSettings(IgnoreApi = true)]
        public string HashPassword(string password)
        {
            return Crypto.HashPassword(password);
        }

        // Method to verify the password hash against the given password
        [ApiExplorerSettings(IgnoreApi = true)]
        public bool VerifyPassword(string hash, string password)
        {
            return Crypto.VerifyHashedPassword(hash, password);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.UsuarioID == id);
        }
    }
}
