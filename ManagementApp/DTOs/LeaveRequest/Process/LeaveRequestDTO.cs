using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management.Application.DTOs.Common;
using Management.Application.DTOs.DataType.Process;

namespace Management.Application.DTOs.LeaveRequest.Process
{
    public class LeaveRequestDTO : BaseDTO, ILeaveRequestDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DateRequested { get; set; }

        public DataTypeDTO LeaveType { get; set; } // if sick leave, vacation , etc.. in table as OBJECT
        public int LeaveTypeId { get; set; } // if sick leave, vacation , etc.. in table as ID(INT)

        public bool? IsApproved { get; set; }
        public bool IsDeclined { get; set; }
    }
}
