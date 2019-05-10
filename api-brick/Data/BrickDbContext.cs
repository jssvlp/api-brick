using api_brick.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Data
{
    public class BrickDbContext : DbContext
    {

        public DbSet<Proyecto> Proyecto { get; set; }
        public DbSet<Inmueble> Inmueble { get; set; }
       
        public DbSet<Caracteristica> Caracteristica { get; set;}
        public DbSet<CaracteristicaInmueble> CaracteristicaInmuebles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
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


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
            .UseMySql(@"Server=localhost;database=brick;user=root;pwd=;");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            //much to much relationship for caracteristicas and imbuebles
            modelBuilder.Entity<CaracteristicaInmueble>()
            .HasKey(bc => new { bc.CaracteristicaID, bc.InmuebleID });
            modelBuilder.Entity<CaracteristicaInmueble>()
                .HasOne(bc => bc.Inmueble)
                .WithMany(b => b.CaracteristicasInmuebles)
                .HasForeignKey(bc => bc.InmuebleID);
            modelBuilder.Entity<CaracteristicaInmueble>()
                .HasOne(bc => bc.Caracteristica)
                .WithMany(c => c.CaracteristicasInmuebles)
                .HasForeignKey(bc => bc.CaracteristicaID);


            //SEEDS
            modelBuilder.Entity<Estado>().HasData(new Estado {EstadoId = 1, EstadoNombre = "Activo" },new Estado {EstadoId = 2, EstadoNombre = "Pendiente" }, new Estado { EstadoId= 3, EstadoNombre = "Finalizado"}, new Estado {EstadoId = 4, EstadoNombre = "Inactivo" }, new Estado {EstadoId = 5, EstadoNombre = "Aprobada" },
                 new Estado { EstadoId = 6, EstadoNombre = "Rechazada" });
            modelBuilder.Entity<Rol>().HasData(new Rol {RoleId = 1, RoleNombre = "Admin" }, new Rol { RoleId = 2, RoleNombre = "Usuarios" });
            modelBuilder.Entity<Usuario>().HasData(new Usuario {UsuarioID =1, NombreUsuario = "Admin", ApellidosUsuario = "Admin", CorreoUsuario = "admin@admin.com", RoleId = 1 , FechaNacimiento = DateTime.Today, Contraseña = "1234567"});

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
        }
    }
}
