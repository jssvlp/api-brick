using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    [Table("caracteristicas")]
    public class Caracteristica
    {
        public int CaracteristicaID { get; set; }
        public string TipoCar { get; set; }
        public string CarNombre { get; set; }
        public string CarDescripcion { get; set; }
        public string TipoCarProyecto { get; set; }


        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdateAt { get; set; }

        
        public ICollection<CaracteristicaProyecto> CaracteristicasProyectos { get; set; }

        public Caracteristica()
        {
            CaracteristicasProyectos = new Collection<CaracteristicaProyecto>();
        }
    }
}
