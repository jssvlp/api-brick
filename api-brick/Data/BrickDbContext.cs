using api_brick.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Data
{
    public class BrickDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Caracteristica> Caracteristica { get; set; }
        public DbSet<Proyecto> Proyecto { get; set; }
        public DbSet<Inmueble> Inmueble { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<ServicioSolicitud> ServicioSolicituds { get; set; }
        public DbSet<Solicitud> Solicitud { get; set; }
        public DbSet<VisitaAgendada> VisitasAgendadas { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet <ComentarioForo> CometarioForos { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<PublicacionForo> PublicacionesForos { get; set; }
        public DbSet<TemasForo> TemasForos { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Peticion> Peticiones { get; set; }
        public DbSet<CaracteristicaProyecto> CaracteristicaProyectos { get; set; }
        public DbSet<DatoGenerico> DatosGenericos { get; set; }
        public DbSet<ImagenProyecto> ImagenesProyectos { get; set; }
        public DbSet<Tasacion> Tasacions { get; set; }
        public DbSet<PasswordReset> PasswordRests { get; set; }



        public BrickDbContext(DbContextOptions<BrickDbContext> options): base(options)
        {

        }
       

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            //SEEDS
            modelBuilder.Entity<Estado>().HasData(new Estado {EstadoID = 1, EstadoNombre = "Activo" },new Estado {EstadoID = 2, EstadoNombre = "Pendiente" }, new Estado { EstadoID= 3, EstadoNombre = "Finalizado"}, new Estado {EstadoID = 4, EstadoNombre = "Inactivo" }, new Estado {EstadoID = 5, EstadoNombre = "Aprobada" },
                 new Estado { EstadoID = 6, EstadoNombre = "Rechazada" });
            
            //modelBuilder.Entity<Rol>().HasData(new Rol {RoleId = 1, RoleNombre = "Admin" }, new Rol { RoleId = 2, RoleNombre = "Usuarios" });
            //modelBuilder.Entity<Usuario>().HasData(new Usuario {UsuarioID =1, NombreUsuario = "Admin", ApellidosUsuario = "Admin", CorreoUsuario = "admin@admin.com", RoleId = 1 , FechaNacimiento = DateTime.Today, Contraseña = "1234567"});

            //Much to much relationship for servicios and solicitudes
            modelBuilder.Entity<ServicioSolicitud>()
            .HasKey(bc => new { bc.ServicioID, bc.SolicitudID });
            modelBuilder.Entity<ServicioSolicitud>()
                .HasOne(bc => bc.Servicio)
                .WithMany(b => b.ServicioSolicituds)
                .HasForeignKey(bc => bc.ServicioID);
            modelBuilder.Entity<ServicioSolicitud>()
                .HasOne(bc => bc.Solicitud)
                .WithMany(c => c.ServicioSolicituds)
                .HasForeignKey(bc => bc.SolicitudID);


            //much to much relationship for caracteristicas and projects
            modelBuilder.Entity<CaracteristicaProyecto>()
            .HasKey(bc => new { bc.CaracteristicaID, bc.ProyectoID });
            modelBuilder.Entity<CaracteristicaProyecto>()
                .HasOne(bc => bc.Proyecto)
                .WithMany(b => b.CaracteristicasProyectos)
                .HasForeignKey(bc => bc.ProyectoID);
            modelBuilder.Entity<CaracteristicaProyecto>()
                .HasOne(bc => bc.Caracteristica)
                .WithMany(c => c.CaracteristicasProyectos)
                .HasForeignKey(bc => bc.CaracteristicaID);
        }
    }
}
