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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace api_brick.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ClientesController : Controller
    {
        private readonly BrickDbContext _context;

        public ClientesController(BrickDbContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Cliente>> GetUsuario(int id)
        {
            var usuario = await _context.Clientes.
                Include(x => x.Solicitud).
                    ThenInclude(t => t.ServicioSolicituds).
                        ThenInclude(t => t.Servicio).
                            ThenInclude(t => t.ServicioSolicituds).
                                ThenInclude(t => t.Estado).
                Include(x => x.Solicitud).
                    ThenInclude(t => t.VisitaAgendadas).
                        FirstOrDefaultAsync(x => x.ClienteID == id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuarios/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.ClienteID)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExist(id))
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

        


       
        // POST: api/Clientes
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostUsuario(Cliente cliente)
        {
            var _cliente = _context.Clientes.FirstOrDefault(c => c.Email == cliente.Email);
            if (_cliente == null) {
                _context.Clientes.Add(cliente);
                //CREATE USER


                await _context.SaveChangesAsync();
                return Ok(new
                {
                    status = "success",
                    message = "Registro insertado correctamente",
                    cliente = cliente
                });
            }

            return Ok(new
            {
                status = "error",
                message = "Ya existe un cliente registrado con esta dirección de correo."
            });

            
        }


        private bool ClienteExist(int id)
        {
            return _context.Clientes.Any(e => e.ClienteID == id);
        }
        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Cliente>> DeleteUsuario(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return cliente;
        }

       

      

       

      
    }
}
