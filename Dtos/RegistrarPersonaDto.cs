using Solicitud_Fondos_Avance_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solicitud_Fondos_Avance_API.Dtos
{
    public class RegistrarPersonaDto
    {
        public string nombres { get; set; }
        public string paterno { get; set; }
        public string materno { get; set; }
        public string cargo { get; set; }
        public string rol { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public static explicit operator RegistrarPersonaDto(Persona personaModel)
        {
            var resultDto = default(RegistrarPersonaDto);
            if (personaModel!= null)
            {
                resultDto = new RegistrarPersonaDto
                {
                    nombres = personaModel.nombres,
                    paterno = personaModel.apPaterno,
                    materno = personaModel.apMaterno,
                    cargo = personaModel.cargo,
                    rol = personaModel.rol,
                    username = personaModel.username,
                    password = personaModel.pass,
                };
            }
            return resultDto;
        }
        
        public static explicit operator Persona(RegistrarPersonaDto personaDto)
        {
            var resultEntity = default(Persona);
            if (personaDto!= null)
            {
                resultEntity = new Persona
                {
                    nombres = personaDto.nombres,
                    apPaterno = personaDto.paterno,
                    apMaterno = personaDto.materno,
                    cargo = personaDto.cargo,
                    rol = personaDto.rol,
                    username = personaDto.username,
                    pass = personaDto.password,
                    estado = 1,
                };
            }
            return resultEntity;
        }
    }
}
