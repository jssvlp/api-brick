using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    public class TemasForo
    {
        public int TemaID { get; set; }
        public string NombreTema { get; set; }
        public string DescripcionTema { get; set; }

        public ICollection<PublicacionDelForo> PublicacionesDelForo { get; set; }

        public TemasForo() {
            PublicacionesDelForo = new Collection<PublicacionDelForo>();
        }
    }
}
