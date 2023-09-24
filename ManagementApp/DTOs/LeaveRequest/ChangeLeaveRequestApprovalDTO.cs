using Management.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.DTOs.LeaveRequest
{
    internal class ChangeLeaveRequestApprovalDTO : BaseDTO
    {
        public bool? IsApproved { get; set; }
    }
}
