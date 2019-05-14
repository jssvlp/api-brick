using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    public class Email
    {
        public string Subject { get; set; }
        public string Htmlcontent { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
    }
}
