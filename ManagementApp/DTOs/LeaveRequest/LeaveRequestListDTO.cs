using Management.Application.DTOs.Common;
using Management.Application.DTOs.DataType.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.DTOs.LeaveRequest
{
    internal class LeaveRequestListDTO : BaseDTO
    {
        public DataTypeDTO LeaveType { get; set; }

        public int LeaveTypeId { get; set; }

        public bool? IsApproved { get; set; }
    }
}
