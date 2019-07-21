using api_brick.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace api_brick.Data
{
    public class SeedRoles
    {
        public static IConfiguration Configuration { get; set; }
        public BrickDbContext _context;
        public async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            string[] roleNames = { "Admin", "Manager", "Client" };
            IdentityResult roleResult;

            _context = serviceProvider.GetRequiredService<BrickDbContext>();
            foreach (var roleName in roleNames)
            {
                //creating the roles and seeding them to the database
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            

            var poweruser = new ApplicationUser
            {
                UserName ="admin@admin.com",
                Email = "admin@admin.com"
            };

            string UserPassword = "Abcd@123";
            var _user = await UserManager.FindByEmailAsync(poweruser.Email);
            var client = _context.Clientes.Where(c => c.Email == poweruser.UserName).FirstOrDefault();

            if (client is null)
            {
                Cliente _cliente = new Cliente()
                {
                    Nombre = "admin",
                    Apellidos = "admin",
                    Email = poweruser.UserName,
                    FechaNacimiento = DateTime.UtcNow

                };

                _context.Clientes.Add(_cliente);
                await _context.SaveChangesAsync();

                if (_user == null)
                {
                    var createPowerUser = await UserManager.CreateAsync(poweruser, UserPassword);
                    if (createPowerUser.Succeeded)
                    {
                        await UserManager.AddToRoleAsync(poweruser, "Admin");
                    }

                }
            }
        }
    }
}
