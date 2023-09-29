using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management.Application.DTOs.Common;
using Management.Application.DTOs.DataType.Process;

namespace Management.Application.DTOs.LeaveAllocation.Process
{
    public class LeaveAllocationDTO : BaseDTO
    {
        public int NumberOfDays { get; set; }

        public DateTime DateCreated { get; set; }

        public DataTypeDTO LeaveType { get; set; }

        public int LeaveTypeId { get; set; }

        public int Period { get; set; }
    }
}
