using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    public class Blog
    {
        public int BlogEntryID { get; set; }
        public string TituloEntrada { get; set; }
        public string TextoEntrada { get; set; }
        public int UsuarioID { get; set; }
        public DateTime TimeStampBlog { get; set; }

        public Usuario Usuario { get; set; }
    }
}
