using Microsoft.EntityFrameworkCore;
using Solicitud_Fondos_Avance_API.Dtos;
using Solicitud_Fondos_Avance_API.Infrastructure.DataContext;
using Solicitud_Fondos_Avance_API.Infrastructure.Repositories.Interfaces;
using Solicitud_Fondos_Avance_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Solicitud_Fondos_Avance_API.Infrastructure.Repositories.Impl
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {

        protected DbContextSolicitudFondosAvance dbContextSolicitudFondosAvance;
        protected DbSet<T> dbSet;

        public GenericRepository(DbContextSolicitudFondosAvance dbContextSolicitudFondosAvance)
        {
            this.dbContextSolicitudFondosAvance = dbContextSolicitudFondosAvance;
            this.dbSet = dbContextSolicitudFondosAvance.Set<T>();
        }


        public async Task<T> Add(T entity)
        {
            var result = await dbSet.AddAsync(entity);
            await dbContextSolicitudFondosAvance.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<T>> All()
        {
            return (await dbSet.ToListAsync()).Where((entidadActual) => {
                Type entityType = entidadActual.GetType();
                if (entityType.IsSubclassOf(typeof(BaseEntity)))
                {
                    PropertyInfo propEstado = entityType.GetProperty("estado");
                    return ((byte)propEstado.GetValue(entidadActual)) == 1;
                }
                return false;
            });
        }

        public async Task<ResponseDeleteDto> Delete(int id)
        {
            var entityForDelete = await GetById(id);
            var response = new ResponseDeleteDto
            {
                deleted = false,
                message = "Ocurrio un error al eliminar"
            };
            if (entityForDelete != null)
            {
                Type entityType = entityForDelete.GetType();
                if (entityType.IsSubclassOf(typeof(BaseEntity)))
                {
                    PropertyInfo propEstado = entityType.GetProperty("estado");
                    propEstado.SetValue(entityForDelete, (byte)0);
                    
                    PropertyInfo propFechaModificacion = entityType.GetProperty("fecha_modificacion");
                    propFechaModificacion.SetValue(entityForDelete, DateTime.UtcNow);
                }
                dbSet.Update(entityForDelete);
                //dbSet.Remove(entityForDelete);
                dbContextSolicitudFondosAvance.SaveChanges();
                response.deleted = true;
                response.message = $"Eliminacion satisfactoria de la entidad con Id : {id}";
            }
            return response;
        }

        public Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public Task<bool> Upsert(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
