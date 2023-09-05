using Management;

namespace ManagementApp.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {

        Task<LeaveAllocation> GetLeaveRequestDetail(int Id);

        Task<List<LeaveAllocation>> GetLeaveRequestDetailList();
    }
}
