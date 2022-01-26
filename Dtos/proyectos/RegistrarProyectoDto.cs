using Solicitud_Fondos_Avance_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solicitud_Fondos_Avance_API.Dtos
{
    public class RegistrarProyectoDto
    {
        public string proyecto { get; set; }
        public string glosa { get; set; }
        public DateTime inicio { get; set; }
        public DateTime? finalizacion { get; set; }


        public static explicit operator Proyecto(RegistrarProyectoDto proyectoDto)
        {
            var resultEntity = default(Proyecto);
            if (proyectoDto!= null)
            {
                resultEntity = new Proyecto
                {
                    nombre = proyectoDto.proyecto,
                    descripcion = proyectoDto.glosa,
                    fechaInicio = proyectoDto.inicio,
                    fechaFin = proyectoDto.finalizacion
                };
            }
            return resultEntity;
        }

    }
}
