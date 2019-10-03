using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadCliente.Data.Core.Repository.Interfaces
{
    public interface IRepository<T>
    {
        Task SaveAsync(T entity);
        Task<T> GetAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
