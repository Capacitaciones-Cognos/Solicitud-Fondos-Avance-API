using Solicitud_Fondos_Avance_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solicitud_Fondos_Avance_API.Dtos
{
    public class GetPersonaDto
    {
        public int id { get; set; }
        public string nombres { get; set; }
        public string apPaterno { get; set; }
        public string apMaterno { get; set; }
        public string cargo { get; set; }
        public string rol { get; set; }
        public string username { get; set; }

        public static explicit operator GetPersonaDto(Persona personaModel)
        {
            var resultDto = default(GetPersonaDto);
            if (personaModel != null)
            {
                resultDto = new GetPersonaDto
                {
                    id = personaModel.id,
                    nombres = personaModel.nombres,
                    apPaterno= personaModel.apPaterno,
                    apMaterno= personaModel.apMaterno,
                    cargo = personaModel.cargo,
                    rol = personaModel.rol,
                    username = personaModel.username,
                };
            }
            return resultDto;
        }

        public static explicit operator Persona(GetPersonaDto personaDto)
        {
            var resultEntity = default(Persona);
            if (personaDto != null)
            {
                resultEntity = new Persona
                {
                    nombres = personaDto.nombres,
                    apPaterno = personaDto.apPaterno,
                    apMaterno = personaDto.apMaterno,
                    cargo = personaDto.cargo,
                    rol = personaDto.rol,
                    username = personaDto.username,
                };
            }
            return resultEntity;
        }
    }
}
