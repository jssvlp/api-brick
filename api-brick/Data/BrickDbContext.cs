﻿using api_brick.Models;
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
        public DbSet<CaracteristicaInmueble> CaracteristicaInmuebles { get; set;}
        public DbSet<Caracteristica_Inmueble> Caracteristica_Inmuebles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
            .UseMySql(@"Server=localhost;database=brick;user=root;pwd=;");
    }
}
