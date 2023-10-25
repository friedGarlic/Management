using Management.Domain;

namespace Management
{
    public class DataType : BaseDomainEntity
    {
        public string Name { get; set; }

        public int LeaveTypeDefaultDays { get; set; }
    }
}