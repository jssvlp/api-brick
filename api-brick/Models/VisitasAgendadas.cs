using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    public class VisitasAgendadas
    {
        public int VisitaID { get; set; }
        public int ProyectoID { get; set; }
        public DateTime HorarioProgramado { get; set; }
        public int SolicitudID { get; set; }

        public Proyecto Proyecto { get; set; }
        public SolicitudServicio Solicitud { get; set; }
    }
}
