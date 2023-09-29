using Management;

namespace ManagementApp.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequest> GetLeaveRequestDetail(int id);

        Task<List<LeaveRequest>> GetLeaveRequestDetailList();

        ///request for source, approval Change approval
        Task ChangeLeaveRequestApproval(LeaveRequest request, bool? approval);

    }
}
