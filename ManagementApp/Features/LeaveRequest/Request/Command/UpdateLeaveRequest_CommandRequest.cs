using Management.Application.DTOs.LeaveRequest;
using Management.Application.DTOs.LeaveRequest.Process;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.LeaveRequest.Request.Command
{
    public class UpdateLeaveRequest_CommandRequest : IRequest<Unit>
    {
        public LeaveRequestDTO LeaveRequestDTO { get; set; }

        public ChangeLeaveRequestApprovalDTO ChangeLeaveRequestApprovalDTO { get; set; }
    }
}
