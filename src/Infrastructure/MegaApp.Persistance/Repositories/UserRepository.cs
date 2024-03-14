using MegaApp.Domain.BaseEntity;
using MegaApp.Persistance.Context;

using Microsoft.EntityFrameworkCore;

namespace MegaApp.Persistance.Repositories;

public class UserRepository
{

    //context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

}


public class GenericRepository<TEntity> : _IGenericRepository<TEntity> where TEntity : BaseEntity<TEntity>
{
    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task InsertAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(TEntity entityToUpdate)
    {
        throw new NotImplementedException();
    }
}
/*
public class UnitOfWork : IUnitOfWork
{
    private readonly IDbConnection _dbConnection;
    private IDbTransaction _dbTransaction { get; set; }

    private readonly ConcurrentDictionary<Type, object> _repositories;
    private bool _disposed = false;
    public UnitOfWork(
        IDbConnection dbConnection)
    {
        _repositories = new ConcurrentDictionary<Type, object>();
        _dbConnection = dbConnection;
        _dbConnection.Open();
        _dbTransaction = _dbConnection.BeginTransaction();

    }

    public _IGenericRepository<T> Repository<T>() where T : BaseEntity<T>
    {
        return _repositories.GetOrAdd(typeof(T), _ => new GenericRepository<T>(_dbTransaction)) as _IGenericRepository<T> ?? default!;
    }
    public void Commit()
    {
        try
        {
            _dbTransaction.Commit();
        }
        catch
        {
            _dbTransaction.Rollback();
            throw;
        }
        finally
        {
            _dbTransaction.Dispose();
            _repositories.Clear();
            _dbConnection?.Close();
            _dbConnection?.Dispose();
        }
    }

    public void Rollback()
    {
        try
        {
            _dbTransaction.Rollback();
        }
        catch
        {
            throw;
        }
        finally
        {
            _dbTransaction.Dispose();
            _repositories.Clear();
            _dbConnection?.Close();
            _dbConnection?.Dispose();
        }
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                // Dispose managed resources.
                _dbTransaction?.Dispose();
                _dbConnection?.Close();
                _dbConnection?.Dispose();
            }

            // Dispose unmanaged resources.

            _disposed = true;
        }
    }
}

*/