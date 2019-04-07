using api_brick.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    [Table("usuarios")]
    public class Usuario
    {
        public int UsuarioID { get; set; }
        public string NombreUsuario { get; set; }
        public string ApellidosUsuario { get; set; }
        public string CorreoUsuario { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Contraseña { get; set; }

        public string FirebaseCode { get; set; }
        public string AuthToken { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Rol Role { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdateAt { get; set; }

        public virtual ICollection<Solicitud> Solicitud{ get; set; }

        public Usuario() {
            Solicitud = new Collection<Solicitud>();
        }

        public void SetAccessToken()
        {
            string token = TokenGenerator.Generate(50);
            this.AuthToken = token;
        }
        public void DestroyAccesToken() {
            this.AuthToken = string.Empty;
        }
    }
}
