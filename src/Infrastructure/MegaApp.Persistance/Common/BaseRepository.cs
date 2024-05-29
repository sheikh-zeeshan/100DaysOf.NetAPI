using System.Linq.Expressions;

using MegaApp.Application.Interfaces.Persistance;
using MegaApp.Domain.Common;
using MegaApp.Persistance.DatabaseContext;
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

    public virtual async Task AddRangeAsync(List<TEntity> entities, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public virtual async Task DeleteAsync(int id, CancellationToken token)
    {
        var itemToDelete = await GetByIdAsync(id, token);
        if (itemToDelete != null)
        {
            await DeleteAsync(itemToDelete, token);
        }
    }

    public virtual async Task DeleteAsync(TEntity entity, CancellationToken token)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public virtual Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<List<TEntity>> GetAllAsync(CancellationToken token)
    {
        return await _context.Set<TEntity>().ShouldNotTrack(true).Take(1).ToListAsync(token);
    }

    public async Task<TEntity> GetByIdAsync(int id, CancellationToken token)
    {
        return await _context.Set<TEntity>().ShouldNotTrack(true).FirstOrDefaultAsync(x => x.Id == id, token);
    }

    public virtual async Task InsertAsync(TEntity entity, CancellationToken token)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync(token);
    }

    public virtual async Task UpdateAsync(TEntity entityToUpdate, CancellationToken token)
    {
        try
        {
            _context.Update(entityToUpdate);
            var result = await _context.SaveChangesAsync(token);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}

public static class EFExtensions
{
    public static IQueryable<TEntity> ShouldNotTrack<TEntity>(this IQueryable<TEntity> source, bool noTrack = true) where TEntity : class
    {
        return noTrack ? source.AsNoTracking() : source;
    }
}