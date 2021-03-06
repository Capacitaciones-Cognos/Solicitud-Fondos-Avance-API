using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solicitud_Fondos_Avance_API.Dtos;
using Solicitud_Fondos_Avance_API.Infrastructure.Repositories.Interfaces;
using Solicitud_Fondos_Avance_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solicitud_Fondos_Avance_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly IPersonaRepository personaRepository;

        public PersonasController(IPersonaRepository personaRepository)
        {
            this.personaRepository = personaRepository;
        }


        [HttpGet]
        public async Task<IEnumerable<GetPersonaDto>> getPersonas()
        {
            return (await personaRepository.All())
                .ToList()
                .ConvertAll(personaModel => (GetPersonaDto)personaModel);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Persona> getPersonById([FromRoute(Name = "id")] int id)
        {
            return await personaRepository.GetById(id);
        }

        [HttpPost]
        //[Route("add")]
        public async Task<GetPersonaDto> addPerson([FromBody] RegistrarPersonaDto personaDto)
        {
            return (GetPersonaDto)(await personaRepository.Add((Persona)personaDto));
        } 
        
        [HttpPost]
        [Route("add")]
        public async Task<Persona> addPersonWithValidation([FromBody] Persona persona)
        {
            return await personaRepository.addWithValidations(persona);
        }


        [HttpPut]
        public async Task<bool> upsertPerson([FromBody] Persona persona)
        {
            return await personaRepository.Upsert(persona);
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ResponseDeleteDto> removePerson(int id)
        {
            return await personaRepository.Delete(id);
        }


    }
}
