using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    public class Permiso
    {
        [Key]
        public int PermisoId { get; set; }

        public string Modulo { get; set; }

        public ICollection<PermisosRoles> PermisosRol { get; set; }
    }
}
