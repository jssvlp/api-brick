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
    [Migration("20190530205254_documentoresumenpdf")]
    partial class documentoresumenpdf
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("api_brick.Models.Blog", b =>
                {
                    b.Property<int>("BlogID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ImgURL");

                    b.Property<string>("TextoEntrada");

                    b.Property<DateTime>("TimeStampBlog");

                    b.Property<string>("TituloEntrada");

                    b.Property<DateTime>("UpdateAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("UsuarioID");

                    b.HasKey("BlogID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("blogs");
                });

            modelBuilder.Entity("api_brick.Models.Caracteristica", b =>
                {
                    b.Property<int>("CaracteristicaID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CarDescripcion");

                    b.Property<string>("CarNombre");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("TipoCarProyecto");

                    b.Property<DateTime>("UpdateAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("CaracteristicaID");

                    b.ToTable("caracteristicas");
                });

            modelBuilder.Entity("api_brick.Models.CaracteristicaProyecto", b =>
                {
                    b.Property<int>("CaracteristicaID");

                    b.Property<int>("ProyectoID");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<DateTime>("UpdateAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("CaracteristicaID", "ProyectoID");

                    b.HasIndex("ProyectoID");

                    b.ToTable("caracteristicas_proyectos");
                });

            modelBuilder.Entity("api_brick.Models.ComentarioForo", b =>
                {
                    b.Property<int>("ComentarioID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PublicacionID");

                    b.Property<string>("TextoComentario");

                    b.Property<DateTime>("TimeStampComment");

                    b.Property<string>("URLImagen");

                    b.Property<int>("UsuarioID");

                    b.HasKey("ComentarioID");

                    b.HasIndex("PublicacionID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("comentarios");
                });

            modelBuilder.Entity("api_brick.Models.DatoGenerico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion");

                    b.Property<string>("Key");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("datos_genericos");
                });

            modelBuilder.Entity("api_brick.Models.Estado", b =>
                {
                    b.Property<int>("EstadoID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("EstadoNombre");

                    b.Property<DateTime>("UpdateAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("EstadoID");

                    b.ToTable("estados");

                    b.HasData(
                        new
                        {
                            EstadoID = 1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EstadoNombre = "Activo",
                            UpdateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            EstadoID = 2,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EstadoNombre = "Pendiente",
                            UpdateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            EstadoID = 3,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EstadoNombre = "Finalizado",
                            UpdateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            EstadoID = 4,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EstadoNombre = "Inactivo",
                            UpdateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            EstadoID = 5,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EstadoNombre = "Aprobada",
                            UpdateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            EstadoID = 6,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EstadoNombre = "Rechazada",
                            UpdateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("api_brick.Models.ImagenProyecto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion");

                    b.Property<int>("ProyectoID");

                    b.Property<string>("Tipo");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("ProyectoID");

                    b.ToTable("imagenes_proyectos");
                });

            modelBuilder.Entity("api_brick.Models.Inmueble", b =>
                {
                    b.Property<int>("InmuebleID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("CantidadBanos");

                    b.Property<int>("CantidadHabitaciones");

                    b.Property<int>("CantidadParqueos");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("DescripcionInmueble");

                    b.Property<string>("Moneda");

                    b.Property<string>("NombreInmueble");

                    b.Property<int>("Precio");

                    b.Property<int>("ProyectoID");

                    b.Property<DateTime>("UpdateAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<decimal>("mts");

                    b.HasKey("InmuebleID");

                    b.HasIndex("ProyectoID");

                    b.ToTable("inmuebles");
                });

            modelBuilder.Entity("api_brick.Models.Like", b =>
                {
                    b.Property<int>("LikeID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("PublicacionID");

                    b.Property<DateTime>("UpdateAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("UsuarioID");

                    b.HasKey("LikeID");

                    b.HasIndex("PublicacionID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("likes");
                });

            modelBuilder.Entity("api_brick.Models.Peticion", b =>
                {
                    b.Property<int>("PeticionID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comentario");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Estado");

                    b.Property<DateTime?>("FechaCancelacion");

                    b.Property<DateTime?>("FechaSolicitada");

                    b.Property<string>("Motivo");

                    b.Property<int>("SolicitudID");

                    b.Property<string>("Tipo");

                    b.Property<DateTime>("UpdateAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("PeticionID");

                    b.HasIndex("SolicitudID");

                    b.ToTable("Peticiones");
                });

            modelBuilder.Entity("api_brick.Models.Proyecto", b =>
                {
                    b.Property<int>("ProyectoID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Direccion");

                    b.Property<string>("DocumentoResumenPdf");

                    b.Property<int>("Estado");

                    b.Property<DateTime>("FechaTerminacion");

                    b.Property<string>("ImgURL");

                    b.Property<string>("Latitude");

                    b.Property<string>("Longitude");

                    b.Property<string>("NombreProyecto");

                    b.Property<DateTime>("UpdateAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("ProyectoID");

                    b.ToTable("proyectos");
                });

            modelBuilder.Entity("api_brick.Models.PublicacionForo", b =>
                {
                    b.Property<int>("PublicacionID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Archivado");

                    b.Property<int>("TemaID");

                    b.Property<string>("TextoPublicacion");

                    b.Property<DateTime>("TimeStampForo");

                    b.Property<string>("TituloPublicacion");

                    b.Property<string>("URLImagen");

                    b.Property<DateTime>("UpdateAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("UsuarioID");

                    b.HasKey("PublicacionID");

                    b.HasIndex("TemaID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("publicaciones");
                });

            modelBuilder.Entity("api_brick.Models.Rol", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion");

                    b.Property<string>("RoleNombre");

                    b.HasKey("RoleId");

                    b.ToTable("roles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            RoleNombre = "Admin"
                        },
                        new
                        {
                            RoleId = 2,
                            RoleNombre = "Usuarios"
                        });
                });

            modelBuilder.Entity("api_brick.Models.Servicio", b =>
                {
                    b.Property<int>("ServicioID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("DescripcionServicio");

                    b.Property<string>("ImgURL");

                    b.Property<string>("NombreServicio");

                    b.Property<DateTime>("UpdateAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("ServicioID");

                    b.ToTable("servicios");
                });

            modelBuilder.Entity("api_brick.Models.ServicioSolicitud", b =>
                {
                    b.Property<int>("ServicioID");

                    b.Property<int>("SolicitudID");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("EstadoID");

                    b.Property<DateTime>("UpdateAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("ServicioID", "SolicitudID");

                    b.HasIndex("EstadoID");

                    b.HasIndex("SolicitudID");

                    b.ToTable("solicitudes_servicios");
                });

            modelBuilder.Entity("api_brick.Models.Solicitud", b =>
                {
                    b.Property<int>("SolicitudID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comentario");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<DateTime>("FechaServSol");

                    b.Property<DateTime>("FechaSol");

                    b.Property<DateTime>("UpdateAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("UsuarioID");

                    b.HasKey("SolicitudID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("solicitudes");
                });

            modelBuilder.Entity("api_brick.Models.TemasForo", b =>
                {
                    b.Property<int>("TemaID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("DescripcionTema");

                    b.Property<string>("NombreTema");

                    b.Property<DateTime>("UpdateAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("TemaID");

                    b.ToTable("temas_foros");
                });

            modelBuilder.Entity("api_brick.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApellidosUsuario");

                    b.Property<string>("AuthToken");

                    b.Property<string>("Contraseña");

                    b.Property<string>("CorreoUsuario");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<DateTime>("FechaNacimiento");

                    b.Property<string>("FirebaseCode");

                    b.Property<string>("NombreUsuario");

                    b.Property<int>("RoleId");

                    b.Property<DateTime>("UpdateAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("UsuarioID");

                    b.HasIndex("RoleId");

                    b.ToTable("usuarios");

                    b.HasData(
                        new
                        {
                            UsuarioID = 1,
                            ApellidosUsuario = "Admin",
                            Contraseña = "1234567",
                            CorreoUsuario = "admin@admin.com",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaNacimiento = new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Local),
                            NombreUsuario = "Admin",
                            RoleId = 1,
                            UpdateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("api_brick.Models.VisitaAgendada", b =>
                {
                    b.Property<int>("VisitaID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Descripcion");

                    b.Property<string>("Estado");

                    b.Property<DateTime>("Hora_Fin");

                    b.Property<DateTime>("Hora_Inicio");

                    b.Property<string>("Motivo");

                    b.Property<int?>("ProyectoID");

                    b.Property<int?>("SolicitudID");

                    b.Property<DateTime>("UpdateAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("VisitaID");

                    b.HasIndex("ProyectoID");

                    b.HasIndex("SolicitudID");

                    b.ToTable("visitas_agendadas");
                });

            modelBuilder.Entity("api_brick.Models.Blog", b =>
                {
                    b.HasOne("api_brick.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("api_brick.Models.CaracteristicaProyecto", b =>
                {
                    b.HasOne("api_brick.Models.Caracteristica", "Caracteristica")
                        .WithMany("CaracteristicasProyectos")
                        .HasForeignKey("CaracteristicaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("api_brick.Models.Proyecto", "Proyecto")
                        .WithMany("CaracteristicasProyectos")
                        .HasForeignKey("ProyectoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("api_brick.Models.ComentarioForo", b =>
                {
                    b.HasOne("api_brick.Models.PublicacionForo", "Publicacion")
                        .WithMany("CometariosForos")
                        .HasForeignKey("PublicacionID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("api_brick.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("api_brick.Models.ImagenProyecto", b =>
                {
                    b.HasOne("api_brick.Models.Proyecto", "Proyecto")
                        .WithMany("Imagenes")
                        .HasForeignKey("ProyectoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("api_brick.Models.Inmueble", b =>
                {
                    b.HasOne("api_brick.Models.Proyecto", "Proyecto")
                        .WithMany("Inmuebles")
                        .HasForeignKey("ProyectoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("api_brick.Models.Like", b =>
                {
                    b.HasOne("api_brick.Models.PublicacionForo", "Publicacion")
                        .WithMany("Likes")
                        .HasForeignKey("PublicacionID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("api_brick.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("api_brick.Models.Peticion", b =>
                {
                    b.HasOne("api_brick.Models.Solicitud", "Solicitud")
                        .WithMany()
                        .HasForeignKey("SolicitudID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("api_brick.Models.PublicacionForo", b =>
                {
                    b.HasOne("api_brick.Models.TemasForo", "TemasForo")
                        .WithMany("PublicacionesDelForo")
                        .HasForeignKey("TemaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("api_brick.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("api_brick.Models.ServicioSolicitud", b =>
                {
                    b.HasOne("api_brick.Models.Estado", "Estado")
                        .WithMany("ServicioSolicituds")
                        .HasForeignKey("EstadoID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("api_brick.Models.Servicio", "Servicio")
                        .WithMany("ServicioSolicituds")
                        .HasForeignKey("ServicioID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("api_brick.Models.Solicitud", "Solicitud")
                        .WithMany("ServicioSolicituds")
                        .HasForeignKey("SolicitudID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("api_brick.Models.Solicitud", b =>
                {
                    b.HasOne("api_brick.Models.Usuario", "Usuario")
                        .WithMany("Solicitud")
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("api_brick.Models.Usuario", b =>
                {
                    b.HasOne("api_brick.Models.Rol", "Role")
                        .WithMany("Usuarios")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("api_brick.Models.VisitaAgendada", b =>
                {
                    b.HasOne("api_brick.Models.Proyecto", "Proyecto")
                        .WithMany("VisitasAgendadas")
                        .HasForeignKey("ProyectoID");

                    b.HasOne("api_brick.Models.Solicitud", "Solicitud")
                        .WithMany("VisitaAgendadas")
                        .HasForeignKey("SolicitudID");
                });
#pragma warning restore 612, 618
        }
    }
}
