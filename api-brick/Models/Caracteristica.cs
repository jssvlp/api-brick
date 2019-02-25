using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    public class Caracteristica
    {
        public int CaracteristicaID { get; set; }
        public string CarNombre { get; set; }
        public string CarDescripcion { get; set; }


        public ICollection<CaracteristicaInmueble> CaracteristicasInmuebles { get; set; }

        public Caracteristica()
        {
            CaracteristicasInmuebles = new Collection<CaracteristicaInmueble>();
        }
    }
}
