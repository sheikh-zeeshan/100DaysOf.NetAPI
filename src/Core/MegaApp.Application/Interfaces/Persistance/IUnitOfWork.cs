using MegaApp.Domain.Common;

namespace MegaApp.Application.Interfaces.Persistance
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        void Rollback();

        IGenericRepository<T> Repository<T>() where T : BaseEntity; //y<T>;
    }
}