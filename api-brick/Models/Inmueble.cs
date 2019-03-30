using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    [Table("inmuebles")]
    public  class Inmueble
    {
        public int InmuebleID { get; set; }
        public int Precio { get; set; }
        public string NombreInmueble { get; set; }
        public string DescripcionInmueble { get; set; }
        
        //[ForeignKey("Proyecto")]
        public int ProyectoID { get; set; }
        public Proyecto Proyecto { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdateAt { get; set; }

        public ICollection<CaracteristicaInmueble> CaracteristicasInmuebles { get; set; }

        public Inmueble() {
            CaracteristicasInmuebles = new Collection<CaracteristicaInmueble>();
        }
    }
}
