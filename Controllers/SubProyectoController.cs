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
    public class SubProyectoController : ControllerBase
    {
        private readonly ISubProyectoRepository subProyectoRepositorya;
        public SubProyectoController(ISubProyectoRepository subProyectoRepository)
        {
            this.subProyectoRepositorya = subProyectoRepository;
        }        
        [HttpGet]
        public async Task<IEnumerable<SubProyecto>> GetSubProyectos()
        {
            return (await subProyectoRepositorya.All())
                .ToList();
        }
        //[HttpPost]
        ////[Route("add")]
        //public async Task<SubProyecto> addPerson([FromBody] SubProyecto SubProyecto)
        //{
        //    return (await subProyectoRepositorya.Add((SubProyecto)));
        //}
        [HttpPost]
        //[Route("add")]
        public async Task<GetSubProyectoDTO> addPerson([FromBody] RegistrarSubProyectoDTO subpDTO)
        {
            return (GetSubProyectoDTO)(await subProyectoRepositorya.Add((SubProyecto)subpDTO));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ResponseDeleteDto> removeSubProyecto(int id)
        {
            return await subProyectoRepositorya.Delete(id);
        }

    }
}
