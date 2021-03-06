﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api_brick.Data;

namespace api_brick.Migrations
{
    [DbContext(typeof(BrickDbContext))]
    [Migration("20190223205527_CaracteristicaInmuebleMigration")]
    partial class CaracteristicaInmuebleMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("api_brick.Models.Caracteristica", b =>
                {
                    b.Property<int>("CaracteristicaID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CarDescripcion");

                    b.Property<string>("CarNombre");

                    b.HasKey("CaracteristicaID");

                    b.ToTable("Caracteristica");
                });

            modelBuilder.Entity("api_brick.Models.CaracteristicaInmueble", b =>
                {
                    b.Property<int>("CaracteristicaID");

                    b.Property<int>("InmuebleID");

                    b.HasKey("CaracteristicaID", "InmuebleID");

                    b.HasIndex("InmuebleID");

                    b.ToTable("CaracteristicaInmuebles");
                });

            modelBuilder.Entity("api_brick.Models.Inmueble", b =>
                {
                    b.Property<int>("InmuebleID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DescripcionInmueble");

                    b.Property<int>("Precio");

                    b.Property<int>("ProyectoID");

                    b.HasKey("InmuebleID");

                    b.HasIndex("ProyectoID");

                    b.ToTable("Inmueble");
                });

            modelBuilder.Entity("api_brick.Models.Proyecto", b =>
                {
                    b.Property<int>("ProyectoID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Direccion");

                    b.Property<DateTime>("FechaTerminacion");

                    b.Property<string>("ImgURL");

                    b.Property<string>("NombreProyecto");

                    b.Property<int>("UbicacionID");

                    b.HasKey("ProyectoID");

                    b.HasIndex("UbicacionID");

                    b.ToTable("Proyecto");
                });

            modelBuilder.Entity("api_brick.Models.Ubicacion", b =>
                {
                    b.Property<int>("UbicacionID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Ciudad");

                    b.Property<string>("NombreUbicacion");

                    b.HasKey("UbicacionID");

                    b.ToTable("Ubicacion");
                });

            modelBuilder.Entity("api_brick.Models.CaracteristicaInmueble", b =>
                {
                    b.HasOne("api_brick.Models.Caracteristica", "Caracteristica")
                        .WithMany("CaracteristicasInmbles")
                        .HasForeignKey("CaracteristicaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("api_brick.Models.Inmueble", "Inmueble")
                        .WithMany("CaracteristicasInmbles")
                        .HasForeignKey("InmuebleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("api_brick.Models.Inmueble", b =>
                {
                    b.HasOne("api_brick.Models.Proyecto", "Proyecto")
                        .WithMany("Inmuebles")
                        .HasForeignKey("ProyectoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("api_brick.Models.Proyecto", b =>
                {
                    b.HasOne("api_brick.Models.Ubicacion", "Ubicacion")
                        .WithMany()
                        .HasForeignKey("UbicacionID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
