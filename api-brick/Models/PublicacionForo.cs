using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    [Table("publicaciones")]
    public class PublicacionForo
    {
        [Key]
        public int PublicacionID { get; set; }
        public string TituloPublicacion { get; set; }
      
        public string TextoPublicacion { get; set; }
      
        public DateTime TimeStampForo { get; set; }
        public bool Archivado { get; set; }
        public string URLImagen { get; set; }

        public int UsuarioID { get; set; }
        public  Cliente Usuario { get; set; }

        public int TemaID { get; set; }
        public  TemasForo TemasForo { get; set; }

        public ICollection<ComentarioForo> CometariosForos { get; set; }
        public ICollection<Like> Likes { get; set; }

    
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdateAt { get; set; }

        public PublicacionForo() {

            CometariosForos = new Collection<ComentarioForo>();
            Likes = new Collection<Like>();
        }
    }
}
