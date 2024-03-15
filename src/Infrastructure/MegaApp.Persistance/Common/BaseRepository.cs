
using System.Linq.Expressions;

using MegaApp.Application.Interfaces.Persistance;
using MegaApp.Domain.Common;
using MegaApp.Persistance.Context;

using Microsoft.EntityFrameworkCore;

namespace MegaApp.Persistance.Common;

public class GenericRepository<TEntity> : _IGenericRepository<TEntity> where TEntity : BaseEntity<TEntity>
{
    public void AddRange(List<TEntity> entities, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public List<TEntity> Find(Expression<Func<TEntity, bool>> predicate, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetByIdAsync(int id, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task InsertAsync(TEntity entity, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(TEntity entityToUpdate, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}