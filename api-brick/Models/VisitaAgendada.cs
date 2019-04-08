﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    [Table("visitas_agendadas")]
    public class VisitaAgendada
    {
        [Key]
        public int VisitaID { get; set; }
        public DateTime Hora_Inicio { get; set; }
        public DateTime Hora_Fin { get; set; }
        public string Motivo { get; set; }
        public string Descripcion { get; set; }
        public int? ProyectoID { get; set; }
        public Proyecto Proyecto { get; set; }
        public int? SolicitudID { get; set; }
        public Solicitud Solicitud { get; set; }
        public string Estado { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdateAt { get; set; }
    }
}
