using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    [Table("temas_foros")]
    public class TemasForo
    {
        [Key]
        public int TemaID { get; set; }
        public string NombreTema { get; set; }
        public string DescripcionTema { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdateAt { get; set; }

        public ICollection<PublicacionForo> PublicacionesDelForo { get; set; }

        public TemasForo() {
            PublicacionesDelForo = new Collection<PublicacionForo>();
        }
    }
}
