using AutoMapper;
using Management.Application.DTOs.LeaveRequest;
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
    internal class GetLeaveRequest_DetailRequestHandler : IRequestHandler<GetLeaveRequest_DetailRequest, LeaveRequestDTO>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequest_DetailRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<LeaveRequestDTO> Handle(GetLeaveRequest_DetailRequest request, CancellationToken cancellation) 
        {
            var leaveRequest = await _leaveRequestRepository.GetLeaveRequestDetail(request.Id);
            return _mapper.Map<LeaveRequestDTO>(leaveRequest);
        }
    }
}
