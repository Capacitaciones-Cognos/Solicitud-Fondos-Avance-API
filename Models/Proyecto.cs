using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Solicitud_Fondos_Avance_API.Models
{
    public class Proyecto : BaseEntity
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }

        public DateTime fechaInicio { get; set; }
        public DateTime? fechaFin { get; set; }

        // FK: Persona > Proyecto 1..* <-> 0..1 Persona
        public int? personaId { get; set; }
        
        // Prop navegability
        [ForeignKey("personaId")]
        public Persona persona { get; set; }

        
    }
}
