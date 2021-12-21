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
        public async Task<IEnumerable<Persona>> getPersonas()
        {
            return await personaRepository.All();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Persona> getPersonById([FromRoute(Name = "id")] int id)
        {
            return await personaRepository.GetById(id);
        }

        [HttpPost]
        //[Route("add")]
        public async Task<Persona> addPerson([FromBody] Persona persona)
        {
            return await personaRepository.Add(persona);
        } 
        
        [HttpPost]
        [Route("add")]
        public async Task<Persona> addPersonWithValidation([FromBody] Persona persona)
        {
            return await personaRepository.addWithValidations(persona);
        } 

        [HttpDelete]
        [Route("{id}")]
        public async Task<ResponseDeleteDto> removePerson(int id)
        {
            return await personaRepository.Delete(id);
        }


    }
}
