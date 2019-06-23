using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_brick.Migrations
{
    public partial class Tasacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasacions",
                columns: table => new
                {
                    TasacionID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DescripcionInmueble = table.Column<string>(nullable: true),
                    TasadorNombre = table.Column<string>(nullable: true),
                    AsesorNombre = table.Column<string>(nullable: true),
                    TecnicoNombre = table.Column<string>(nullable: true),
                    DireccionConstructora = table.Column<string>(nullable: true),
                    TelefonoConstructora = table.Column<string>(nullable: true),
                    CorreoCompania = table.Column<string>(nullable: true),
                    ClienteNombre = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Ciudad = table.Column<string>(nullable: true),
                    Pais = table.Column<string>(nullable: true),
                    Banco = table.Column<string>(nullable: true),
                    NoCatastral = table.Column<string>(nullable: true),
                    Matricula = table.Column<string>(nullable: true),
                    Precio = table.Column<int>(nullable: false),
                    LetraPrecio = table.Column<string>(nullable: true),
                    Propietario = table.Column<string>(nullable: true),
                    Valuador = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    DerechoPropiedad = table.Column<string>(nullable: true),
                    OcupadoPor = table.Column<string>(nullable: true),
                    UtilidadInmueble = table.Column<int>(nullable: false),
                    TipoVecindad = table.Column<string>(nullable: true),
                    TendenciaVecindad = table.Column<string>(nullable: true),
                    ComparacionVecindario = table.Column<string>(nullable: true),
                    AntiguedadPromedio = table.Column<int>(nullable: false),
                    AreaConstruida = table.Column<int>(nullable: false),
                    Oferta = table.Column<string>(nullable: true),
                    Demanda = table.Column<string>(nullable: true),
                    DeseabilidadPropiedad = table.Column<string>(nullable: true),
                    DistanciaEscuelaP = table.Column<int>(nullable: false),
                    DistanciaEscuelaS = table.Column<int>(nullable: false),
                    DistanciaTransporte = table.Column<int>(nullable: false),
                    DistanciaComercio = table.Column<int>(nullable: false),
                    DistanciaCiudad = table.Column<int>(nullable: false),
                    LimitesNaturales = table.Column<string>(nullable: true),
                    caracteristicasZona = table.Column<string>(nullable: true),
                    Area = table.Column<int>(nullable: false),
                    Fuente = table.Column<string>(nullable: true),
                    Topografia = table.Column<string>(nullable: true),
                    Configuracion = table.Column<string>(nullable: true),
                    Zonificacion = table.Column<string>(nullable: true),
                    UsoPropiedad = table.Column<string>(nullable: true),
                    AreaVerde = table.Column<string>(nullable: true),
                    Servidumbre = table.Column<string>(nullable: true),
                    Marquesina = table.Column<string>(nullable: true),
                    InstalacionElectrica = table.Column<string>(nullable: true),
                    ConstruccionTerminada = table.Column<string>(nullable: true),
                    AnoEstimado = table.Column<DateTime>(nullable: false),
                    Xtotal = table.Column<int>(nullable: false),
                    VentanaMarco = table.Column<string>(nullable: true),
                    AreaPiso = table.Column<int>(nullable: false),
                    AreaTotalSotano = table.Column<int>(nullable: false),
                    Sotano = table.Column<string>(nullable: true),
                    TipoInmueble = table.Column<string>(nullable: true),
                    Estructura = table.Column<string>(nullable: true),
                    MaterialConstruccion = table.Column<string>(nullable: true),
                    RevestimientoExterior = table.Column<string>(nullable: true),
                    MaterialTecho = table.Column<string>(nullable: true),
                    CondicionExterna = table.Column<string>(nullable: true),
                    TipoPiso = table.Column<string>(nullable: true),
                    DistribucionArq = table.Column<string>(nullable: true),
                    Armarios = table.Column<string>(nullable: true),
                    Dormitorios = table.Column<string>(nullable: true),
                    Banos = table.Column<string>(nullable: true),
                    NoBanos = table.Column<int>(nullable: false),
                    CodicionInterna = table.Column<string>(nullable: true),
                    ParedesMaterial = table.Column<string>(nullable: true),
                    Techos = table.Column<string>(nullable: true),
                    OtrosDetalles = table.Column<string>(nullable: true),
                    MurosCimientos = table.Column<string>(nullable: true),
                    TuberiasSanitarias = table.Column<string>(nullable: true),
                    CalentadorAgua = table.Column<string>(nullable: true),
                    SistemaElectrico = table.Column<string>(nullable: true),
                    ArtefactosAdicionales = table.Column<string>(nullable: true),
                    Amenidades = table.Column<string>(nullable: true),
                    NoParqueos = table.Column<int>(nullable: false),
                    OtrasMejoras = table.Column<string>(nullable: true),
                    Comentarios = table.Column<string>(nullable: true),
                    CapacidadCalentador = table.Column<int>(nullable: false),
                    NumeroPiso = table.Column<int>(nullable: false),
                    NivelesCasa = table.Column<int>(nullable: false),
                    CantidadPiso = table.Column<int>(nullable: false),
                    Habitaciones = table.Column<int>(nullable: false),
                    Entrada = table.Column<int>(nullable: false),
                    SalaEstar = table.Column<int>(nullable: false),
                    Cocina = table.Column<int>(nullable: false),
                    Comedor = table.Column<int>(nullable: false),
                    BanoCompleto = table.Column<int>(nullable: false),
                    BanoParcial = table.Column<int>(nullable: false),
                    Terraza = table.Column<int>(nullable: false),
                    Lavanderia = table.Column<int>(nullable: false),
                    CuartoServicio = table.Column<int>(nullable: false),
                    Parqueos = table.Column<int>(nullable: false),
                    FuenteManualCosto = table.Column<string>(nullable: true),
                    ValorTerreno = table.Column<int>(nullable: false),
                    MetroInmueble = table.Column<int>(nullable: false),
                    MetroTerraza = table.Column<int>(nullable: false),
                    CostoMetroInmueble = table.Column<int>(nullable: false),
                    CostoMetroTerraza = table.Column<int>(nullable: false),
                    FechaVenta = table.Column<DateTime>(nullable: false),
                    PrecioVenta = table.Column<int>(nullable: false),
                    Tamaño = table.Column<int>(nullable: false),
                    PrecioPorM2 = table.Column<int>(nullable: false),
                    Condicion = table.Column<string>(nullable: true),
                    Estilo = table.Column<string>(nullable: true),
                    ValorAjustado = table.Column<int>(nullable: false),
                    Descripcion2 = table.Column<string>(nullable: true),
                    Direccion2 = table.Column<string>(nullable: true),
                    FechaVenta2 = table.Column<DateTime>(nullable: false),
                    PrecioVenta2 = table.Column<int>(nullable: false),
                    Tamaño2 = table.Column<int>(nullable: false),
                    PrecioMetro2 = table.Column<int>(nullable: false),
                    Condicion2 = table.Column<string>(nullable: true),
                    Estilo2 = table.Column<string>(nullable: true),
                    NoBaños2 = table.Column<int>(nullable: false),
                    NoHabitacion2 = table.Column<int>(nullable: false),
                    NoParqueos2 = table.Column<int>(nullable: false),
                    CondicionFisica2 = table.Column<string>(nullable: true),
                    ValorAjustado2 = table.Column<int>(nullable: false),
                    Descripcion3 = table.Column<string>(nullable: true),
                    Direccion3 = table.Column<string>(nullable: true),
                    FechaVenta3 = table.Column<DateTime>(nullable: false),
                    PrecioVenta3 = table.Column<int>(nullable: false),
                    Tamaño3 = table.Column<int>(nullable: false),
                    PrecioMetro3 = table.Column<int>(nullable: false),
                    Condicion3 = table.Column<string>(nullable: true),
                    Estilo3 = table.Column<string>(nullable: true),
                    NoBaños3 = table.Column<int>(nullable: false),
                    NoHabitacion3 = table.Column<int>(nullable: false),
                    NoParqueos3 = table.Column<int>(nullable: false),
                    CondicionFisica3 = table.Column<string>(nullable: true),
                    ValorAjustado3 = table.Column<int>(nullable: false),
                    Conclusiones = table.Column<string>(nullable: true),
                    ValorEnfoqueVentas = table.Column<int>(nullable: false),
                    OpinionValorLiquidacion = table.Column<int>(nullable: false),
                    ValorDelMismo = table.Column<int>(nullable: false),
                    ComentariosVentas = table.Column<string>(nullable: true),
                    FechaDiaTasacion = table.Column<DateTime>(nullable: false),
                    VentaAdicional = table.Column<string>(nullable: true),
                    SuplementoInformativo = table.Column<string>(nullable: true),
                    Plano = table.Column<string>(nullable: true),
                    CondicionesRestrictivas = table.Column<string>(nullable: true),
                    Otro = table.Column<string>(nullable: true),
                    Revisor = table.Column<string>(nullable: true),
                    NumeroRegistro = table.Column<int>(nullable: false),
                    FechaInspeccion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasacions", x => x.TasacionID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "UsuarioID",
                keyValue: 1,
                column: "FechaNacimiento",
                value: new DateTime(2019, 6, 22, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Tasacions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "UsuarioID",
                keyValue: 1,
                column: "FechaNacimiento",
                value: new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
