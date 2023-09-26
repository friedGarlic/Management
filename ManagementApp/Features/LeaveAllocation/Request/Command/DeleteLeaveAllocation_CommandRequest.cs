using Management.Application.DTOs.LeaveAllocation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.LeaveAllocation.Request.Command
{
    internal class DeleteLeaveAllocation_CommandRequest : IRequest<int>
    {
        public LeaveAllocationDTO LeaveAllocationDTO { get; set; }
    }
}
