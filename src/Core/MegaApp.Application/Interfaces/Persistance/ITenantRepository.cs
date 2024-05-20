
using MegaApp.Domain.Entities;

namespace MegaApp.Application.Interfaces.Persistance
{
    public interface ITenantRepository : IGenericRepository<Tenant>

    {

        bool IsTenantIsValid(int tenantId);

    }
}