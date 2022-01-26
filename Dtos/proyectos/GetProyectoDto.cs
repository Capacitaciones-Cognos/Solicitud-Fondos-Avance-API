using Solicitud_Fondos_Avance_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solicitud_Fondos_Avance_API.Dtos.proyectos
{
    public class GetProyectoDto
    {
        public int idProyecto { get; set; }
        public string proyecto { get; set; }
        public string glosa { get; set; }
        public DateTime inicio { get; set; }
        public DateTime? finalizacion { get; set; }

        /*
            Corto:      0..3 meses
            Mediano:    3..6 meses
            Largo:      6..N meses
         */
        public string plazo { get; set; } 


        public static explicit operator GetProyectoDto(Proyecto proyectoEntitdad)
        {
            var resultDto = default(GetProyectoDto);
            if (proyectoEntitdad != null)
            {
                var diferenciaTiempo = proyectoEntitdad.fechaFin - proyectoEntitdad.fechaInicio;
                int diferenciaDias = diferenciaTiempo.Value.Days;

                string plazoDefinido;
                if (diferenciaDias >= 0 && diferenciaDias < 90)
                {
                    plazoDefinido = "corto";
                } else if (diferenciaDias >= 90 && diferenciaDias < 180)
                {
                    plazoDefinido = "mediano";
                } else // Mayor a 180 dias
                {
                    plazoDefinido = "largo";
                }

                resultDto = new GetProyectoDto
                {
                    idProyecto = proyectoEntitdad.id,
                    proyecto = proyectoEntitdad.nombre,
                    glosa = proyectoEntitdad.descripcion,
                    inicio = proyectoEntitdad.fechaInicio,
                    finalizacion = proyectoEntitdad.fechaFin,
                    plazo = plazoDefinido
                };
            }
            return resultDto;
        }
    }
}
