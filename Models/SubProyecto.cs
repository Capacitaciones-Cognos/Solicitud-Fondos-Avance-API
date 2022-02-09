using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Solicitud_Fondos_Avance_API.Models
{
    public class SubProyecto:BaseEntity
    {        
        public string nombre { get; set; }
        public string descripcion { get; set; }

        public DateTime fechaInicio { get; set; }
        public DateTime? fechaFin { get; set; }

        // FK: Persona > Proyecto 1..* <-> 0..1 Persona
        public int? proyectoId { get; set; }

        // Prop navegability
        [ForeignKey("proyectoId")]
        public Proyecto proyecto { get; set; }
    }
}
