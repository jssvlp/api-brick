using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    public class Like
    {
        public int LikeID { get; set; }
        public int PublicacionID { get; set; }
        public int UsuarioID { get; set; }

        public Usuario Usuario { get; set; }
        public PublicacionDelForo Publicacion { get; set; }
    }
}
