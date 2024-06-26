using MegaApp.Application.Interfaces.Persistance;
using MegaApp.Domain.Entities;
using MegaApp.Persistance.Common;
using MegaApp.Persistance.DatabaseContext;
using MegaApp.Persistance.DatabaseContext.Configurations;

using Microsoft.EntityFrameworkCore;


namespace MegaApp.Persistance.Repositories;

public class TenantRepository : BaseRepository<Tenant>, ITenantRepository
{
    public TenantRepository(MegaDbContext context) : base(context)
    {

    }

    public bool IsTenantIsValid(int tenantId)
    {
        var data = GetByIdAsync(tenantId, new CancellationToken()).Result;

        return true;
    }

    public override async Task<List<Tenant>> GetAllAsync(CancellationToken token)
    {
        return await _context.Tenants.Include(x => x.Address).OrderBy(x => x.Id).Take(1).ToListAsync(token);

    }

    public override async Task InsertAsync(Tenant entity, CancellationToken token)
    {
        //get tags list save it to tag
        //get list of tags associated with Entity
        //upsert entity tags

        //eneity.Tags
        // await UpsertTags(entity.TenantHostels.SelectMany(x => x.Tags).ToList(), entity.AppUser.Id);

        await base.InsertAsync(entity, token);
    }


}