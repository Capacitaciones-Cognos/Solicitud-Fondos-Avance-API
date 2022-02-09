using Microsoft.EntityFrameworkCore;
using Solicitud_Fondos_Avance_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solicitud_Fondos_Avance_API.Infrastructure.DataContext
{
    public class DbContextSolicitudFondosAvance : DbContext
    {
        public DbContextSolicitudFondosAvance(DbContextOptions<DbContextSolicitudFondosAvance> options)
            : base(options)
        {
        }

        // referencia a cada entidad o tabla
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Proyecto> Proyectos { get; set; }
        public virtual DbSet<SubProyecto> SubProyecto { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
