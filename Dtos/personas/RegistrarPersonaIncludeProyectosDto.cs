using Solicitud_Fondos_Avance_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solicitud_Fondos_Avance_API.Dtos
{
    public class RegistrarPersonaIncludeProyectosDto
    {
        public string nombre { get; set; }
        public string paterno { get; set; }
        public string materno { get; set; }
        public string cargo { get; set; }
        public string rol { get; set; }
        public string username { get; set; }
        
        public List<RegistrarProyectoDto> proyectos { get; set; }


        public static implicit operator Persona(RegistrarPersonaIncludeProyectosDto personaDto)
        {
            var resultEntity = default(Persona);
            if (personaDto != null)
            {
                resultEntity = new Persona
                {
                    nombres = personaDto.nombre,
                    apPaterno = personaDto.paterno,
                    apMaterno = personaDto.materno,
                    cargo = personaDto.cargo,
                    rol = personaDto.rol,
                    username = personaDto.username,
                    pass = Guid.NewGuid().ToString("n").Substring(0, 8),
                    proyectos = personaDto.proyectos
                                        .ConvertAll(proyectoDto => (Proyecto)proyectoDto)
                };
            }
            return resultEntity;
        }

    }
}
