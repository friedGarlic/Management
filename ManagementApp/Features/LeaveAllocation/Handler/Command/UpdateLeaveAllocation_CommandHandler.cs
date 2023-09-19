using AutoMapper;
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
    internal class UpdateLeaveAllocation_CommandHandler : IRequestHandler<UpdateLeaveAllocation_CommandRequest, Unit>
    {
        private readonly ILeaveAllocationRepository _repository;
        private readonly Mapper _mapper;

        public UpdateLeaveAllocation_CommandHandler(ILeaveAllocationRepository repository, Mapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle (UpdateLeaveAllocation_CommandRequest request, CancellationToken token)
        {
            
            return Unit.Value;
        }
    }
}
