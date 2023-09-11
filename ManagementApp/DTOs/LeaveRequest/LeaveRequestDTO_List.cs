using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management.Application.DTOs.Common;
using Management.Application.DTOs.DataType;


namespace Management.Application.DTOs.LeaveRequest
{
    internal class LeaveRequestDTO_List : BaseDTO
    {
        public DateTime DateRequested { get; set; }

        public bool? Approved { get; set; }

        public DataTypeDTO LeaveType { get; set; }

    }
}
