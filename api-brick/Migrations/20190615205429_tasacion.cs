﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_brick.Migrations
{
    public partial class tasacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    CorreoCompañia = table.Column<string>(nullable: true),
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
                    AñoEstimado = table.Column<DateTime>(nullable: false),
                    Xtotal = table.Column<int>(nullable: false),
                    VentanaMarco = table.Column<string>(nullable: true),
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
                    Baños = table.Column<string>(nullable: true),
                    NoBaños = table.Column<int>(nullable: false),
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
                    NivelesCasa = table.Column<int>(nullable: false),
                    CantidadPiso = table.Column<int>(nullable: false),
                    Habitaciones = table.Column<int>(nullable: false),
                    Entrada = table.Column<int>(nullable: false),
                    SalaEstar = table.Column<int>(nullable: false),
                    Cocina = table.Column<int>(nullable: false),
                    Comedor = table.Column<int>(nullable: false),
                    BañoCompleto = table.Column<int>(nullable: false),
                    BañoParcial = table.Column<int>(nullable: false),
                    Terraza = table.Column<int>(nullable: false),
                    Lavanderia = table.Column<int>(nullable: false),
                    CuartoServicio = table.Column<int>(nullable: false),
                    Parqueos = table.Column<int>(nullable: false),
                    FuenteManualCosto = table.Column<string>(nullable: true),
                    ValorTerreno = table.Column<int>(nullable: false),
                    FechaVenta = table.Column<DateTime>(nullable: false),
                    PrecioVenta = table.Column<int>(nullable: false),
                    Tamaño = table.Column<int>(nullable: false),
                    PrecioPorM2 = table.Column<int>(nullable: false),
                    Condicion = table.Column<string>(nullable: true),
                    Estilo = table.Column<string>(nullable: true),
                    ValorAjustado = table.Column<int>(nullable: false),
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

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "UsuarioID",
                keyValue: 1,
                column: "FechaNacimiento",
                value: new DateTime(2019, 6, 15, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasacions");

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "UsuarioID",
                keyValue: 1,
                column: "FechaNacimiento",
                value: new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
