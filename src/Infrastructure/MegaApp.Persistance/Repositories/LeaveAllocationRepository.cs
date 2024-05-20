using MegaApp.Application.Interfaces.Persistance;
using MegaApp.Domain.Entities;
using MegaApp.Persistance.Common;
using MegaApp.Persistance.DatabaseContext;
using MegaApp.Persistance.DatabaseContext.Configurations;

using Microsoft.EntityFrameworkCore;

namespace MegaApp.Persistance.Repositories;

public class LeaveAllocationRepository : BaseRepository<LeaveAllocation>, ILeaveAllocationRepository
{
    public LeaveAllocationRepository(MegaDbContext context) : base(context)
    {
    }

    public async Task AddAllocations(List<LeaveAllocation> allocations)
    {
        await _context.AddRangeAsync(allocations);
        await _context.SaveChangesAsync();
    }
    //optimize the below function
    public async Task<bool> AllocationExists(int userId, int leaveTypeId, int period)
    {
        //
        return await _context.LeaveAllocations.AnyAsync(q => q.EmployeeId == userId
                                    && q.LeaveTypeId == leaveTypeId
                                    && q.Period == period);
    }


    public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
    {
        var leaveAllocations = await _context.LeaveAllocations
           .Include(q => q.LeaveType)
           .ToListAsync();
        return leaveAllocations;
    }

    public async Task<List<LeaveAllocation>> GetUserLeaveAllocationsWithDetails(int userId)
    {
        var leaveAllocations = await _context.LeaveAllocations.Where(q => q.EmployeeId == userId)
           .Include(q => q.LeaveType)
           .ToListAsync();
        return leaveAllocations;
    }

    public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
    {
        var leaveAllocation = await _context.LeaveAllocations
            .Include(q => q.LeaveType)
            .FirstOrDefaultAsync(q => q.Id == id);

        return leaveAllocation;
    }

    public async Task<LeaveAllocation> GetUserAllocations(int userId, int leaveTypeId)
    {
        //fix the below warning null ref exception in code
        // return await _context.LeaveAllocations.FirstOrDefaultAsync(q => q. == userId
        //                             && q.LeaveTypeId == leaveTypeId);
        return await _context.LeaveAllocations.FirstOrDefaultAsync(q => q.EmployeeId == userId
                                    && q.LeaveTypeId == leaveTypeId);



    }
}