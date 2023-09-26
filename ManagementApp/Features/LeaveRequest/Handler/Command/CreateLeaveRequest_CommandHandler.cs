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
    internal class CreateLeaveRequest_CommandHandler : IRequestHandler<CreateLeaveRequest_CommandRequest, int>
    {
        private readonly ILeaveRequestRepository _repository;
        private readonly Mapper _mapper;

        public CreateLeaveRequest_CommandHandler(ILeaveRequestRepository repository, Mapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateLeaveRequest_CommandRequest commandRequest, CancellationToken token)
        {
            //TODO add validation before creating any shit

            var leaveRequest = _mapper.Map<Management.LeaveRequest>(commandRequest);

            leaveRequest = await _repository.Add(leaveRequest);
            
            return leaveRequest.Id;
        }
    }
}
