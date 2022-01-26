using Solicitud_Fondos_Avance_API.Dtos;
using Solicitud_Fondos_Avance_API.Dtos.personas;
using Solicitud_Fondos_Avance_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solicitud_Fondos_Avance_API.Infrastructure.Repositories.Interfaces
{
    public interface IPersonaRepository : IGenericRepository<Persona>
    {
        Task<Persona> addWithValidations(Persona persona);
        Task<Persona> addWithProjects(Persona personaDto);
        //Task<bool> buscarPersonaPorNombreYApellido(string n, string ap);
    }
}
