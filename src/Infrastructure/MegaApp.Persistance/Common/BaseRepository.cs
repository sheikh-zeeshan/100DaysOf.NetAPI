using System.Linq.Expressions;

using MegaApp.Application.Interfaces.Persistance;
using MegaApp.Domain.Common;

using MegaApp.Persistance.DatabaseContext.Configurations;

using Microsoft.EntityFrameworkCore;

namespace MegaApp.Persistance.Common;

public class BaseRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity //<TEntity>
{
    public readonly MegaDbContext _context;

    public BaseRepository(MegaDbContext context)
    {
        _context = context;
    }

    public Task AddRangeAsync(List<TEntity> entities, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken token)
    {
        return await _context.Set<TEntity>().ShouldNotTrack(true).ToListAsync(token);
    }

    public async Task<TEntity> GetByIdAsync(int id, CancellationToken token)
    {
        return await _context.Set<TEntity>().ShouldNotTrack(true).FirstOrDefaultAsync(x => x.Id == id, token);
    }

    public async Task InsertAsync(TEntity entity, CancellationToken token)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync(token);
    }

    public async Task UpdateAsync(TEntity entityToUpdate, CancellationToken token)
    {
        _context.Update(entityToUpdate);
        await _context.SaveChangesAsync(token);
    }
}

public static class EFExtensions
{
    public static IQueryable<TEntity> ShouldNotTrack<TEntity>(this IQueryable<TEntity> source, bool noTrack = true) where TEntity : class
    {
        return noTrack ? source.AsNoTracking() : source;
    }
}