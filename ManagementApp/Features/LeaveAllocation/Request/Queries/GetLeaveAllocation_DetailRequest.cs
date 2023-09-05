using Management.Application.DTOs.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.LeaveAllocation.Request.Queries
{
    internal class GetLeaveAllocation_DetailRequest : IRequest<LeaveAllocationDTO>
    {
        public int Id { get; set; }
    }
}
