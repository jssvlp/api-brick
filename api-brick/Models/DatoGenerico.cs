using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    [Table("datos_genericos")]
    public class DatoGenerico
    {

        public int Id { get; set; }
        public string Key { get; set; }
        public string  Value { get; set; }
        public string Descripcion { get; set; }

    }
}
