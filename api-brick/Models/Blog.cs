using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    [Table("blogs")]
    public class Blog
    {
        public int BlogID { get; set; }
        public string TituloEntrada { get; set; }
        public string TextoEntrada { get; set; }
        public int UsuarioID { get; set; }
        public DateTime TimeStampBlog { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdateAt { get; set; }

        
        public  Usuario Usuario { get; set; }
    }
}
