using AutoMapper;
using Management.Application.Contracts.Persistence;
using Management.Application.DTOs.LeaveAllocation.Process;
using Management.Application.Features.DataType.Requests.Queries;
using Management.Application.Features.LeaveAllocation.Request.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.LeaveAllocation.Handler.Queries
{
    public class GetLeaveAllocation_DetailRequestHandler : IRequestHandler<GetLeaveAllocation_DetailRequest, LeaveAllocationDTO>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public GetLeaveAllocation_DetailRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<LeaveAllocationDTO> Handle(GetLeaveAllocation_DetailRequest request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationRepository.GetLeaveAllocationDetail(request.Id);
            return _mapper.Map<LeaveAllocationDTO>(leaveAllocation);
        }
    }
}
