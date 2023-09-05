using Management;

namespace ManagementApp.Contracts
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<LeaveAllocation> GetLeaveAllocationDetail(int Id);

        Task<List<LeaveAllocation>> GetLeaveAllocationDetailList();
    }
}
