using Management;

namespace Management.Application.Contracts.Persistence
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<LeaveAllocation> GetLeaveAllocationDetail(int Id);

        Task<List<LeaveAllocation>> GetLeaveAllocationDetailList();
    }
}
