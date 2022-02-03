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
            Type entityType = entity.GetType();
            if (entityType.IsSubclassOf(typeof(BaseEntity)))
            {
                PropertyInfo propEstado = entityType.GetProperty("estado");
                propEstado.SetValue(entity, (byte)1);

                PropertyInfo propFechaCreacion = entityType.GetProperty("fecha_creacion");
                propFechaCreacion.SetValue(entity, DateTime.UtcNow);

                PropertyInfo propFechaModificacion = entityType.GetProperty("fecha_modificacion");
                propFechaModificacion.SetValue(entity, DateTime.UtcNow);
            }

            var result = await dbSet.AddAsync(entity);
            await dbContextSolicitudFondosAvance.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<IEnumerable<T>> All()
        {
            return (await dbSet.ToListAsync()).Where((entidadActual) =>
            {
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
                message = "Ocurrio un error al eliminar, ID de no existente"
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

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params string[] includeProperties)
        {
            IQueryable<T> query = dbSet;

            // include properties will be comma separated
            includeProperties.ToList()
                .ForEach(prop => query = query.Include(prop));

            // aplicate filter
            if (filter != null)
            {
                query = query.Where(filter);
            }

            // aplicate order by
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            return (await query.ToListAsync()).Where((entidadActual) =>
            {
                Type entityType = entidadActual.GetType();
                if (entityType.IsSubclassOf(typeof(BaseEntity)))
                {
                    PropertyInfo propEstado = entityType.GetProperty("estado");
                    return ((byte)propEstado.GetValue(entidadActual)) == 1;
                }
                return false;
            });
        }

        public async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<bool> Upsert(T entity)
        {

            Type entityType = entity.GetType();
            if (entityType.IsSubclassOf(typeof(BaseEntity)))
            {
                PropertyInfo propIdEnviado = entityType.GetProperty("id");
                int idEntitySend = (int)propIdEnviado.GetValue(entity);

                T entitySearch = dbSet.Find(idEntitySend);
                /*Type entityTypeSearch = entitySearch.GetType();
                PropertyInfo propIdSearch = entityTypeSearch.GetProperty("id");
                int idSearch = (int)propIdSearch.GetValue(entitySearch);*/

                if (entitySearch== null) // registrar
                {
                    await Add(entity);
                }
                else // actualizar
                {
                    PropertyInfo[] propertiesSend = entityType.GetProperties();
                    foreach (PropertyInfo propertySend in propertiesSend)
                    {
                        string propSendName = propertySend.Name;

                        PropertyInfo propSearch = entitySearch.GetType().GetProperty(propSendName);
                        if (propSearch != null && !propSearch.Name.Equals("estado") && !propSearch.Name.Equals("fecha_creacion"))
                        {
                            object valuePropSend = propertySend.GetValue(entity);
                            propSearch.SetValue(entitySearch, valuePropSend);
                        }
                    }
                    PropertyInfo propFechaModificacion = entityType.GetProperty("fecha_modificacion");
                    propFechaModificacion.SetValue(entitySearch, DateTime.UtcNow);

                    dbContextSolicitudFondosAvance.Entry(entitySearch).State = EntityState.Modified;
                    dbContextSolicitudFondosAvance.SaveChanges();
                }
                return true;
            }
            return false;
        }
    }
}
