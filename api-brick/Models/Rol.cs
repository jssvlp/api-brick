using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{

    [Table("Roles")]
    public class Rol
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleNombre { get; set; }
        public string Descripcion { get; set; }

        public ICollection<PermisosRoles> Permisos { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
    }
}
