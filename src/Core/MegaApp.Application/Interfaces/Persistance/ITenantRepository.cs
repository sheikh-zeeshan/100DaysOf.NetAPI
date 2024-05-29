
using MegaApp.Application.Interfaces.Persistance;
using MegaApp.Domain.Entities;

namespace MegaApp.Application.Interfaces.Persistance
{
    public interface ITenantRepository : IGenericRepository<Tenant>

    {

        bool IsTenantIsValid(int tenantId);

    }
}

public interface ITagRepository : IGenericRepository<Tag>
{

    Task UpsertTags(List<Tag> tags, int userID);
}