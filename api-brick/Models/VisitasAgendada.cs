using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    public class VisitasAgendada
    {
        [Key]
        public int VisitaID { get; set; }
        public int ProyectoID { get; set; }
        public DateTime HorarioProgramado { get; set; }
        public int SolicitudID { get; set; }

        public Proyecto Proyecto { get; set; }
        public Solicitud Solicitud { get; set; }
    }
}
