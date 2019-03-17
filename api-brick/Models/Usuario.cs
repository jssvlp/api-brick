using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
   
    public class Usuario
    {
        public int UsuarioID { get; set; }
        public string NombreUsuario { get; set; }
        public string ApellidosUsuario { get; set; }
        public string CorreoUsuario { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Contraseña { get; set; }
     
        public string FirebaseCode { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Rol Role { get; set; }

        public ICollection<Solicitud> Solicitud{ get; set; }

        public Usuario() {
            Solicitud = new Collection<Solicitud>();
        }
    }
}
