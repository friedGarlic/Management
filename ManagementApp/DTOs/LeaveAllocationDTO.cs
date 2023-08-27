using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.DTOs.Common
{
    internal class LeaveAllocationDTO : BaseDTO
    {
        public string EmployeeId { get; set; }

        public int NumberOfDays { get; set; }

        public DateTime DateCreated { get; set; }

        public DataTypeDTO LeaveType { get; set; }

        public int LeaveTypeId { get; set; }

        public int Period { get; set; }
    }
}
