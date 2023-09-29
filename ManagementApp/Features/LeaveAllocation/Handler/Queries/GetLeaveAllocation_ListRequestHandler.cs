using AutoMapper;
using Management.Application.DTOs.LeaveAllocation.Process;
using Management.Application.Features.DataType.Requests.Queries;
using Management.Application.Features.LeaveAllocation.Request.Queries;
using ManagementApp.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.LeaveAllocation.Handler.Queries
{
    internal class GetLeaveAllocation_ListRequestHandler : IRequestHandler<GetLeaveAllocation_ListRequest, List<LeaveAllocationDTO>>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public GetLeaveAllocation_ListRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<List<LeaveAllocationDTO>> Handle(GetLeaveAllocation_ListRequest request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationRepository.GetLeaveAllocationDetailList();
            return _mapper.Map<List<LeaveAllocationDTO>>(leaveAllocation);
        }
    }
}
