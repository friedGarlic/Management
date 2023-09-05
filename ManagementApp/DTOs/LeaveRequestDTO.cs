using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.DTOs.Common
{
    public class LeaveRequestDTO : BaseDTO
    {
        public string EmployeeId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DateRequested { get; set; }

        public DataTypeDTO LeaveType { get; set; }
        public int LeaveTypeId { get; set; }

        public bool? IsApproved { get; set; }
        public bool IsDeclined { get; set; }
    }
}
