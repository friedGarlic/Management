using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management.Application.DTOs.LeaveAllocation.Process;
using MediatR;

namespace Management.Application.Features.LeaveAllocation.Request.Command
{
    public class CreateLeaveAllocation_CommandRequest : IRequest<int>
    {
        public LeaveAllocationDTO LeaveAllocationDTO { get; set; }
        public CreateLeaveAllocationDTO CreateLeaveAllocationDTO { get; set; }
    }
}
