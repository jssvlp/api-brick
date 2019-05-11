using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    public class Peticion
    {
        public int PeticionID { get; set; }
        public string Tipo { get; set; }
        public string Motivo { get; set; }
        public string Comentario { get; set; }
        public DateTime? FechaSolicitada { get; set; }
        public DateTime? FechaCancelacion { get; set; }
        public int SolicitudID { get; set; }
        public Solicitud Solicitud { get; set; }
        public string Estado { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdateAt { get; set; }
    }
}
