using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    public class Proyecto
    {
        public int ProyectoID { get; set; }
        public string NombreProyecto { get; set; }
        public DateTime FechaTerminacion { get; set; }
        public string Direccion { get; set; }
        public string ImgURL { get; set; }


        public int UbicacionID { get; set; }
        public Ubicacion Ubicacion { get; set; }

        public ICollection<Inmueble> Inmuebles { get; set; }
        public ICollection<VisitasAgendadas> VisitasAgendadas { get; set; }

        public Proyecto()
        {
            Inmuebles = new Collection<Inmueble>();
            VisitasAgendadas = new Collection<VisitasAgendadas>();
        }
    }
}
