using MegaApp.Domain.Entities;

namespace MegaApp.Application.Interfaces.Persistance
{
    public interface ILeaveTypeRepository : _IGenericRepository<LeaveType>
    {
        Task<bool> IsLeaveTypeUnique(string name);
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
