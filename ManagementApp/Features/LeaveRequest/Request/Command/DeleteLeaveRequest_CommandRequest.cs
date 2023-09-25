using Management.Application.DTOs.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.LeaveRequest.Request.Command
{
    internal class DeleteLeaveRequest_CommandRequest : IRequest<Unit>
    {
        public LeaveRequestDTO LeaveRequestDTO { get; set; }
    }
}
