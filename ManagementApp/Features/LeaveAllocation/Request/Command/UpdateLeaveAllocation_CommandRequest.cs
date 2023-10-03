using Management.Application.DTOs.LeaveAllocation.Process;
using Management.Application.DTOs.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.LeaveAllocation.Request.Command
{
    public class UpdateLeaveAllocation_CommandRequest : IRequest<Unit>
    {
        public LeaveAllocationDTO LeaveAllocationDTO { get; set; }

        public UpdateLeaveAllocationDTO UpdateLeaveAllocationDTO { get; set; }
    }
}
