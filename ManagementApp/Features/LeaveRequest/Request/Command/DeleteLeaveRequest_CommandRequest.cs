using Management.Application.DTOs.LeaveRequest.Process;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.LeaveRequest.Request.Command
{
    public class DeleteLeaveRequest_CommandRequest : IRequest<Unit>
    {
        public int ID { get; set; } //TODO idk why theres a object of id when theres a leaverequestDTO.id

        public LeaveRequestDTO LeaveRequestDTO { get; set; }
    }
}
