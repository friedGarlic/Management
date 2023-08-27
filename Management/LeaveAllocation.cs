using Management.Common;

namespace Management
{
    public class LeaveAllocation : ModifyEntity
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