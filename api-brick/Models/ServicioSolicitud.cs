using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    public class ServicioSolicitud
    {
        public int SolicitudID { get; set; }
        public SolicitudServicio SolicitudServicio { get; set; }

        public int ServicioID { get; set; }
        public Servicio Servicio { get; set; }
    }
}
