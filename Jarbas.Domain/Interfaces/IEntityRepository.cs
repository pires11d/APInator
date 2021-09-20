using Jarbas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jarbas.Domain.Interfaces
{
    public interface IEntityRepository<T> 
        where T : class, IEntity
    {
        Task<List<T>> GetAll();
        Task<T> GetById(object id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> DeleteById(object id);
    }
}