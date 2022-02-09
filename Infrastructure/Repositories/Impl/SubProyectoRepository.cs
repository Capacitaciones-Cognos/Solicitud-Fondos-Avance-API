using Solicitud_Fondos_Avance_API.Infrastructure.DataContext;
using Solicitud_Fondos_Avance_API.Infrastructure.Repositories.Interfaces;
using Solicitud_Fondos_Avance_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solicitud_Fondos_Avance_API.Infrastructure.Repositories.Impl
{
    public class SubProyectoRepository: GenericRepository<SubProyecto>, ISubProyectoRepository
    {
        public SubProyectoRepository(DbContextSolicitudFondosAvance dbContextSolicitudFondosAvance) : base(dbContextSolicitudFondosAvance)
        {
        }
    }
}
