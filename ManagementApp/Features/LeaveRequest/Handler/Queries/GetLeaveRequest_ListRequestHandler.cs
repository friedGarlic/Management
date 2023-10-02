using AutoMapper;
using Management.Application.DTOs.LeaveRequest.Process;
using Management.Application.Features.LeaveRequest.Request.Queries;
using ManagementApp.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.LeaveRequest.Handler.Queries
{
    public class GetLeaveRequest_ListRequestHandler : IRequestHandler<GetLeaveRequest_ListRequest, List<LeaveRequestDTO>>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequest_ListRequestHandler(ILeaveRequestRepository repo, IMapper mapper)
        {
            _leaveRequestRepository = repo;
            _mapper = mapper;
        }

        public  async Task<List<LeaveRequestDTO>> Handle(GetLeaveRequest_ListRequest request, CancellationToken cancellationToken)
        {
            var leaveRequestList = await _leaveRequestRepository.GetLeaveRequestDetailList();
            return _mapper.Map<List<LeaveRequestDTO>>(leaveRequestList);
        }
    }
}
