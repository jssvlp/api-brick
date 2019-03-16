using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    [Table("PermisosRoles")]
    public class PermisosRoles
    {

        [ForeignKey("Permiso")]
        public int PermisoId { get; set; }
        public Permiso Permiso { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Rol Role { get; set; }
       
    }
}
