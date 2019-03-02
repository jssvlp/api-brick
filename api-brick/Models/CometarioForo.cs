using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    public class CometarioForo
    {
        public int ComentarioID { get; set; }
        public int PublicacionID { get; set; }
        public int UsuarioID { get; set; }
        public string TextoComentario { get; set; }
        public DateTime TimeStampComment { get; set; }
        public string URLImagen { get; set; }

        public Usuario Usuario { get; set; }
        public PublicacionDelForo publicacion { get; set; }
    }
}
