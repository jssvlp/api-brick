using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public bool AdminAccess { get; set; }

        public ICollection<SolicitudServicio> Solicitud{ get; set; }

        public Usuario() {
            Solicitud = new Collection<SolicitudServicio>();
        }
    }
}
