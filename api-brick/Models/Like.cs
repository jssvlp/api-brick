    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    [Table("likes")]
    public class Like
    {
        public int LikeID { get; set; }
        public int PublicacionID { get; set; }
        public int UsuarioID { get; set; }

        public Usuario Usuario { get; set; }
        public PublicacionForo Publicacion { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdateAt { get; set; }
    }
}
