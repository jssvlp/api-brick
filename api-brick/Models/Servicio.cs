using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    [Table("servicios")]
    public class Servicio
    {
        public int ServicioID { get; set; }
        public string NombreServicio { get; set; }
        public string DescripcionServicio { get; set; }
        public string ImgURL { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdateAt { get; set; }

        public ICollection<ServicioSolicitud> servicioSolicituds { get; set; }

        public Servicio() {
            servicioSolicituds = new Collection<ServicioSolicitud>();
        }
    }
}
