using System.Linq.Expressions;

namespace MegaApp.Application.Interfaces.Persistance
{
    public interface IGenericRepository<T> where T : class //BaseEntity<T>
    {
        Task<List<T>> GetAllAsync(CancellationToken token);

        Task<T> GetByIdAsync(int id, CancellationToken token);

        Task InsertAsync(T entity, CancellationToken token);

        Task UpdateAsync(T entityToUpdate, CancellationToken token);

        Task DeleteAsync(int id, CancellationToken token);

        Task AddRangeAsync(List<T> entities, CancellationToken token);

        // void UpdateRange(List<T> entities, CancellationToken token);
        // void DeleteRange(List<T> entities, CancellationToken token);
        Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken token);
    }
}