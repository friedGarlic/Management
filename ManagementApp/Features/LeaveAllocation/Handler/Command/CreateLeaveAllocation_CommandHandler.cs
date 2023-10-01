using AutoMapper;
using Management.Application.DTOs.LeaveAllocation;
using Management.Application.DTOs.LeaveAllocation.Validation;
using Management.Application.Features.LeaveAllocation.Request.Command;
using ManagementApp.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.LeaveAllocation.Handler.Command
{
    internal class CreateLeaveAllocation_CommandHandler : IRequestHandler<CreateLeaveAllocation_CommandRequest, int>
    {
        private readonly ILeaveAllocationRepository _repository;
        private readonly Mapper _mapper;

        public CreateLeaveAllocation_CommandHandler(ILeaveAllocationRepository repository, Mapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateLeaveAllocation_CommandRequest request, CancellationToken cancellationToken)
        {
            //TODO implement validation before doing anything shit
            

            var leaveAlloc = _mapper.Map<Management.LeaveAllocation>(request.LeaveAllocationDTO);

            leaveAlloc = await _repository.Add(leaveAlloc);

            return leaveAlloc.Id;
        }
    }
}
