using System.Linq.Expressions;

using MegaApp.Domain.Common;

namespace MegaApp.Application.Interfaces.Persistance
{
    public interface _IGenericRepository<T> where T : class //BaseEntity<T>
    {
        Task<IEnumerable<T>> GetAllAsync(CancellationToken token);
        Task<T> GetByIdAsync(int id, CancellationToken token);
        Task InsertAsync(T entity, CancellationToken token);
        Task UpdateAsync(T entityToUpdate, CancellationToken token);
        Task DeleteAsync(int id, CancellationToken token);


        void AddRange(List<T> entities, CancellationToken token);
        // void UpdateRange(List<T> entities, CancellationToken token);
        // void DeleteRange(List<T> entities, CancellationToken token);
        List<T> Find(Expression<Func<T, bool>> predicate, CancellationToken token);

    }

}
