using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Solicitud_Fondos_Avance_API.Models
{
    public class SubProyecto_Actividad : BaseEntity
    {
        public int subProyectoId { get; set; }
        public int actividadProyectoId { get; set; }

        public string faseActual { get; set; }


        [ForeignKey("subProyectoId")]
        public SubProyecto subProyecto { get; set; }

        [ForeignKey("actividadProyectoId")]
        public ActividadProyecto actividadProyecto { get; set; }

    }
}
