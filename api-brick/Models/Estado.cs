using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    [Table("estados")]
    public class Estado
    {
        [Key]
        public int EstadoId { get; set; }
        public string EstadoNombre { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdateAt { get; set; }


        public virtual ICollection<ServicioSolicitud> ServicioSolicituds { get; set; }

         public Estado()
         {
             ServicioSolicituds = new Collection<ServicioSolicitud>();
         }
    }
}
