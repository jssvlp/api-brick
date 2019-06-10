using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    public class Tasacion
    {
        public int TasacionID { get; set; }
        public string DescripcionInmueble { get; set; }
        public string TasadorNombre { get; set; }
        public string AsesorNombre { get; set; }
        public string TecnicoNombre { get; set; }
        public string DireccionConstructora { get; set; }
        public string TelefonoConstructora { get; set; }
        public string CorreoCompañia { get; set; }
        public string ClienteNombre { get; set; }
        public DateTime Fecha { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public string Banco { get; set; }

        //Certificador de avaluo

        public string NoCatastral { get; set; }
        public string Matricula { get; set; }
        public int Precio { get; set; }
        public string LetraPrecio { get; set; }

        //Informe de avaluo de propiedad

        public string Propietario { get; set; }
        public string Valuador { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int MyProperty { get; set; }

        //Nombre del solicitante <<Nombre del cliente>>

        public string DerechoPropiedad { get; set; }
        public string OcupadoPor { get; set; }
        public int UtilidadInmueble { get; set; }

        //Descripcion de la vecindad

        public string TipoVecindad { get; set; }
        public string TendenciaVecindad { get; set; }
        public string ComparacionVecindario { get; set; }
        public int AntiguedadPromedio { get; set; }
        public int AreaConstruida { get; set; }
        public string Oferta { get; set; }
        public string Demanda { get; set; }
        public string DeseabilidadPropiedad { get; set; }
        public int DistanciaEscuelaP { get; set; }
        public int DistanciaEscuelaS { get; set; }
        public int DistanciaTransporte { get; set;  }
        public int DistanciaComercio { get; set; }
        public int DistanciaCiudad { get; set; }


        //Descripcion de la zona

        public string LimitesNaturales { get; set; }
        public int Area { get; set; }
        public string Fuente { get; set; }
        public string Topografia { get; set; }
        public string Configuracion { get; set; }
        public string Zonificacion { get; set; }
        public string UsoPropiedad { get; set; }
        public string AreaVerde { get; set; }
        public string Servidumbre { get; set; }
        public string Marquesina { get; set; }
        public string InstalacionElectrica { get; set; }

        //Descripcion de las mejoras
        public string ConstruccionTerminada { get; set; }
        public int Xtotal { get; set; }
        public string VentanaMarco { get; set; }
        public string Sotano { get; set; }
        public string TipoInmueble { get; set; }
        public string Estructura { get; set; }
        public string MaterialConstruccion { get; set; }
        public string RevestimientoExterior { get; set; }
        public string MaterialTecho { get; set; }
        public string CondicionExterna { get; set; }

        //Descripcion del interior de la propiedad

        public string TipoPiso { get; set; }
        public string DistribucionArq { get; set; }
        public string Armarios { get; set; }
        public string Dormitorios { get; set; }
        public string Baños { get; set; }
        public int NoBaños { get; set; }
        public string CodicionInterna { get; set; }
        public string ParedesMaterial { get; set; }
        public string Techos { get; set; }
        public string OtrosDetalles { get; set; }
        public string MurosCimientos { get; set; }
        public string TuberiasSanitarias { get; set; }
        public string CalentadorAgua { get; set; }
        public string SistemaElectrico { get; set; }
        public ArraySegment<string> ArtefactosAdicionales { get; set; }
        public int NoParqueos { get; set; }
        public string OtrasMejoras { get; set; }
        public string Comentarios { get; set; }

        //Distribucion Habitaciones

        public int NivelesCasa { get; set; }
        public int CantidadPiso { get; set; }
        public int Habitaciones { get; set; }
        public int Entrada { get; set; }
        public int SalaEstar { get; set; }
        public int Cocina { get; set; }
        public int Comedor { get; set; }
        public int BañoCompleto { get; set; }
        public int BañoParcial { get; set; }
        public int Terraza { get; set; }
        public int Lavanderia { get; set; }
        public int CuartoServicio { get; set; }
        public int Parqueos { get; set; }

        //Metodologias de venta

        public string FuenteManualCosto { get; set; }
        public int ValorTerreno { get; set; }

        //Enfoque de venta comparables

        public DateTime FechaVenta { get; set; }
        public int PrecioVenta { get; set; }
        public int Tamaño { get; set; }
        public int PrecioPorM2 { get; set; }
        public string Condicion { get; set; }
        public string Estilo { get; set; }
        public int ValorAjustado { get; set; }


        //Conclusiones
        public string Conclusiones { get; set; }
        public int ValorEnfoqueVentas { get; set; }
        public int OpnionValorMercado { get; set; }
        public int OpinionValorLiquidacion { get; set; }
        public int ValorDelMismo { get; set; }
        public string ComentariosVentas { get; set; }
        public DateTime FechaDiaTasacion { get; set; }
        public int ValorConsiderado { get; set; }
        public string VentaAdicional { get; set; }
        public string SuplementoInformativo { get; set; }
        public string Plano { get; set; }
        public string CondicionesRestrictivas { get; set; }
        public string Otro { get; set; }
        public string Revisor { get; set; }
        public int NumeroRegistro { get; set; }
        public DateTime FechaInspeccion { get; set; }
    }
}
