using Management.Application.DTOs.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.LeaveRequest.Request.Command
{
    internal class CreateLeaveRequest_CommandRequest : IRequest<int>
    {
            public LeaveRequestDTO LeaveRequestDTO { get; set; }
    }
}
