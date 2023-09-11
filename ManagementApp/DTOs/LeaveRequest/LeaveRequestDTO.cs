using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management.Application.DTOs.Common;
using Management.Application.DTOs.DataType;

namespace Management.Application.DTOs.LeaveRequest
{
    public class LeaveRequestDTO : BaseDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DateRequested { get; set; }

        public DataTypeDTO LeaveType { get; set; }
        public int LeaveTypeId { get; set; }

        public bool? IsApproved { get; set; }
        public bool IsDeclined { get; set; }
    }
}
