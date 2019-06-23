﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api_brick.Data;

namespace api_brick.Migrations
{
    [DbContext(typeof(BrickDbContext))]
    partial class BrickDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("api_brick.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

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

            modelBuilder.Entity("api_brick.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Apellidos");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Email");

                    b.Property<DateTime>("FechaNacimiento");

                    b.Property<string>("Nombre");

                    b.Property<int?>("RoleId");

                    b.Property<DateTime>("UpdateAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("ClienteID");

                    b.HasIndex("RoleId");

                    b.ToTable("clientes");
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

            modelBuilder.Entity("api_brick.Models.Tasacion", b =>
                {
                    b.Property<int>("TasacionID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Amenidades");

                    b.Property<DateTime>("AnoEstimado");

                    b.Property<int>("AntiguedadPromedio");

                    b.Property<int>("Area");

                    b.Property<int>("AreaConstruida");

                    b.Property<int>("AreaPiso");

                    b.Property<int>("AreaTotalSotano");

                    b.Property<string>("AreaVerde");

                    b.Property<string>("Armarios");

                    b.Property<string>("ArtefactosAdicionales");

                    b.Property<string>("AsesorNombre");

                    b.Property<string>("Banco");

                    b.Property<int>("BanoCompleto");

                    b.Property<int>("BanoParcial");

                    b.Property<string>("Banos");

                    b.Property<string>("CalentadorAgua");

                    b.Property<int>("CantidadPiso");

                    b.Property<int>("CapacidadCalentador");

                    b.Property<string>("Ciudad");

                    b.Property<string>("ClienteNombre");

                    b.Property<int>("Cocina");

                    b.Property<string>("CodicionInterna");

                    b.Property<int>("Comedor");

                    b.Property<string>("Comentarios");

                    b.Property<string>("ComentariosVentas");

                    b.Property<string>("ComparacionVecindario");

                    b.Property<string>("Conclusiones");

                    b.Property<string>("Condicion");

                    b.Property<string>("Condicion2");

                    b.Property<string>("Condicion3");

                    b.Property<string>("CondicionExterna");

                    b.Property<string>("CondicionFisica2");

                    b.Property<string>("CondicionFisica3");

                    b.Property<string>("CondicionesRestrictivas");

                    b.Property<string>("Configuracion");

                    b.Property<string>("ConstruccionTerminada");

                    b.Property<string>("CorreoCompania");

                    b.Property<int>("CostoMetroInmueble");

                    b.Property<int>("CostoMetroTerraza");

                    b.Property<int>("CuartoServicio");

                    b.Property<string>("Demanda");

                    b.Property<string>("DerechoPropiedad");

                    b.Property<string>("Descripcion2");

                    b.Property<string>("Descripcion3");

                    b.Property<string>("DescripcionInmueble");

                    b.Property<string>("DeseabilidadPropiedad");

                    b.Property<string>("Direccion");

                    b.Property<string>("Direccion2");

                    b.Property<string>("Direccion3");

                    b.Property<string>("DireccionConstructora");

                    b.Property<int>("DistanciaCiudad");

                    b.Property<int>("DistanciaComercio");

                    b.Property<int>("DistanciaEscuelaP");

                    b.Property<int>("DistanciaEscuelaS");

                    b.Property<int>("DistanciaTransporte");

                    b.Property<string>("DistribucionArq");

                    b.Property<string>("Dormitorios");

                    b.Property<int>("Entrada");

                    b.Property<string>("Estilo");

                    b.Property<string>("Estilo2");

                    b.Property<string>("Estilo3");

                    b.Property<string>("Estructura");

                    b.Property<DateTime>("Fecha");

                    b.Property<DateTime>("FechaDiaTasacion");

                    b.Property<DateTime>("FechaInspeccion");

                    b.Property<DateTime>("FechaVenta");

                    b.Property<DateTime>("FechaVenta2");

                    b.Property<DateTime>("FechaVenta3");

                    b.Property<string>("Fuente");

                    b.Property<string>("FuenteManualCosto");

                    b.Property<int>("Habitaciones");

                    b.Property<string>("InstalacionElectrica");

                    b.Property<int>("Lavanderia");

                    b.Property<string>("LetraPrecio");

                    b.Property<string>("LimitesNaturales");

                    b.Property<string>("Marquesina");

                    b.Property<string>("MaterialConstruccion");

                    b.Property<string>("MaterialTecho");

                    b.Property<string>("Matricula");

                    b.Property<int>("MetroInmueble");

                    b.Property<int>("MetroTerraza");

                    b.Property<string>("MurosCimientos");

                    b.Property<int>("NivelesCasa");

                    b.Property<int>("NoBanos");

                    b.Property<int>("NoBaños2");

                    b.Property<int>("NoBaños3");

                    b.Property<string>("NoCatastral");

                    b.Property<int>("NoHabitacion2");

                    b.Property<int>("NoHabitacion3");

                    b.Property<int>("NoParqueos");

                    b.Property<int>("NoParqueos2");

                    b.Property<int>("NoParqueos3");

                    b.Property<int>("NumeroPiso");

                    b.Property<int>("NumeroRegistro");

                    b.Property<string>("OcupadoPor");

                    b.Property<string>("Oferta");

                    b.Property<int>("OpinionValorLiquidacion");

                    b.Property<string>("OtrasMejoras");

                    b.Property<string>("Otro");

                    b.Property<string>("OtrosDetalles");

                    b.Property<string>("Pais");

                    b.Property<string>("ParedesMaterial");

                    b.Property<int>("Parqueos");

                    b.Property<string>("Plano");

                    b.Property<int>("Precio");

                    b.Property<int>("PrecioMetro2");

                    b.Property<int>("PrecioMetro3");

                    b.Property<int>("PrecioPorM2");

                    b.Property<int>("PrecioVenta");

                    b.Property<int>("PrecioVenta2");

                    b.Property<int>("PrecioVenta3");

                    b.Property<string>("Propietario");

                    b.Property<string>("RevestimientoExterior");

                    b.Property<string>("Revisor");

                    b.Property<int>("SalaEstar");

                    b.Property<string>("Servidumbre");

                    b.Property<string>("SistemaElectrico");

                    b.Property<string>("Sotano");

                    b.Property<string>("SuplementoInformativo");

                    b.Property<int>("Tamaño");

                    b.Property<int>("Tamaño2");

                    b.Property<int>("Tamaño3");

                    b.Property<string>("TasadorNombre");

                    b.Property<string>("Techos");

                    b.Property<string>("TecnicoNombre");

                    b.Property<string>("Telefono");

                    b.Property<string>("TelefonoConstructora");

                    b.Property<string>("TendenciaVecindad");

                    b.Property<int>("Terraza");

                    b.Property<string>("TipoInmueble");

                    b.Property<string>("TipoPiso");

                    b.Property<string>("TipoVecindad");

                    b.Property<string>("Topografia");

                    b.Property<string>("TuberiasSanitarias");

                    b.Property<string>("UsoPropiedad");

                    b.Property<int>("UtilidadInmueble");

                    b.Property<int>("ValorAjustado");

                    b.Property<int>("ValorAjustado2");

                    b.Property<int>("ValorAjustado3");

                    b.Property<int>("ValorDelMismo");

                    b.Property<int>("ValorEnfoqueVentas");

                    b.Property<int>("ValorTerreno");

                    b.Property<string>("Valuador");

                    b.Property<string>("VentaAdicional");

                    b.Property<string>("VentanaMarco");

                    b.Property<int>("Xtotal");

                    b.Property<string>("Zonificacion");

                    b.Property<string>("caracteristicasZona");

                    b.HasKey("TasacionID");

                    b.ToTable("Tasacions");
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("api_brick.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("api_brick.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("api_brick.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("api_brick.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("api_brick.Models.Blog", b =>
                {
                    b.HasOne("api_brick.Models.Cliente", "Usuario")
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

            modelBuilder.Entity("api_brick.Models.Cliente", b =>
                {
                    b.HasOne("api_brick.Models.Rol")
                        .WithMany("Usuarios")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("api_brick.Models.ComentarioForo", b =>
                {
                    b.HasOne("api_brick.Models.PublicacionForo", "Publicacion")
                        .WithMany("CometariosForos")
                        .HasForeignKey("PublicacionID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("api_brick.Models.Cliente", "Usuario")
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

                    b.HasOne("api_brick.Models.Cliente", "Usuario")
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

                    b.HasOne("api_brick.Models.Cliente", "Usuario")
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
                    b.HasOne("api_brick.Models.Cliente", "Usuario")
                        .WithMany("Solicitud")
                        .HasForeignKey("UsuarioID")
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
