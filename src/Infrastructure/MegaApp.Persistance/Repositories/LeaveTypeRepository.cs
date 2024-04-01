using MegaApp.Application.Interfaces.Persistance;
using MegaApp.Domain.Entities;
using MegaApp.Persistance.Common;
using MegaApp.Persistance.DatabaseContext.Configurations;

using Microsoft.EntityFrameworkCore;

namespace MegaApp.Persistance.Repositories;

public class LeaveTypeRepository : BaseRepository<LeaveType>, ILeaveTypeRepository
{
    public LeaveTypeRepository(MegaDbContext context) : base(context)
    {
    }

    public async Task<bool> IsLeaveTypeUnique(string name)
    {
        return await _context.LeaveTypes.AnyAsync(q => q.Name == name);
    }
}