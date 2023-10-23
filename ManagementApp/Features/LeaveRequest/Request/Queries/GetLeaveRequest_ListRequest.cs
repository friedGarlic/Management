using Management.Application.DTOs.LeaveRequest.Process;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.LeaveRequest.Request.Queries
{
    public class GetLeaveRequest_ListRequest : IRequest<List<LeaveRequestDTO>>
    {
        public GetLeaveRequest_ListRequest()
        {
            
        }

        public int Id { get; set; }
    }
}
