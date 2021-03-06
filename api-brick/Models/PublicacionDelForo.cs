﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    public class PublicacionDelForo
    {
        [Key]
        public int PublicacionID { get; set; }
        public string TituloPublicacion { get; set; }
        public int TemaID { get; set; }
        public string TextoPublicacion { get; set; }
        public int UsuarioID { get; set; }
        public DateTime TimeStampForo { get; set; }
        public bool Archivado { get; set; }
        public string URLImagen { get; set; }

        public Usuario Usuario { get; set; }
        public TemasForo temasForo { get; set; }

        public ICollection<ComentarioForo> cometarioForos { get; set; }
        public ICollection<Like> Likes { get; set; }
        public PublicacionDelForo() {

            cometarioForos = new Collection<ComentarioForo>();
            Likes = new Collection<Like>();
        }
    }
}
