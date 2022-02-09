using Solicitud_Fondos_Avance_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solicitud_Fondos_Avance_API.Dtos
{
    public class RegistrarSubProyectoDTO
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int? proyectoId { get; set; }
        public int estado { get; set; }
        public static explicit operator RegistrarSubProyectoDTO(SubProyecto subProyectoModel)
        {
            var resultDto = default(RegistrarSubProyectoDTO);
            if (subProyectoModel != null)
            {
                resultDto = new RegistrarSubProyectoDTO
                {
                    nombre = subProyectoModel.nombre,
                    descripcion = subProyectoModel.descripcion,
                    fechaInicio = subProyectoModel.fechaInicio,
                    FechaFin = subProyectoModel.fechaFin,
                    proyectoId = subProyectoModel.proyectoId,
                    estado = subProyectoModel.estado,                  
                };
            }
            return resultDto;
        }
        public static explicit operator SubProyecto(RegistrarSubProyectoDTO SubProyectoDto)
        {
            var resultEntity = default(SubProyecto);
            if (SubProyectoDto != null)
            {
                resultEntity = new SubProyecto
                {
                    nombre = SubProyectoDto.nombre,
                    descripcion = SubProyectoDto.descripcion,
                    fechaInicio = SubProyectoDto.fechaInicio,
                    fechaFin = SubProyectoDto.FechaFin,
                    proyectoId = SubProyectoDto.proyectoId,                    
                    estado = 1,
                };
            }
            return resultEntity;
        }
    }
}
