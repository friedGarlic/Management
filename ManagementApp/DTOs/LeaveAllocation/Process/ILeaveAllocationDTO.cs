using Management.Application.DTOs.DataType.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.DTOs.LeaveAllocation.Process
{
    internal interface ILeaveAllocationDTO
    {
        public int NumberOfDays { get; set; }

        public DateTime DateCreated { get; set; }

        public DataTypeDTO LeaveType { get; set; }

        public int LeaveTypeId { get; set; }

        public int Period { get; set; }
    }
}
