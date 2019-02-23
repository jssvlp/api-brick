using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    public class CaracteristicaInmueble
    {
        public int InmuebleID { get; set; }
        public Inmueble Inmueble { get; set; }

        public int CaracteristicaID { get; set; }
        public Caracteristica Caracteristica { get; set; }
    }
}
