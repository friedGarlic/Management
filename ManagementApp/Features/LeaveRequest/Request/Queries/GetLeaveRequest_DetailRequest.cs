using Management.Application.DTOs.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.LeaveRequest.Request.Queries
{
    internal class GetLeaveRequest_DetailRequest : IRequest<LeaveRequestDTO>
    {
        public int Id { get; set; }
    }
}
