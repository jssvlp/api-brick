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
        public DbSet<Ubicacion> Ubicacion { get; set; }
        public DbSet<Caracteristica> Caracteristica { get; set;}
        public DbSet<CaracteristicaInmueble> CaracteristicaInmuebles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<ServicioSolicitud> ServicioSolicituds { get; set; }
        public DbSet<SolicitudServicio> SolicitudServicios { get; set; }
        public DbSet<VisitasAgendada> VisitasAgendadas { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet <ComentarioForo> CometarioForos { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<PublicacionDelForo> PublicacionDelForos { get; set; }
        public DbSet<TemasForo> TemasForos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
            .UseMySql(@"Server=localhost;database=brick;user=root;pwd=;");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

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

            modelBuilder.Entity<ServicioSolicitud>()
            .HasKey(bc => new { bc.ServicioID, bc.SolicitudID });
            modelBuilder.Entity<ServicioSolicitud>()
                .HasOne(bc => bc.Servicio)
                .WithMany(b => b.servicioSolicituds)
                .HasForeignKey(bc => bc.ServicioID);
            modelBuilder.Entity<ServicioSolicitud>()
                .HasOne(bc => bc.SolicitudServicio)
                .WithMany(c => c.servicioSolicituds)
                .HasForeignKey(bc => bc.SolicitudID);
        }
    }
}
