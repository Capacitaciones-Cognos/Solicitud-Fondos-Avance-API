using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Solicitud_Fondos_Avance_API.Models
{
    public class SubProyecto : BaseEntity
    {
        public string nombre { get; set; }

        // FK: Proyecto > SubProyecto 1..* <-> 1..1 Proyecto
        public int proyectoId { get; set; }

        // Property navegability
        [ForeignKey("proyectoId")]
        public Proyecto proyecto { get; set; }


        //[ForeignKey("subProyectoId")]
        public List<SubProyecto_Actividad> subProyectosActividades { get; set; }
    }
}
