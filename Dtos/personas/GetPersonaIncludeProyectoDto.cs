using Solicitud_Fondos_Avance_API.Dtos.proyectos;
using Solicitud_Fondos_Avance_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solicitud_Fondos_Avance_API.Dtos.personas
{
    public class GetPersonaIncludeProyectoDto
    {
        public int idPersona { get; set; }
        public string nombreCompleto { get; set; }
        public string cargo { get; set; }
        public string rol { get; set; }
        public string username { get; set; }

        public List<GetProyectoDto> proyectos { get; set; }

        public static implicit operator GetPersonaIncludeProyectoDto(Persona personaEntity)
        {
            var resultDto = default(GetPersonaIncludeProyectoDto);
            if (personaEntity != null)
            {
                resultDto = new GetPersonaIncludeProyectoDto
                {
                    idPersona = personaEntity.id,
                    nombreCompleto = $"{personaEntity.nombres} {personaEntity.apPaterno} {personaEntity.apMaterno}",
                    cargo = personaEntity.cargo,
                    rol = personaEntity.rol,
                    username = personaEntity.username,
                    proyectos = personaEntity.proyectos
                                        .ConvertAll(proyectoEntidad => (GetProyectoDto)proyectoEntidad)
                };
            }
            return resultDto;
        }


    }
}
