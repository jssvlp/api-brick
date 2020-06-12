using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    [Table("familias_proyectos")]
    public class FamiliaProyecto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdateAt { get; set; }

        public ICollection<Proyecto> Proyectos { get; set; }

        public FamiliaProyecto()
        {
            Proyectos = new Collection<Proyecto>();
        }
    }
}
