using MegaApp.Domain.Entities;

namespace MegaApp.Application.Interfaces.Persistance
{
    public interface ILeaveAllocationRepository : _IGenericRepository<LeaveAllocation>
    {
        Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id, CancellationToken token);
        Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(CancellationToken token);
        Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId, CancellationToken token);
        Task<bool> AllocationExists(string userId, int leaveTypeId, int period, CancellationToken token);
        Task AddAllocations(List<LeaveAllocation> allocations, CancellationToken token);
        Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId, CancellationToken token);
    }

    // public interface IGenericRepository<T> where T : BaseEntity
    // {
    //     Task<IReadOnlyList<T>> GetAsync();
    //     Task<T> GetByIdAsync(int id);
    //     Task CreateAsync(T entity);
    //     Task UpdateAsync(T entity);
    //     Task DeleteAsync(T entity);
    // }
    // public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    // {
    //     Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);
    //     Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails();
    //     Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId);
    //     Task<bool> AllocationExists(string userId, int leaveTypeId, int period);
    //     Task AddAllocations(List<LeaveAllocation> allocations);
    //     Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId);
    //}

}
