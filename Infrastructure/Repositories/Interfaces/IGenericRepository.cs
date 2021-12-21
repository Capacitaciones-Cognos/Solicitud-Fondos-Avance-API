using Solicitud_Fondos_Avance_API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Solicitud_Fondos_Avance_API.Infrastructure.Repositories.Interfaces
{
    public interface IGenericRepository<T> 
        where T:  class
    {
        Task<IEnumerable<T>> All();
        Task<T> GetById(int id);
        Task<T> Add(T entity);
        Task<bool> Upsert(T entity);
        Task<ResponseDeleteDto> Delete(int id);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);


    }
}
