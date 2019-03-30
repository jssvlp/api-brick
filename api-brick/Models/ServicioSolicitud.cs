﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    [Table("solicitudes_servicios")]
    public class ServicioSolicitud
    {
        public int EstadoID { get; set; }
        public Estado Estado { get; set; }
        
        public int SolicitudID { get; set; }
        public Solicitud SolicitudServicio { get; set; }

        public int ServicioID { get; set; }
        public Servicio Servicio { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdateAt { get; set; }

    }
}
