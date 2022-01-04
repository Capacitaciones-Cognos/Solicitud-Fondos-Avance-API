using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class ProyectoController : ControllerBase
    {

        private readonly IProyectoRepository proyectoRepository;

        public ProyectoController(IProyectoRepository proyectoRepository)
        {
            this.proyectoRepository = proyectoRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Proyecto>> GetAllProyectos()
        {
            string[] relations = new string[] { "persona" };
            return await proyectoRepository.FindAsync(includeProperties: relations);
        }
    }
}
