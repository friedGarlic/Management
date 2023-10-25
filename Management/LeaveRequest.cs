using Management.Domain;

namespace Management
{
    public class LeaveRequest : BaseDomainEntity
    {
        public int Id { get; set; }

        public string EmployeeId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DateRequested { get; set; }

        public DataType LeaveType { get; set; }
        public int LeaveTypeId { get; set; }

        public bool? IsApproved { get; set; }
        public bool IsDeclined { get; set; }
    }
}