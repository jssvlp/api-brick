using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    [Table("solicitudes")]
    public class Solicitud
    {
        [Key]
        public int SolicitudID { get; set; }

        public DateTime FechaSol { get; set; }
        public int UsuarioID { get; set; }
        public DateTime FechaServSol { get; set; }
        public string Comentario { get; set; }

        public Usuario usuario { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdateAt { get; set; }

        public ICollection<ServicioSolicitud> servicioSolicituds { get; set; }

        public Solicitud()
        {
            servicioSolicituds = new Collection<ServicioSolicitud>();
        }
    }
}
