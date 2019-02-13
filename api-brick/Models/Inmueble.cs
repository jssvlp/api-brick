﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    public class Inmueble
    {
        public int InmuebleID { get; set; }
        public int Precio { get; set; }
        public string DescripcionInmueble { get; set; }

        //[ForeignKey("Proyecto")]
        public int ProyectoID { get; set; }
        public Proyecto Proyecto { get; set; }
    }
}