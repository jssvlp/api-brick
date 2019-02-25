﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    public class Servicios
    {
        public int ServicioID { get; set; }
        public string NombreServicio { get; set; }
        public string DescripcionServicio { get; set; }

        public ICollection<ServicioSolicitud> servicioSolicituds { get; set; }

        public Servicios() {
            servicioSolicituds = new Collection<ServicioSolicitud>();
        }
    }
}
