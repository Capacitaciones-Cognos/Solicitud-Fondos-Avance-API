using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Solicitud_Fondos_Avance_API.Models
{
    public class ActividadProyecto : BaseEntity
    {
        public string tarea { get; set; }
        public int prioridad { get; set; }

        //public List<SubProyecto> subProyectos { get; set; }

        //[ForeignKey("actividadProyectoId")]
        public List<SubProyecto_Actividad> subProyectosActividades { get; set; }
    }
}
