using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    public class Caracteristica_Inmueble
    {
        public int Caracteristica_InmuebleID { get; set; }
        public ICollection<Inmueble> Inmuebles { get; set; }
        public ICollection<CaracteristicaInmueble> CaracteristicaInmuebles { get; set; }

        public Caracteristica_Inmueble() {
            Inmuebles = new Collection<Inmueble>();
            CaracteristicaInmuebles = new Collection<CaracteristicaInmueble>();

        }
    }
}
