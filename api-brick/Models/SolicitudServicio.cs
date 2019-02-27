using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    public class SolicitudServicio
    {
        [Key]
        public int SolicitudID { get; set; }

        public DateTime FechaSol { get; set; }
        public int UsuarioID { get; set; }
        public DateTime FechaServSol { get; set; }
        public string Comentario { get; set; }

        public Usuario usuario { get; set; }

        public ICollection<ServicioSolicitud> servicioSolicituds { get; set; }

        public SolicitudServicio()
        {
            servicioSolicituds = new Collection<ServicioSolicitud>();
        }
    }
}
