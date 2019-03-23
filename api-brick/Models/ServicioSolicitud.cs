using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    public class ServicioSolicitud
    {
        public int EstadoID { get; set; }
        public Estado Estado { get; set; }
        
        public int SolicitudID { get; set; }
        public Solicitud SolicitudServicio { get; set; }

        public int ServicioID { get; set; }
        public Servicio Servicio { get; set; }
    }
}
