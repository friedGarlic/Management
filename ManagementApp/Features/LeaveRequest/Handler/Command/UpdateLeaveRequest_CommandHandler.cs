using AutoMapper;
using Management.Application.Features.LeaveRequest.Request.Command;
using ManagementApp.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.LeaveRequest.Handler.Command
{
    internal class UpdateLeaveRequest_CommandHandler : IRequestHandler<UpdateLeaveRequest_CommandRequest, Unit>
    {
        private readonly ILeaveRequestRepository _repository;
        private readonly Mapper _mapper;

        public UpdateLeaveRequest_CommandHandler(ILeaveRequestRepository repository, Mapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveRequest_CommandRequest commandRequest, CancellationToken token)
        {
            //get id
            var leaveRequest = await _repository.Get(commandRequest.LeaveRequestDTO.Id);

            //map
            _mapper.Map(commandRequest.LeaveRequestDTO, leaveRequest);

            //update
            await _repository.Update(leaveRequest);

            //return value
            return Unit.Value;
        }
    }
}
