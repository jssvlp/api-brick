using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    public class Caracteristica
    {
        public int CaracteristicaID { get; set; }
        public string CarNombre { get; set; }
        public string CarDescripcion { get; set; }


        public ICollection<CaracteristicaInmueble> CaracteristicasInmbles { get; set; }
    }
}
