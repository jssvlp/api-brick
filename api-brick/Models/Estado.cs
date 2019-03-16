using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    [Table("Estado")]
    public class Estado
    {
        [Key]
        public int EstadoId { get; set; }
        public string EstadoNombre { get; set; }
    }
}
