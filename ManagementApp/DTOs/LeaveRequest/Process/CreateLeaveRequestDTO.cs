using Management.Application.DTOs.DataType.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.DTOs.LeaveRequest.Process
{
    internal class CreateLeaveRequestDTO : LeaveRequestDTO, ILeaveRequestDTO
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime DateReqested { get; set; }

        public string Description { get; set; }

        public DataTypeDTO LeaveType { get; set; }

        public int DataTypeId { get; set; } // whether leave is for sick, vacation etc
    }
}
