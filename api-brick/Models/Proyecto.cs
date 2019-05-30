using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    [Table("proyectos")]
    public class Proyecto
    {
        public int ProyectoID { get; set; }
        public string NombreProyecto { get; set; }
        public DateTime FechaTerminacion { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Direccion { get; set; }
        public string ImgURL { get; set; }
        public string DocumentoResumenPdf { get; set; }
        public int Estado { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdateAt { get; set; }

        public ICollection<Inmueble> Inmuebles { get; set; }
        public ICollection<VisitaAgendada> VisitasAgendadas { get; set; }
        public ICollection<CaracteristicaProyecto> CaracteristicasProyectos { get; set; }
        public ICollection<ImagenProyecto>  Imagenes { get; set; }

        public Proyecto()
        {
            Inmuebles = new Collection<Inmueble>();
            VisitasAgendadas = new Collection<VisitaAgendada>();
            CaracteristicasProyectos = new Collection<CaracteristicaProyecto>();
            Imagenes = new Collection<ImagenProyecto>();
        }
    }
}
