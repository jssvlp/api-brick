using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    [Table("imagenes_proyectos")]
    public class ImagenProyecto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }

        [ForeignKey("Proyecto")]
        public int ProyectoID { get; set; }
        public Proyecto Proyecto { get; set; }
    }
}
