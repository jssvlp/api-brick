using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    [Table("caracteristicas_proyectos")]
    public class CaracteristicaProyecto
    {
        public int ProyectoID { get; set; }
        public Proyecto Proyecto { get; set; }

        public int CaracteristicaID { get; set; }
        public Caracteristica Caracteristica { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdateAt { get; set; }
    }
}
