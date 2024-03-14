using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaApp.Domain.BaseEntity
{
    public abstract class BaseEntity<T>
    {
        public virtual T Id { get; set; }
    }

    public interface _IGenericRepository<T> where T : BaseEntity<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task InsertAsync(T entity);
        Task UpdateAsync(T entityToUpdate);
        Task DeleteAsync(int id);
    }

    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();
        _IGenericRepository<T> Repository<T>() where T : BaseEntity<T>;
    }

}