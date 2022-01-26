using Solicitud_Fondos_Avance_API.Dtos;
using Solicitud_Fondos_Avance_API.Dtos.personas;
using Solicitud_Fondos_Avance_API.Infrastructure.DataContext;
using Solicitud_Fondos_Avance_API.Infrastructure.Repositories.Interfaces;
using Solicitud_Fondos_Avance_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solicitud_Fondos_Avance_API.Infrastructure.Repositories.Impl
{
    public class PersonaRepository : GenericRepository<Persona>, IPersonaRepository
    {
        public PersonaRepository(DbContextSolicitudFondosAvance dbContextSolicitudFondosAvance) : base(dbContextSolicitudFondosAvance)
        {
        }

        public async Task<Persona> addWithProjects(Persona personaEntidad)
        {
            var entity = (await dbContextSolicitudFondosAvance.AddAsync(personaEntidad)).Entity;
            await dbContextSolicitudFondosAvance.SaveChangesAsync();
            entity.proyectos.AddRange(personaEntidad.proyectos);

            /*var entity = (await dbContextSolicitudFondosAvance.Personas.AddAsync(personaEntidad)).Entity;
            //var entity = (await dbSet.AddAsync(personaEntidad)).Entity;
            await dbContextSolicitudFondosAvance.SaveChangesAsync();*/
            return entity;
        }

        public async Task<Persona> addWithValidations(Persona persona)
        {
            var result = dbSet.FirstOrDefault(pr => pr.username == persona.username);
            if (result== null) // no existe persona con el usersname enviado por parametro
            {
                return await base.Add(persona);
            } else
            {
                return null; 
            }
        }



        /*public Task<bool> buscarPersonaPorNombreYApellido(string n, string ap)
        {
            base.dbSet.FirstOrDefault(a => a.nombres == n && a.apPaterno == ap);

        }*/
    }
}
