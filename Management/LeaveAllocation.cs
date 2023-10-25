using Management.Domain;

namespace Management
{
    public class LeaveAllocation : BaseDomainEntity
    {
        public int Id { get; set; }

        public string EmployeeId { get; set; }

        public int NumberOfDays { get; set; }

        public DateTime DateCreated { get; set; }

        public DataType LeaveType { get; set; }

        public int LeaveTypeId { get; set; }

        public int Period { get; set; }
    }
}