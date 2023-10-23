using Management.Application.DTOs.LeaveRequest.Process;
using Management.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.LeaveRequest.Request.Command
{
    public class CreateLeaveRequest_CommandRequest : IRequest<BaseCommandResponse>
    {
        public LeaveRequestDTO LeaveRequestDTO { get; set; }
        public CreateLeaveRequestDTO CreateLeaveRequestDTO { get; set; }
    }
}
