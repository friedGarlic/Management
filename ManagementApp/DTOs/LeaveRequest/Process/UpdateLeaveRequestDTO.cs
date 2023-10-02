using Management.Application.DTOs.Common;
using Management.Application.DTOs.DataType.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.DTOs.LeaveRequest.Process
{
    public class UpdateLeaveRequestDTO : LeaveRequestDTO, ILeaveRequestDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LeaveTypeId { get; set; }
        public string Description { get; set; }
        public bool Cancelled { get; set; }
    }
}
